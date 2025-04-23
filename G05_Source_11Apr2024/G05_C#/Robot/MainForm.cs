using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using VideoSource;
using motion;
using TCPClient;
using System.Reflection;

namespace Robot
{
    // NOTE:
    // This main program run with threading & event for a better response
    // It will be an advantage if has some multi-threading knowledge
    public partial class MainForm : Form
    {
        #region Local const declaration

        //Default Link Parameters in CM
        const double Link1 = 95;
        const double Link2 = 28;
        const double Link3 = 155;


        // Upper & Lower bounds for object detection
        private const int Ubound = 190; //190
        private const int Lbound = 170; //170

        // Start and End bytes for Tx Packet
        private const byte STX = 0x30;
        private const byte ETX = 0x40;

        // Flag for summing up encoder vel values
        private int flag = 0;
        // Flag to check for motor distance (during 1m run)
        private int chkflag = 0;

        // ARM Servo motors default values
        private const int SV1_DEFAULT_ANGLE = 0;
        private const int SV2_DEFAULT_ANGLE = 0;
        private const int SV3_DEFAULT_ANGLE = -1000;
        private const int SV4_DEFAULT_ANGLE = 0;
        private const int SV5_DEFAULT_ANGLE = 0;
        private const int SV6_DEFAULT_ANGLE = 0;
        private const int SV7_DEFAULT_ANGLE = 0;
        private const int SV8_DEFAULT_ANGLE = 0;

        // Command Type
        private const byte TYPE_WHEEL = 0x00;
        private const byte TYPE_SERVO = 0x01;
        // private const byte TYPE_DIST_SENSOR = 0x02;

        // Command for wheel
        private const byte CMD_WHEEL_STOP = 0x00;
        private const byte CMD_WHEEL_FWD = 0x01;
        private const byte CMD_WHEEL_BWD = 0x02;
        private const byte CMD_WHEEL_LEFT = 0x03;
        private const byte CMD_WHEEL_RIGHT = 0x04;
        private const byte CMD_WHEEL_LEFT_DUTY = 0x05;
        private const byte CMD_WHEEL_RIGHT_DUTY = 0x06;
        private const byte CMD_WHEEL_ALL_DUTY = 0x07;

        // Command for servo
        private const byte CMD_SV_ASTEP_INTERVAL_MS = 0x09;
        private const byte CMD_SV_ASTEP_RES = 0x0A;
        private const byte CMD_ARM_ENABLE = 0x0B;
        private const byte CMD_ARM_DISABLE = 0x0C;

        // Event number for rc servos
        private const int EVT_COMP_SERVO1 = 0;
        private const int EVT_COMP_SERVO2 = 1;
        private const int EVT_COMP_SERVO3 = 2;
        private const int EVT_COMP_SERVO4 = 3;
        private const int EVT_COMP_SERVO5 = 4;
        private const int EVT_COMP_SERVO6 = 5;
        private const int EVT_COMP_SERVO7 = 6;
        private const int EVT_COMP_SERVO8 = 7;

        // Event number for general actions/movement
        private const int EVT_CTRL_PARKING_POS = 0;
        private const int EVT_CTRL_INITIAL_POS = 1;
        private const int EVT_CTRL_SYS_SHUTWON = 2;
        private const int EVT_CTRL_WHEEL_MOVE = 3;
        private const int EVT_CTRL_SERVO_MOVE_1 = 4;
        private const int EVT_CTRL_SERVO_MOVE_2 = 5;
        private const int EVT_CTRL_SERVO_MOVE_3 = 6;
        private const int EVT_CTRL_SERVO_MOVE_4 = 7;
        private const int EVT_CTRL_SERVO_MOVE_5 = 8;
        private const int EVT_CTRL_SERVO_MOVE_6 = 9;
        private const int EVT_CTRL_SERVO_MOVE_7 = 10;
        private const int EVT_CTRL_SERVO_MOVE_8 = 11;
        private const int EVT_CTRL_DRAW_LINE = 12;
        private const int EVT_CTRL_PICK_PLACE_START = 13;
        private const int EVT_CTRL_PICK_PLACE_MOVE = 14;
        private const int EVT_CTRL_PICK_PLACE_DONE = 15;
        private const int EVT_CTRL_MV_SQ_START = 16;
        // private const int EVT_CTRL_MV_SQ_LEFT = 17;
        // private const int EVT_CTRL_MV_SQ_FWD = 18;

        // Variables for Sensor and Encoders
        private int distmm = 0;
        private long ENC1, ENC2 = 0;
        private long sum1, sum2 = 0;

        // Variables for Forward Kinematics
        private double q1 = 0;
        private double q2 = 0;
        private double q3 = 0;
        private float e0, e1, e2, e3 = 0;
        private float r11, r12, r13 = 0;
        private float r21, r22, r23 = 0;
        private float r31, r32, r33 = 0;
       
        private IMotionDetector detector = null;
        private Camera camera;
        private Client client = null;   //Client Socket class
        private bool bArmEnable = false;
        private int WheelPWMDutyCycle = 4000;  //x100 = 75%
        private byte CurrentMoveDirection = CMD_WHEEL_STOP;
        private int[] CurrentAngle = new int[8];        

        Thread CtrlThreadHandle;
        Thread TcpThreadHandle;
        private AutoResetEvent evtTcpReceived = new AutoResetEvent(true);
        private AutoResetEvent evtAcknowledge = new AutoResetEvent(true);
        private AutoResetEvent[] evtHandles = new AutoResetEvent[24];
        private AutoResetEvent[] evtServoHandles = new AutoResetEvent[8];
        private int[] TimeoutCount = new int[8];
        private ConcurrentQueue<byte> TcpReceivedQueue = new ConcurrentQueue<byte>();
        
        #endregion

        #region Local functions
        private void ArmDefaultPosition()
        {
            CurrentAngle[0] = SV1_DEFAULT_ANGLE; //angle x 100
            CurrentAngle[1] = SV2_DEFAULT_ANGLE; //angle x 100
            CurrentAngle[2] = SV3_DEFAULT_ANGLE; //angle x 100
            CurrentAngle[3] = SV4_DEFAULT_ANGLE; //angle x 100
            CurrentAngle[4] = SV5_DEFAULT_ANGLE; //angle x 100
            CurrentAngle[5] = SV6_DEFAULT_ANGLE; //angle x 100
            CurrentAngle[6] = SV7_DEFAULT_ANGLE; //angle x 100
            CurrentAngle[7] = SV8_DEFAULT_ANGLE; //angle x 100

            if( false == bArmEnable )
            {
                return;
            }

            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 1, CurrentAngle[0]);
            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 2, CurrentAngle[1]);
            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 3, CurrentAngle[2]);
            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 4, CurrentAngle[3]);
            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 5, CurrentAngle[4]);
            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 6, CurrentAngle[5]);
            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 7, CurrentAngle[6]);
            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 8, CurrentAngle[7]);

            TimeoutCount[0] = 5;
            SetServoAngle(1, CurrentAngle[0]);
            TimeoutCount[1] = 5;
            SetServoAngle(2, CurrentAngle[1]);
            TimeoutCount[2] = 5;
            SetServoAngle(3, CurrentAngle[2]);
            TimeoutCount[3] = 5;
            SetServoAngle(4, CurrentAngle[3]);
            TimeoutCount[4] = 5;
            SetServoAngle(5, CurrentAngle[4]);
            TimeoutCount[5] = 5;
            SetServoAngle(6, CurrentAngle[5]);
            TimeoutCount[6] = 5;
            SetServoAngle(7, CurrentAngle[6]);
            TimeoutCount[7] = 5;
            SetServoAngle(8, CurrentAngle[7]);
        }
        
        private bool ArmPosition(int t1, int t2, int t3)
        {
            int teta1 = t1;
            int teta2 = t2;
            int teta3 = t3;
            CurrentAngle[0] = teta1; //angle x 100
            CurrentAngle[1] = teta2; //angle x 100
            CurrentAngle[2] = SV3_DEFAULT_ANGLE; //angle x 100
            CurrentAngle[3] = teta3;
            CurrentAngle[4] = SV5_DEFAULT_ANGLE; //angle x 100
            CurrentAngle[5] = SV6_DEFAULT_ANGLE; //angle x 100
            CurrentAngle[6] = SV7_DEFAULT_ANGLE; //angle x 100
            CurrentAngle[7] = SV8_DEFAULT_ANGLE; //angle x 100

            if (false == bArmEnable)
            {
                MessageBox.Show("Please Enable Arm Before Trying Again!");
                return false;
            }

            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 1, CurrentAngle[0]);
            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 2, CurrentAngle[1]);
            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 3, CurrentAngle[2]);
            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 4, CurrentAngle[3]);
            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 5, CurrentAngle[4]);
            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 6, CurrentAngle[5]);
            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 7, CurrentAngle[6]);
            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 8, CurrentAngle[7]);

            TimeoutCount[0] = 5;
            SetServoAngle(4, CurrentAngle[3]);
            TimeoutCount[4] = 5;
            SetServoAngle(3, CurrentAngle[2]);
            TimeoutCount[3] = 5;
            SetServoAngle(2, CurrentAngle[1]);
            TimeoutCount[2] = 5;
            SetServoAngle(1, CurrentAngle[0]);
            TimeoutCount[1] = 5;
            SetServoAngle(5, CurrentAngle[4]);
            TimeoutCount[5] = 5;
            SetServoAngle(6, CurrentAngle[5]);
            TimeoutCount[6] = 5;
            SetServoAngle(7, CurrentAngle[6]);
            TimeoutCount[7] = 5;
            SetServoAngle(8, CurrentAngle[7]);

            return true;
        }


        private void ArmParkingPosition()
        {
            CurrentAngle[0] = SV1_DEFAULT_ANGLE; //angle x 100
            CurrentAngle[1] = SV2_DEFAULT_ANGLE; //angle x 100
            CurrentAngle[2] = SV3_DEFAULT_ANGLE; //angle x 100
            CurrentAngle[3] = SV4_DEFAULT_ANGLE; //angle x 100
            CurrentAngle[4] = SV5_DEFAULT_ANGLE; //angle x 100
            CurrentAngle[5] = SV6_DEFAULT_ANGLE; //angle x 100
            CurrentAngle[6] = SV7_DEFAULT_ANGLE; //angle x 100
            CurrentAngle[7] = SV8_DEFAULT_ANGLE; //angle x 100

            if (false == bArmEnable)
            {
                return;
            }

            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 1, CurrentAngle[0]);
            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 2, CurrentAngle[1]);
            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 3, CurrentAngle[2]);
            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 4, CurrentAngle[3]);
            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 5, CurrentAngle[4]);
            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 6, CurrentAngle[5]);
            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 7, CurrentAngle[6]);
            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 8, CurrentAngle[7]);

            TimeoutCount[0] = 5;
            SetServoAngle(1, CurrentAngle[0]);
            TimeoutCount[1] = 5;
            SetServoAngle(2, CurrentAngle[1]);
            TimeoutCount[2] = 5;
            SetServoAngle(3, CurrentAngle[2]);
            TimeoutCount[3] = 5;
            SetServoAngle(4, CurrentAngle[3]);
            TimeoutCount[4] = 5;
            SetServoAngle(5, CurrentAngle[4]);
            TimeoutCount[5] = 5;
            SetServoAngle(6, CurrentAngle[5]);
            TimeoutCount[6] = 5;
            SetServoAngle(7, CurrentAngle[6]);
            TimeoutCount[7] = 5;
            SetServoAngle(8, CurrentAngle[7]);
        }

        private void WheelMoveToDirection()
        {
            if(CurrentMoveDirection == CMD_WHEEL_STOP)
            {
                MotorWheelDuty(0);  // duty cycle x100
            }
            else
            {
                MotorWheelDuty(WheelPWMDutyCycle);  // duty cycle x100
            }
            
            MotorMovement(CurrentMoveDirection);
            Invoke(new UPDATE_WHEEL_MOVEMENT(UpdateWheelMovement), WheelPWMDutyCycle, CurrentMoveDirection);
        }

        private bool ConnectToHostServer()
        {
            try
            {
                if (client == null)
                {
                    client = new Client();
                }
                else
                {
                    //if we get here then we already have a client object so see if we are already connected
                    if (client.Connected)
                        return true;
                }

                IPAddress ipAdd = IPAddress.Parse("192.168.1.1");
                client.Disconnect();
                client.Connect(ipAdd, 2001);

                if (client.Connected)
                {
                    client.OnDisconnected += OnDisconnect;
                    client.OnReceiveData += OnDataReceive;

                    Debug.WriteLine(" Client connected to server\r\n");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                var exceptionMessage = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                Debug.WriteLine("EXCEPTION IN: ConnectToHostServer - {exceptionMessage}");
            }
            return false;
        }

        private void GetWiFiRSSI(ref string Ssid, ref string Percent)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = "netsh.exe";
                p.StartInfo.Arguments = "wlan show interfaces";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.Start();

                string s0 = p.StandardOutput.ReadToEnd();
                int i = s0.IndexOf("Receive rate");
                if(i < 0)
                {
                    return;
                }

                string s1 = s0.Substring(s0.IndexOf("SSID"));
                if(null == s1)
                {
                    return;
                }
                s1 = s1.Substring(s1.IndexOf(":"));
                s1 = s1.Substring(2, s1.IndexOf("\n")).Trim();
                Ssid = s1;

                string s2 = s0.Substring(s0.IndexOf("Signal"));
                s2 = s2.Substring(s2.IndexOf(":"));
                s2 = s2.Substring(2, s2.IndexOf("\n")).Trim();
                Percent = s2;
            }
            catch (Exception)
            {
                Percent = "0%";
            }
        }

        /// <summary>
        /// This function uses to trigger servo event to move to desired angle
        /// The Angle shall be x100. example: 5000 = 50 degree
        /// </summary>
        /// <param name="nSv"></param>
        /// <param name="nAngle"></param>
        private void TriggerServo(int nSv, int nAngle)
        {
            if (false == bArmEnable)
            {
                MessageBox.Show("Robot ARM not enable.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Math.Abs(nAngle) > 18000)
            {
                MessageBox.Show(
                    "Out of range. Angle shall within 0.00° to 180.00°",
                    "Out of Range",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (0 == nSv)
            {
                MessageBox.Show(
                    "Servo Index could not be 0.",
                    "Warning",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);

                return;
            }

            int index = nSv - 1;
            CurrentAngle[index] = nAngle;
            evtHandles[EVT_CTRL_SERVO_MOVE_1 + index].Set();
        }

        /// <summary>
        /// Set RC servo angle by specify sevo index
        /// </summary>
        /// <param name="nServo"></param>
        /// <param name="Angle"></param>
        private void SetServoAngle(int nServo, int Angle)
        {
            byte[] Data = new byte[6];

            if (nServo <= 0)
            {
                MessageBox.Show(
                    "Servo motor number cannot be 0",
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);

                return;
            }

            Data[0] = STX;
            Data[1] = TYPE_SERVO;
            Data[2] = Convert.ToByte(nServo);
            Data[3] = Convert.ToByte(Angle & 0xff);
            Data[4] = Convert.ToByte((Angle >> 8) & 0xff);
            Data[5] = ETX;

            SendMessageToServer(Data);
            TimeoutCount[nServo-1] = 5; // 5s
        }


        /// <summary>
        /// Set rc servo steps interval in ms
        /// </summary>
        /// <param name="IntervalMs"></param>
        private void SetServoStepIntervalms(int IntervalMs)
        {
            byte[] Data = new byte[6];
            Data[0] = STX;
            Data[1] = TYPE_SERVO;
            Data[2] = CMD_SV_ASTEP_INTERVAL_MS;
            Data[3] = Convert.ToByte(IntervalMs & 0xff);
            Data[4] = Convert.ToByte(IntervalMs >> 8);
            Data[5] = ETX;
            SendMessageToServer(Data);
        }


        /// <summary>
        /// Set rc servos step resolution
        /// </summary>
        /// <param name="nStepDuty"></param>
        private void SetServoStepResolution(int nStepDuty)
        {
            byte[] Data = new byte[6];
            Data[0] = STX;
            Data[1] = TYPE_SERVO;
            Data[2] = CMD_SV_ASTEP_RES;
            Data[3] = Convert.ToByte(nStepDuty & 0xff);
            Data[4] = Convert.ToByte(nStepDuty >> 8);
            Data[5] = ETX;
            SendMessageToServer(Data);
        }


        /// <summary>
        /// Set Wheels movement direction
        /// </summary>
        /// <param name="Direction"></param>
        private void MotorMovement(int Direction)
        {
            byte[] Data = new byte[6];
            Data[0] = STX;
            Data[1] = TYPE_WHEEL;
            Data[2] = Convert.ToByte(Direction & 0xff);
            Data[3] = 0;
            Data[4] = 0;
            Data[5] = ETX;
            SendMessageToServer(Data);
        }


        /// <summary>
        /// Set wheeels PWM duty cycle in % x100. 1000 = 10%
        /// </summary>
        /// <param name="nDuty"></param>
        private void MotorWheelDuty(int nDuty)
        {
            byte[] Data = new byte[6];
            Data[0] = STX;
            Data[1] = TYPE_WHEEL;
            Data[2] = CMD_WHEEL_LEFT_DUTY;
            Data[3] = Convert.ToByte(nDuty & 0xff);
            Data[4] = Convert.ToByte((nDuty >> 8) & 0xff);
            Data[5] = ETX;
            byte[] Data2 = new byte[6];
            Data2[0] = STX;
            Data2[1] = TYPE_WHEEL;
            Data2[2] = CMD_WHEEL_RIGHT_DUTY;
            Data2[3] = Convert.ToByte((1000+nDuty) & 0xff);
            Data2[4] = Convert.ToByte(((1000+nDuty) >> 8) & 0xff);
            Data2[5] = ETX;
            SendMessageToServer(Data);
            SendMessageToServer(Data2);
        }


        /// <summary>
        /// Send data to TCP server. Data out.
        /// </summary>
        /// <param name="byData"></param>
        internal void SendMessageToServer(byte[] byData)
        {
            //TimeSpan ts = client.LastDataFromServer

            if (null == client)
            {
                MessageBox.Show("Failed.TCP Server disconnected.");
                return;
            }

            // TCP link might be weak, we implement 5 retries if sending failed
            bool evt;
            int retry = 5;
            while(true)
            {
                if (false == client.Connected)
                {
                    // If TCP client not established, exit the loop
                    break;
                }

                if (false == client.SendMessage(byData))
                {
                    MessageBox.Show(
                        "TCP link error. Please reconnect",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    // If TCP broken during transmission, exit the loop
                    break;
                }
              
                // Sent. Wait for Robot Ack with 500ms timeout
                evt = evtAcknowledge.WaitOne(500);
                if (false == evt)
                {
                    Debug.WriteLine("ACK timeout count: " + retry.ToString());
                    if (0 != retry)
                    {
                        retry--;
                        if (0 == retry)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    // Everything sent successfully. exit the loop
                    break;
                }
            }
        }


        /// <summary>
        /// Enable or disable ARM movement
        /// </summary>
        /// <param name="bEn"></param>
        void SetARMEnable(bool bEn)
        {
            byte cmd;

            if (true == bEn)
            {
                cmd = CMD_ARM_ENABLE;
            }
            else
            {
                cmd = CMD_ARM_DISABLE;
            }


            byte[] Data = new byte[6];
            Data[0] = STX;
            Data[1] = TYPE_SERVO;
            Data[2] = cmd;
            Data[3] = 0;
            Data[4] = 0;
            Data[5] = ETX;
            SendMessageToServer(Data);
        }


        /// <summary>
        /// Open Camera and Serial net
        /// </summary>
        /// <returns></returns>
        private bool OpenCameraAndTCP()
        {
            bool res = false;
            MJPEGStream mjpegSource = new MJPEGStream();

            // We also can input this link direct to web browser to stream the video
            mjpegSource.VideoSource = "http://192.168.1.1:8080/?action=stream";

            // Create a TCP link used by the Router Serial
            if (true == ConnectToHostServer())
            {
                // successful to connect to TCP router

                // Start the Camera stream
                camera = new Camera(mjpegSource, detector);
                camera.Start();

                // Assign the frame to Camera window to display
                cameraWindow.Camera = camera;

                // Ready to enable all features
                btnEnARM.Enabled = true;
                tabControl.Enabled = true;
                ServoStatus1.Visible = true;
                ServoStatus2.Visible = true;
                ServoStatus3.Visible = true;
                ServoStatus4.Visible = true;
                ServoStatus5.Visible = true;
                ServoStatus6.Visible = true;
                ServoStatus7.Visible = true;
                ServoStatus8.Visible = true;

                btnConnect.Text = "Disconnect";

                // Update Status bar
                Invoke(new UPDATE_TS_STATUS(UpdateTsStatus), "Connected. Vehicle is ready");

                // Kick on system timer
                SystemTimer.Enabled = true;

                res = true;
            }
            else
            {
                MessageBox.Show("Connection failed.\r\n" +
                    "Ensure PC WiFi is linked to your vehicle base on your team name\r\n" +
                    "e.g.SSID:ECE225_ROBOT_XX",
                 "Error",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
            }

            return res;
        }
        #endregion


        #region Delegate Invoke functions
        // Delegate Invoke function
        public delegate void UPDATE_TS_STATUS(string str);
        public delegate void UPDATE_OPTICAL_DIS(string str);
        public delegate void UPDATE_ENC1_CPS(string str);
        public delegate void UPDATE_ENC2_CPS(string str);

        public delegate void UPDATE_SERVO_STATUS( int Idx, int Value );
        public delegate void UPDATE_WHEEL_MOVEMENT(int nDutyCycPercent, byte Direction);
        public delegate void UPDATE_WIFI_SIGNAL(string SSID, string Strength);
        public delegate void UPDATE_SERVO_COMPLETE( int nSv );
        public delegate void UPDATE_DEG_VALUE(string val);
        public delegate void UPDATE_RAD_VALUE(string val);



        private void UpdateServoComplete( int nSv )
        {
            switch(nSv)
            {
                case 0:
                    break;
                case 1:
                    ServoStatus1.Image = Properties.Resources.ServoReady;
                    break;
                case 2:
                    ServoStatus2.Image = Properties.Resources.ServoReady;
                    break;
                case 3:
                    ServoStatus3.Image = Properties.Resources.ServoReady;
                    break;
                case 4:
                    ServoStatus4.Image = Properties.Resources.ServoReady;
                    break;
                case 5:
                    ServoStatus5.Image = Properties.Resources.ServoReady;
                    break;
                case 6:
                    ServoStatus6.Image = Properties.Resources.ServoReady;
                    break;
                case 7:
                    ServoStatus7.Image = Properties.Resources.ServoReady;
                    break;
                case 8:
                    ServoStatus8.Image = Properties.Resources.ServoReady;
                    break;
            }
        }

        private void UpdateWifiStatus(string SSID, string Strength)
        {
            tslabelWifi.Text = SSID + "," + Strength;
            int i = Strength.IndexOf("%");
            string digit = Strength.Remove(i);
            wifiSignal.Value = Convert.ToInt32(digit) / 10;
        }

        private void UpdateWheelMovement(int nDutyCycPercent, byte Direction)
        {
            double duty;
            if (Direction == CMD_WHEEL_STOP)
            {
                duty = 0;
            }
            else
            {
                duty = Convert.ToDouble(nDutyCycPercent) / 100.0;
            }
           
            labelDuty.Text = duty.ToString() + "%";
        }

        private void UpdateTsStatus(string str)
        {
            tslabelStatus.Text = str;
        }

        private void UpdateOpticalDist(string str)
        {
            labelDist.Text = str;
        }

        private double UpdateRADValue(double val)
        {
            return (val * ((Math.PI)) / 180);
        }

        private double UpdateDegValue(double val)
        {
            return (val * (180 / (Math.PI)));
        }

        private void UpdateServoStatus(int Idx, int Value)
        {
            float angle;
            
            switch (Idx )
            {
                case 0:
                    break;
                case 1:
                    angle = Convert.ToSingle(Value) / 100.0f;
                    labelServo1.Text = "Lower ARM: " + angle.ToString() + "°";
                    tbarServo1.Value = Value;
                    ServoStatus1.Image = Properties.Resources.ServoBusy;
                    break;
                case 2:
                    angle = Convert.ToSingle(Value) / 100.0f;
                    labelServo2.Text = "Upper ARM: " + angle.ToString() + "°";
                    tbarServo2.Value = Value;
                    ServoStatus2.Image = Properties.Resources.ServoBusy;
                    break;
                case 3:
                     angle = Convert.ToSingle(Value) / 100.0f;
                    labelServo3.Text = "Rotate Gripper: " + angle.ToString() + "°";
                    tbarServo3.Value = Value;
                    ServoStatus3.Image = Properties.Resources.ServoBusy;
                    break;
                case 4:
                    angle = Convert.ToSingle(Value) / 100.0f;
                    labelServo4.Text = "Gripper: " + angle.ToString() + "°";
                    tbarServo4.Value = Value;
                    ServoStatus4.Image = Properties.Resources.ServoBusy;
                    break;
                case 5:
                    angle = Convert.ToSingle(Value) / 100.0f;
                    labelServo5.Text = "Unuse: " + angle.ToString() + "°";
                    tbarServo5.Value = Value;
                    ServoStatus5.Image = Properties.Resources.ServoBusy;
                    break;
                case 6:
                    angle = Convert.ToSingle(Value) / 100.0f;
                    labelServo6.Text = "Unuse: " + angle.ToString() + "°";
                    tbarServo6.Value = Value;
                    ServoStatus6.Image = Properties.Resources.ServoBusy;
                    break;
                case 7:
                    angle = Convert.ToSingle(Value) / 100.0f;
                    labelServo7.Text = "Pan: " + angle.ToString() + "°";
                    tbarServo7.Value = Value;
                    ServoStatus7.Image = Properties.Resources.ServoBusy;
                    break;
                case 8:
                    angle = Convert.ToSingle(Value) / 100.0f;
                    labelServo8.Text = "Tilt: " + angle.ToString() + "°";
                    tbarServo8.Value = Value;
                    ServoStatus8.Image = Properties.Resources.ServoBusy;
                    break;
                default:
                    break;
            }
        }

        #endregion


        #region Callbacks from the TCPIP client layer
        /// <summary>
        /// Data coming in from the TCPIP server
        /// </summary>
        private void OnDataReceive(byte[] message, int messageSize)
        {
            for(int i=0; i<messageSize; i++)
            {
                TcpReceivedQueue.Enqueue(message[i]);
            }

            evtTcpReceived.Set();
        }

        /// <summary>
        /// Server disconnected
        /// </summary>
        private void OnDisconnect()
        {
            Debug.Write("Server disconnected\r\n");
        }
        #endregion


        #region Threading Task

        private void TcpThreadRun()
        {
            string strbuf = null;
            bool bstart = false;
            byte c;

            while (true)
            {
                bool evt = evtTcpReceived.WaitOne( 2000 );
                if(false == evt)
                {
                    strbuf = null;
                    bstart = false;
                    continue;
                }

                while( true == TcpReceivedQueue.TryDequeue( out c ) )
                {
                    if (false == bstart)
                    {
                        if ('@' == c)
                        {
                            bstart = true;
                        }

                        continue;
                    }

                    if ('#' == c)
                    {
                        bstart = false;

                        switch (strbuf[0])
                        {
                            case 'A':
                                Debug.Write(strbuf + "\r\n");
                                evtAcknowledge.Set();
                                break;

                            case 'C':
                                Debug.Write(strbuf + "\r\n");
                                string s = strbuf.Substring(1);
                                int sv = Convert.ToInt32(s);
                                switch (sv)
                                {
                                    case 1:
                                        Debug.Write("Servo1 ready\r\n");
                                        evtServoHandles[EVT_COMP_SERVO1].Set();
                                        break;
                                    case 2:
                                        Debug.Write("Servo2 ready\r\n");
                                        evtServoHandles[EVT_COMP_SERVO2].Set();
                                        break;
                                    case 3:
                                        Debug.Write("Servo3 ready\r\n");
                                        evtServoHandles[EVT_COMP_SERVO3].Set();
                                        break;
                                    case 4:
                                        Debug.Write("Servo4 ready\r\n");
                                        evtServoHandles[EVT_COMP_SERVO4].Set();
                                        break;
                                    case 5:
                                        Debug.Write("Servo5 ready\r\n");
                                        evtServoHandles[EVT_COMP_SERVO5].Set();
                                        break;
                                    case 6:
                                        Debug.Write("Servo6 ready\r\n");
                                        evtServoHandles[EVT_COMP_SERVO6].Set();
                                        break;
                                    case 7:
                                        Debug.Write("Servo7 ready\r\n");
                                        evtServoHandles[EVT_COMP_SERVO7].Set();
                                        break;
                                    case 8:
                                        Debug.Write("Servo8 ready\r\n");
                                        evtServoHandles[EVT_COMP_SERVO8].Set();
                                        break;

                                    default:
                                        break;
                                }

                                TimeoutCount[sv-1] = 0;
                                Invoke(new UPDATE_SERVO_COMPLETE(UpdateServoComplete), sv);
                                break;

                            case 'D':
                                distmm = Convert.ToInt32(strbuf.Substring(1))+20;
                                s = strbuf.Substring(1) + "mm";
                                Invoke(new UPDATE_OPTICAL_DIS(UpdateOpticalDist), s);
                                break;

                            case 'E':
                                ENC1 = Convert.ToInt32(strbuf.Substring(1));
                                s = strbuf.Substring(1) + "CPS";
                                
                                break;

                            case 'F':
                                ENC2 = Convert.ToInt32(strbuf.Substring(1));
                                s = strbuf.Substring(1) + "CPS";

                                
                                break;

                            default:
                                break;
                        }
                        strbuf = null;
                    }
                    else
                    {
                        byte[] tmp = new byte[2];
                        tmp[0] = c;
                        tmp[1] = 0;
                        strbuf += System.Text.Encoding.UTF8.GetString(tmp, 0, 1);
                    }
                }
            }
        }

        /// <summary>
        /// This is a thread to manage robot arm Movement, wheel movement when certain buttons are triggered by
        /// setting an event
        /// It also update WiFi signal strength.
        /// </summary>
        private void CtrlThreadRun()
        {
            while (true)
            {
                int index = WaitHandle.WaitAny(evtHandles);

                switch (index)
                {
                    case EVT_CTRL_INITIAL_POS:
                        ArmDefaultPosition();
                        break;

                    case EVT_CTRL_PARKING_POS:
                        ArmParkingPosition();
                        break;

                    case EVT_CTRL_WHEEL_MOVE:
                        WheelMoveToDirection();
                        break;

                    case EVT_CTRL_SERVO_MOVE_1:
                        Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 1, CurrentAngle[0]);
                        SetServoAngle(1, CurrentAngle[0]);
                         break;

                    case EVT_CTRL_SERVO_MOVE_2:
                        Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 2, CurrentAngle[1]);
                        SetServoAngle(2, CurrentAngle[1]);
                        break;

                    case EVT_CTRL_SERVO_MOVE_3:
                        Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 3, CurrentAngle[2]);
                        SetServoAngle(3, CurrentAngle[2]);
                        break;

                    case EVT_CTRL_SERVO_MOVE_4:
                        Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 4, CurrentAngle[3]);
                        SetServoAngle(4, CurrentAngle[3]);
                        break;

                    case EVT_CTRL_SERVO_MOVE_5:
                        Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 5, CurrentAngle[4]);
                        SetServoAngle(5, CurrentAngle[4]);
                        break;

                    case EVT_CTRL_SERVO_MOVE_6:
                        Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 6, CurrentAngle[5]);
                        SetServoAngle(6, CurrentAngle[5]);
                        break;

                    case EVT_CTRL_SERVO_MOVE_7:
                        Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 7, CurrentAngle[6]);
                        SetServoAngle(7, CurrentAngle[6]);
                        break;

                    case EVT_CTRL_SERVO_MOVE_8:
                        Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 8, CurrentAngle[7]);
                        SetServoAngle(8, CurrentAngle[7]);
                        break;


                    case EVT_CTRL_DRAW_LINE:
                        for (int i = 1; i <= 2; i++)
                        {
                            Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), i, CurrentAngle[i - 1]);
                            SetServoAngle(i, CurrentAngle[i - 1]);
                        }
                        break;

                    case EVT_CTRL_SYS_SHUTWON:
                        HandleSystemShutdown();
                        break;

                    case EVT_CTRL_PICK_PLACE_START:
                        HandlePickPlaceStart();
                        break;

                    case EVT_CTRL_PICK_PLACE_MOVE:
                        HandlePickPlaceMove();
                        break;

                    case EVT_CTRL_PICK_PLACE_DONE:
                        HandlePickPlaceDone();
                        break;

                    case EVT_CTRL_MV_SQ_START:
                        Thread.Sleep(100);
                        CurrentMoveDirection = CMD_WHEEL_STOP;
                        WheelMoveToDirection();
                        Thread.Sleep(100);
                        break;
                }
            }
        }

        private void HandleSystemShutdown()
        {
            MotorMovement(CMD_WHEEL_STOP);
            ArmParkingPosition();
            camera.Stop();
            SetARMEnable(false);
            client.Disconnect();
            SystemTimer.Stop();
            Invoke(new UPDATE_TS_STATUS(UpdateTsStatus), "Click Connect to Start...");
            Invoke(new UPDATE_WIFI_SIGNAL(UpdateWifiStatus), "SSID: ---", "0%");
            CtrlThreadHandle.Abort();
        }

        private void HandlePickPlaceStart()
        {
            if ((distmm <= Lbound) || (distmm > Ubound))
            {
                CurrentMoveDirection = (distmm <= Lbound) ? CMD_WHEEL_BWD : CMD_WHEEL_FWD;
                WheelMoveToDirection();
                evtHandles[EVT_CTRL_PICK_PLACE_MOVE].Set();
            }
            else
            {
                evtHandles[EVT_CTRL_PICK_PLACE_DONE].Set();
            }
        }

        private void HandlePickPlaceMove()
        {
            Thread.Sleep(100);
            CurrentMoveDirection = CMD_WHEEL_STOP;
            WheelMoveToDirection();
            Thread.Sleep(100);

            if (distmm >= Lbound && distmm < Ubound)
            {
                CurrentMoveDirection = CMD_WHEEL_STOP;
                WheelMoveToDirection();
                evtHandles[EVT_CTRL_PICK_PLACE_DONE].Set();
            }
            else
            {
                evtHandles[EVT_CTRL_PICK_PLACE_START].Set();
            }
        }

        private void HandlePickPlaceDone()
        {
            ArmPosition(6000, 9000, 7000); //open position
            Thread.Sleep(6000);
            ArmPosition(6000, 9000, 2000); //closed
            Thread.Sleep(6000);
            ArmDefaultPosition(); //default
            Thread.Sleep(6000);
            ArmPosition(6000, 9000, 2000); //close
            Thread.Sleep(6000);
            ArmPosition(6000, 9000, 7000); //open   
            Thread.Sleep(6000);
            ArmDefaultPosition();  //default
        }
        #endregion



        #region Timers
        /// <summary>
        /// System Timer tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SystemTimer_Tick(object sender, EventArgs e)
        {
            string Name = null;
            string Strength = null;

            GetWiFiRSSI(ref Name, ref Strength);

            if(null != Name)
            {
                if ("0%" == Strength)
                {
                    Invoke(new UPDATE_TS_STATUS(UpdateTsStatus), "Disconnected. Vehicle is not ready");
                }

                Invoke(new UPDATE_WIFI_SIGNAL(UpdateWifiStatus), Name, Strength);
            }

            for(int i=0; i<TimeoutCount.Length; i++)
            {
                if (TimeoutCount[i] != 0)
                {
                    TimeoutCount[i]--;
                    if(0 == TimeoutCount[i])
                    {
                        evtHandles[EVT_CTRL_SERVO_MOVE_1 + i].Set();
                    }
                }
            }
        }
        #endregion


        #region Main Entry

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tabControl.Enabled = true;
            btnEnARM.Enabled = false;
            

            ServoStatus1.Visible = false;
            ServoStatus2.Visible = false;
            ServoStatus3.Visible = false;
            ServoStatus4.Visible = false;
            ServoStatus5.Visible = false;
            ServoStatus6.Visible = false;
            ServoStatus7.Visible = false;
            ServoStatus8.Visible = false;

            // reset all servo angles
            for (int i = 0; i < CurrentAngle.Length; i++)
            {
                CurrentAngle[i] = 0;
            }

            // reset all servos command execution timeout
            for (int i = 0; i < TimeoutCount.Length; i++)
            {
                TimeoutCount[i] = 0;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if ( "Disconnect" == btnConnect.Text )
            {
                //User intend to disconnect

                btnConnect.Text = "Connect";
                btnConnect.ForeColor = Color.Gray;
                tabControl.Enabled = false;
                btnArmHome.Enabled = false;
                btnArmParking.Enabled = false;
                btnEnARM.Text = "Enable ARM";
                btnEnARM.Enabled = false;
                SystemTimer.Start();
                evtHandles[EVT_CTRL_SYS_SHUTWON].Set();
            }
            else
            {
                // User intend to connect

                btnConnect.ForeColor = Color.Red;

                // Creates events for control thread
                for (int i = 0; i < evtHandles.Length; i++)
                {
                    evtHandles[i] = new AutoResetEvent(false);
                }

                // Creates events for RC servo control
                for (int i = 0; i < evtServoHandles.Length; i++)
                {
                    evtServoHandles[i] = new AutoResetEvent(false);
                }

                // All threads only will be created if user link to robot with TCP link created successfully
                if( true == OpenCameraAndTCP() )
                {
                    gboxWheel.Enabled = true;
                    // Camera and wifi link established properly

                    // Create Thread for control thread
                    CtrlThreadHandle = new Thread(new ThreadStart(CtrlThreadRun));
                    CtrlThreadHandle.IsBackground = false;
                    CtrlThreadHandle.Priority = ThreadPriority.Normal;
                    CtrlThreadHandle.Start();

                    //Create a thread to handle TCP data
                    TcpThreadHandle = new Thread(new ThreadStart(TcpThreadRun));
                    TcpThreadHandle.IsBackground = false;
                    TcpThreadHandle.Priority = ThreadPriority.Normal;
                    TcpThreadHandle.Start();
                }
            }
        }

        #endregion

        /// <summary>
        /// UI generated functions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbarServo1_ValueChanged(object sender, EventArgs e)
        {
            float angle = Convert.ToSingle(tbarServo1.Value) / 100.0f;

            tboxServo1.Text = angle.ToString();
        }

        private void tbarServo2_ValueChanged(object sender, EventArgs e)
        {
            float angle = Convert.ToSingle(tbarServo2.Value) / 100.0f;

            tboxServo2.Text = angle.ToString();
        }

        private void tbarServo3_ValueChanged(object sender, EventArgs e)
        {

            float angle = Convert.ToSingle(tbarServo3.Value) / 100.0f;

            tboxServo3.Text = angle.ToString();
        }

        private void tbarServo4_ValueChanged(object sender, EventArgs e)
        {
            float angle = Convert.ToSingle(tbarServo4.Value) / 100.0f;

            tboxServo4.Text = angle.ToString();
        }

        private void tbarServo5_ValueChanged(object sender, EventArgs e)
        {
            float angle = Convert.ToSingle(tbarServo5.Value) / 100.0f;
            tboxServo5.Text = angle.ToString();
        }

        private void tbarServo6_ValueChanged(object sender, EventArgs e)
        {
            float angle = Convert.ToSingle(tbarServo6.Value) / 100.0f;

            tboxServo6.Text = angle.ToString();
        }

        private void tbarServo7_ValueChanged(object sender, EventArgs e)
        {
            TriggerServo(7, tbarServo7.Value);
        }

        private void tbarServo8_ValueChanged(object sender, EventArgs e)
        {
            TriggerServo(8, tbarServo8.Value);
        }

        private void btnSnap_Click(object sender, EventArgs e)
        {
            if (true == File.Exists("Snap.bmp"))
            {
                DateTime now = DateTime.Now;
                long time = now.ToFileTime();

                string oldPath = "Snap_" + time.ToString() + ".bmp";
                File.Move("Snap.bmp", oldPath);
            }

            camera.LastFrame.Save("Snap.bmp");
        }

        private void btnFwd_Click(object sender, EventArgs e)
        {
            sum1 = 0;
            sum2 = 0;
            CurrentMoveDirection = CMD_WHEEL_FWD;
            flag = 1;
            evtHandles[EVT_CTRL_WHEEL_MOVE].Set();           // Set event to trigger Ctrl Thread set the wheel movement
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            CurrentMoveDirection = CMD_WHEEL_STOP;
            flag = 2;
            lblsum1.Text = sum1.ToString();
            lblsum2.Text = sum2.ToString();
            evtHandles[EVT_CTRL_WHEEL_MOVE].Set();           // Set event to trigger Ctrl Thread set the wheel movement
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            CurrentMoveDirection = CMD_WHEEL_LEFT;
            evtHandles[EVT_CTRL_WHEEL_MOVE].Set();           // Set event to trigger Ctrl Thread set the wheel movement
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            CurrentMoveDirection = CMD_WHEEL_RIGHT;
            evtHandles[EVT_CTRL_WHEEL_MOVE].Set();
        }

        private void btnBwd_Click(object sender, EventArgs e)
        {
            CurrentMoveDirection = CMD_WHEEL_BWD;
            evtHandles[EVT_CTRL_WHEEL_MOVE].Set();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "1. Your Computer WiFi shall connected to Vehicle before using this Application\r\n\r\n" +
                "2. Feel Free to email to: lianchai.gan@digipen.edu",
                "Help", 
                MessageBoxButtons.OK,
                MessageBoxIcon.Information );
        }

        private void btnEnARM_Click(object sender, EventArgs e)
        {
            if( "Enable ARM" == btnEnARM.Text )
            {
                MessageBox.Show( 
                    "Warning!\r\n" +
                    "Keep away from Robotic ARM working area.\r\n" +
                    "Click OK to proceed.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning );

                btnEnARM.Text = "Disable ARM";
                btnArmHome.Enabled = true;
                btnArmParking.Enabled = true;
                SetARMEnable(true);
                bArmEnable = true;
                evtHandles[EVT_CTRL_INITIAL_POS].Set();
            }
            else
            {
                btnEnARM.Text = "Enable ARM";
                btnArmHome.Enabled = false;
                btnArmParking.Enabled = false;
                SetARMEnable(false);
                bArmEnable = false;
            }
        }

        private void btnSetServo1_Click(object sender, EventArgs e)
        {
            float v = float.Parse(tboxServo1.Text);
            int angle = Convert.ToInt32(v*100.0f);

            TriggerServo( 1, angle );
        }

        private void btnSetServo2_Click(object sender, EventArgs e)
        {
            float v = float.Parse(tboxServo2.Text);
            int angle = Convert.ToInt32(v * 100.0f);

            TriggerServo(2, angle);
        }

        private void btnSetServo3_Click(object sender, EventArgs e)
        {
            float v = float.Parse(tboxServo3.Text);
            int angle = Convert.ToInt32(v * 100.0f);

            TriggerServo(3, angle);
        }

        private void btnSetServo4_Click(object sender, EventArgs e)
        {
            float v = float.Parse(tboxServo4.Text);
            int angle = Convert.ToInt32(v * 100.0f);

            TriggerServo(4, angle);
        }

        private void btnSetServo5_Click(object sender, EventArgs e)
        {
            float v = float.Parse(tboxServo5.Text);
            int angle = Convert.ToInt32(v * 100.0f);

            TriggerServo(5, angle);
        }

        private void btnSetServo6_Click(object sender, EventArgs e)
        {
            float v = float.Parse(tboxServo6.Text);
            int angle = Convert.ToInt32(v * 100.0f);

            TriggerServo(6, angle);
        }

        private void btnArmHome_Click(object sender, EventArgs e)
        {
            evtHandles[EVT_CTRL_INITIAL_POS].Set();
        }

        private void btnArmParking_Click(object sender, EventArgs e)
        {
            evtHandles[EVT_CTRL_PARKING_POS].Set();
        }

        private bool drawLine(double x, double y, double x2, double y2)
        {
            double targetX = x2;
            double targetY = y2;

            double numSegments = 20;
            double currentX = x;
            double currentY = y;

            double deltaX = (targetX - x) / numSegments;
            double deltaY = (targetY - y) / numSegments;

            Tuple<double, double> finalAngles = CalculateAngles(targetX, targetY);
            double finalAngle1 = finalAngles.Item1;
            double finalAngle2 = finalAngles.Item2;

            int segmentCounter = 0;

            while (segmentCounter <= numSegments)
            {
                Tuple<double, double> currentAngles = CalculateAngles(currentX, currentY);

                int servo1Angle = Convert.ToInt32(currentAngles.Item1 * 100.0f);
                int servo2Angle = Convert.ToInt32(currentAngles.Item2 * 100.0f);

                CurrentAngle[0] = servo1Angle; // Angle multiplied by 100
                CurrentAngle[1] = servo2Angle; // Angle multiplied by 100

                // Update servo angles
                Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 1, CurrentAngle[0]);
                Invoke(new UPDATE_SERVO_STATUS(UpdateServoStatus), 2, CurrentAngle[1]);

                SetServoAngle(1, CurrentAngle[0]);
                SetServoAngle(2, CurrentAngle[1]);

                currentX += deltaX;
                currentY += deltaY;
                segmentCounter++;

                if (finalAngle1 >= currentAngles.Item1 || finalAngle2 >= currentAngles.Item2)
                {
                    break;
                }
            }

            return true;
        }

        private void cboxCannyDetect_CheckedChanged(object sender, EventArgs e)
        {
            cameraWindow.CannyDetectionSet(cboxCannyDetect.Checked);
        }

        private void cboxSobelDetect_CheckedChanged(object sender, EventArgs e)
        {
            cameraWindow.SobelDetectionSet(cboxSobelDetect.Checked);
        }

        private void btnRstFKine_Click(object sender, EventArgs e)
        {
            tbTeta1.Text = "";
            tbTeta2.Text = "";
            tbTeta3.Text = "";
            tbR11.Text = "";
            tbR12.Text = "";
            tbR13.Text = "";
            tbR21.Text = "";
            tbR22.Text = "";
            tbR23.Text = "";
            tbR31.Text = "";
            tbR32.Text = "";
            tbR33.Text = "";
            tbPx.Text = "";
            tbPy.Text = "";
            tbPz.Text = "";
            tbE0.Text = "";
            tbE1.Text = "";
            tbE2.Text = "";
            tbE3.Text = "";
            tbYaw.Text = "";
            tbPitch.Text = "";
            tbRoll.Text = "";
            q1 = 0;
            q2 = 0;
            q3 = 0;
            //Move to default starting angle
            evtHandles[EVT_CTRL_INITIAL_POS].Set();
        }

        private void btnRunIKine_Click(object sender, EventArgs e)
        {
            double Link1 = 95;
            double Link2 = 28;
            double Link3 = 155;

            double px1 = Convert.ToDouble(tbPxInv.Text);
            double py1 = Convert.ToDouble(tbPyInv.Text);

            double a = (2 * Link3 * Link1);
            double b = (2 * Link2 * Link1);
            double c = Math.Pow(px1, 2) + Math.Pow(py1, 2) - Math.Pow(Link3, 2) - Math.Pow(Link2, 2) - Math.Pow(Link1, 2);

            double xx = Math.Atan2(b, a);
            double yy = Math.Atan2(Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)), c);
            double sq = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2));
            double theta2_1 = Math.Atan2(b, a) + Math.Atan2(Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)), c);
            double theta2_2 = Math.Atan2(b, a) + Math.Atan2(-Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)), c);

            double a_1 = (Link3 * Math.Cos(theta2_1)) + (Link2 * Math.Sin(theta2_1) + Link1);
            double b_1 = (Link3 * Math.Sin(theta2_1)) - (Link2 * Math.Cos(theta2_1));
            double c_1 = px1;
            double d_1 = py1;
            double theta1_1 = Math.Atan2(((a_1 * d_1) - (b_1 * c_1)), ((a_1 * c_1) + (b_1 * d_1)));

            double a_2 = (Link3 * Math.Cos(theta2_2)) + (Link2 * Math.Sin(theta2_2) + Link1);
            double b_2 = (Link3 * Math.Sin(theta2_2)) - (Link2 * Math.Cos(theta2_2));
            double c_2 = px1;
            double d_2 = py1;
            double theta1_2 = Math.Atan2(((a_2 * d_2) - (b_2 * c_2)), ((a_2 * c_2) + (b_2 * d_2)));

            double t1_1 = ((theta1_1 * (180 / Math.PI)));
            double t2_1 = ((theta2_1 * (180 / Math.PI)));

            double t1_2 = ((theta1_2 * (180 / Math.PI)));
            double t2_2 = ((theta2_2 * (180 / Math.PI)));

            tbTeta1Inv.Text = t1_1.ToString();
            tbTeta2Inv.Text = t2_1.ToString();
            tbTeta3Inv.Text = 0.ToString();

            int angle1 = Convert.ToInt32(t1_1 * 100.0f);
            TriggerServo(1, angle1);

            int angle2 = Convert.ToInt32(t2_1 * 100.0f);
            TriggerServo(2, angle2);
          
        }

        private void btnRstIKine_Click(object sender, EventArgs e)
        {
            tbPxInv.Text = "";
            tbPyInv.Text = "";
            tbPzInv.Text = "";
            tbTeta1Inv.Text = "";
            tbTeta2Inv.Text = "";
            tbTeta3Inv.Text = "";
            //Move to default starting angle
            evtHandles[EVT_CTRL_INITIAL_POS].Set();
        }

        

        private void btnRunLine_Click(object sender, EventArgs e)
        {
            double tmepx1 = Convert.ToDouble(tbPx11.Text);
            double tmepy1 = Convert.ToDouble(tbPy11.Text);

            double tmepx3 = Convert.ToDouble(tbPx13.Text);
            double tmepy3 = Convert.ToDouble(tbPy13.Text);

            double tmepx2 = midpoint(tmepx1, tmepx3);
            double tmepy2 = midpoint(tmepy1, tmepy3);

            tbPx12.Text = tmepx2.ToString();
            tbPy12.Text = tmepy2.ToString();

            bool res = drawLine(tmepx1, tmepy1, tmepx3, tmepy3);
            if (res == true)
            {
                labelLineSts.Visible = true;
            }
            else
            {
                labelLineSts.Visible = false;
            }
        }

        private void btnRstLine_Click(object sender, EventArgs e)
        {
            labelLineSts.Visible = false;
            tbPx11.Text = "";
            tbPx12.Text = "";
            tbPx13.Text = "";
            tbPy11.Text = "";
            tbPy12.Text = "";
            tbPy13.Text = "";
            //Move to default starting angle
            evtHandles[EVT_CTRL_INITIAL_POS].Set();
        }

        private void gbLine_Enter(object sender, EventArgs e)
        {

        }

        private void tbR11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            CurrentMoveDirection = CMD_WHEEL_FWD;
            evtHandles[EVT_CTRL_WHEEL_MOVE].Set();           // Set event to trigger Ctrl Thread set the wheel movement

            Thread.Sleep(5000);

            CurrentMoveDirection = CMD_WHEEL_STOP;
            evtHandles[EVT_CTRL_WHEEL_MOVE].Set();

        }

        private void btnRunPickPlace_Click(object sender, EventArgs e)
        {
            labelFuncSts.Visible = true;
            labelFuncSts.Text = "Initiated...";
            evtHandles[EVT_CTRL_PICK_PLACE_START].Set();
        }

        private void btnRunSquare_Click(object sender, EventArgs e)
        {
            double angle1 = -16.59145;
            double angle2 = 123.92206;

            TriggerServoAndWait(angle1, angle2, 2000, "Drawing...1");

            bool res = DrawAndSleepLine(75, 125, 75, 195, "Drawing...2");
            if (res)
            {
                res = DrawAndSleepLine(75, 195, 145, 195, "Drawing...3");
                if (res)
                {
                    res = DrawAndSleepLine(145, 195, 145, 125, "Drawing...4");
                    if (res)
                    {
                        DrawAndSleepLine(145, 125, 75, 125, "Done");
                    }
                }
            }
        }

        void TriggerServoAndWait(double angle1, double angle2, int sleepTime, string status)
        {
            int servoAngle1 = Convert.ToInt32(angle1 * 100.0f);
            TriggerServo(1, servoAngle1);

            int servoAngle2 = Convert.ToInt32(angle2 * 100.0f);
            TriggerServo(2, servoAngle2);

            Thread.Sleep(sleepTime);
            UpdateStatusLabel(status);
        }

        bool DrawAndSleepLine(int x1, int y1, int x2, int y2, string status)
        {
            bool result = drawLine(x1, y1, x2, y2);
            if (result)
            {
                Thread.Sleep(1000);
                UpdateStatusLabel(status);
            }
            return result;
        }

        void UpdateStatusLabel(string status)
        {
            labelFuncSts.Visible = true;
            labelFuncSts.Text = status;
        }



        private void btnRstFunc_Click(object sender, EventArgs e)
        {
            //Move to default starting angle
            evtHandles[EVT_CTRL_INITIAL_POS].Set();
            labelFuncSts.Visible = false;
            CurrentMoveDirection = CMD_WHEEL_STOP; // update wheel direction
            WheelMoveToDirection();
        }

        private void cboxObjectDetect_CheckedChanged(object sender, EventArgs e)
        {
            cameraWindow.ObjectDetectionSet( cboxObjectDetect.Checked );
        }

        private double midpoint(double a, double b)
        {
            double mp = ((b+a)/ 2);
            return mp;
        }

        private Tuple <double , double> CalculateAngles(double _px, double _py) {

            double a = (2 * Link3 * Link1);
            double b = (2 * Link2 * Link1);
            double c = Math.Pow(_px, 2) + Math.Pow(_py, 2) - Math.Pow(Link3, 2) - Math.Pow(Link2, 2) - Math.Pow(Link1, 2);

            double theta2_1 = Math.Atan2(b, a) + Math.Atan2(Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)), c);
            double theta2_2 = Math.Atan2(b, a) + Math.Atan2(-Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)), c);

            double a_1 = (Link3 * Math.Cos(theta2_1)) + (Link2 * Math.Sin(theta2_1) + Link1);
            double b_1 = (Link3 * Math.Sin(theta2_1)) - (Link2 * Math.Cos(theta2_1));
            double c_1 = _px;
            double d_1 = _py;
            double theta1_1 = Math.Atan2(((a_1 * d_1) - (b_1 * c_1)), ((a_1 * c_1) + (b_1 * d_1)));

            double a_2 = (Link3 * Math.Cos(theta2_2)) + (Link2 * Math.Sin(theta2_2) + Link1);
            double b_2 = (Link3 * Math.Sin(theta2_2)) - (Link2 * Math.Cos(theta2_2));
            double c_2 = _px;
            double d_2 = _py;
            double theta1_2 = Math.Atan2(((a_2 * d_2) - (b_2 * c_2)), ((a_2 * c_2) + (b_2 * d_2)));


            double t1_1 = ((theta1_1 * (180 / Math.PI)) );
            double t2_1 = ((theta2_1 * (180 / Math.PI)) );

            double t1_2 = ((theta1_2 * (180 / Math.PI)));
            double t2_2 = ((theta2_2 * (180 / Math.PI)));


            Tuple<double, double> data = new Tuple<double,double>(t1_1, t2_1);

            return data;
        }

        private void cboxColorTrack_CheckedChanged(object sender, EventArgs e)
        {
            cameraWindow.ColorDetectionSet(cboxColorTrack.Checked);
        }

        private void cboxShapeDetect_CheckedChanged(object sender, EventArgs e)
        {
            cameraWindow.SHapeDetectionSet(cboxShapeDetect.Checked);
        }

        private void btnSetDuty_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(tboxDuty.Text);
            int duty = Convert.ToInt32(a * 100);

            if(duty >= 9900)
            {
                MessageBox.Show("Error! Duty Cycle too high.");
                return;
            }

            if (duty <= 1)
            {
                MessageBox.Show("Error! Duty Cycle too low.");
                return;
            }

            WheelPWMDutyCycle = duty;
            MessageBox.Show("Duty Cycle Set to: " + tboxDuty.Text.ToString() + "%. It will take effect at next movement change");          
        }

        private void setquatval()
        {
            r11 = (float) ((-Math.Sin(q1 + q2) * Math.Sin(q3)));
            r12 = (float) (-Math.Sin(q1 + q2) * Math.Cos(q3));
            r13 = (float) (Math.Cos(q1 + q2));
            r21 = (float) (Math.Cos(q1 + q2) * Math.Sin(q3));
            r22 = (float) (Math.Cos(q1 + q2) * Math.Cos(q3));
            r23 = (float) (Math.Sin(q1 + q2));
            r31 = (float) (-Math.Cos(q3));
            r32 = (float) (Math.Sin(q3));
            r33 = 0;
        }

        private void btnRunFKine_Click(object sender, EventArgs e)
        {
            //reset global values
            q1 = 0;
            q2 = 0;
            q3 = 0;

            if (String.IsNullOrEmpty(tbTeta1.Text) || String.IsNullOrEmpty(tbTeta2.Text) || String.IsNullOrEmpty(tbTeta3.Text))
            {
                MessageBox.Show("Please Key in all Theta Values!");
                tbTeta1.Text = "";
                tbTeta2.Text = "";
                tbTeta3.Text = "";
            }
            else {
                // Convert angle from textbox to radians' local variable
                q1 = UpdateRADValue(Convert.ToDouble(tbTeta1.Text)); 
                q2 = UpdateRADValue(Convert.ToDouble(tbTeta2.Text)); 
                q3 = UpdateRADValue(Convert.ToDouble(tbTeta3.Text));

                // Convert angle from textbox to number
                double  q1_deg = Convert.ToDouble(tbTeta1.Text);
                double  q2_deg = Convert.ToDouble(tbTeta2.Text);
                double  q3_deg = Convert.ToDouble(tbTeta3.Text);

                //Set values for R matrix textboxes
                tbR11.Text = (-Math.Sin(q1 + q2) * Math.Sin(q3)).ToString("0.0000");
                tbR12.Text = (-Math.Sin(q1 + q2) * Math.Cos(q3)).ToString("0.0000");
                tbR13.Text = (Math.Cos(q1 + q2)).ToString("0.0000");
                tbR21.Text = (Math.Cos(q1 + q2) * Math.Sin(q3)).ToString("0.0000");
                tbR22.Text = (Math.Cos(q1 + q2) * Math.Cos(q3)).ToString("0.0000");
                tbR23.Text = (Math.Sin(q1 + q2)).ToString("0.0000");
                tbR31.Text = (-Math.Cos(q3)).ToString("0.0000");
                tbR32.Text = (Math.Sin(q3)).ToString("0.0000");
                tbR33.Text = 0.ToString("0.0000");

                //Set values for XYZ position textboxes
                tbPx.Text = ((Link2 * Math.Sin(q1 + q2)) + (Link3 * Math.Cos(q1 + q2)) + (Link1 * Math.Cos(q1))).ToString("0.000");
                tbPy.Text = ((Link3 * Math.Sin(q1 + q2)) - (Link2 * Math.Cos(q1 + q2)) + (Link1 * Math.Sin(q1))).ToString("0.000");
                tbPz.Text = 0.ToString("0.000");

                //Store R matrix values in local variables
                setquatval();

                //Update Quaternion values
                e0 = (float)((Math.Sqrt((Math.Pow(r11 + r22 + r33 + 1, 2)) + (Math.Pow(r32 - r23, 2)) + (Math.Pow(r13 - r31, 2)) + (Math.Pow(r21 - r12, 2)))) / 4);
                e1 = (float)((Math.Sqrt((Math.Pow(r32 - r23, 2)) + (Math.Pow(r11 - r22 - r33 + 1, 2)) + (Math.Pow(r21 + r12, 2)) + (Math.Pow(r31 + r13, 2)))) / 4);
                e2 = (float)((Math.Sqrt((Math.Pow(r13 - r31, 2)) + (Math.Pow(r21 + r12, 2)) + (Math.Pow(r22 - r11 - r33 + 1, 2)) + (Math.Pow(r32 + r23, 2)))) / 4);
                e3 = (float)((Math.Sqrt((Math.Pow(r21 - r12, 2)) + (Math.Pow(r31 + r13, 2)) + (Math.Pow(r32 + r23, 2)) + (Math.Pow(r33 - r11 - r22 + 1, 2)))) / 4);

                // Checking for negative values
                if ((r32 - r23) < 0)
                {
                    e1 = -e1;
                }

                if ((r13 - r31) < 0)
                {
                    e2 = -e2;
                }

                if ((r21 - r12) < 0)
                {
                    e3 = -e3;
                }

                //Set values for Quaternion textboxes
                tbE0.Text = (e0).ToString("0.000");
                tbE1.Text = (e1).ToString("0.000");
                tbE2.Text = (e2).ToString("0.000");
                tbE3.Text = (e3).ToString("0.000");

                double Yaw = 0;
                double Pitch = 0;
                double Roll = 0;
                if (Math.Abs(Math.Abs(r31) - 1) < Double.Epsilon)
                {
                    Roll = 0;
                    if (r31 < 0)
                    {
                        Yaw = Math.Atan2(r23, r13);
                    }
                    else
                    {
                        Yaw = Math.Atan2(-r23, -r13);
                    }
                    Pitch = -(Math.Asin(r31));
                }
                else
                {
                    Roll = Math.Atan2(r32, r33);
                    Yaw = Math.Atan2(r21, r11);
                    if (r11 >= r21 && r11 >= r32 && r11 >= r33)
                    {
                        Pitch = Math.Atan2(-r31 * Math.Cos(Yaw), r11);
                    }
                    if (r21 >= r11 && r21 >= r32 && r21 >= r33)
                    {
                        Pitch = Math.Atan2(-r31 * Math.Sin(Yaw), r21);
                    }
                    if (r32 >= r21 && r32 >= r11 && r32 >= r33)
                    {
                        Pitch = Math.Atan2(-r31 * Math.Sin(Roll), r32);
                    }
                    if (r33 >= r21 && r33 >= r32 && r33 >= r11)
                    {
                        Pitch = Math.Atan2(-r31 * Math.Cos(Roll), r33);
                    }
                }

                //Set values for RPY textboxes
                tbYaw.Text = (Yaw * (180 / Math.PI)).ToString();
                tbPitch.Text = (Pitch * (180 / Math.PI)).ToString();
                tbRoll.Text = (Roll * (180 / Math.PI)).ToString();

                // Prepare servo update angle from desired angle (ie. 18.20 degrees = 1820)
                int angle1 = Convert.ToInt32(q1_deg * 100.0f);
                int angle2 = Convert.ToInt32(q2_deg * 100.0f);
                int angle3 = Convert.ToInt32(q3_deg * 100.0f);

                // Trigger servo motor to ove arm to desired angle
                TriggerServo(1, angle1);
                TriggerServo(2, angle2);
                TriggerServo(3, angle3);
            }
        }
    }
}

