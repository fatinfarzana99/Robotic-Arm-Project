namespace Robot
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnConnect = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Files = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslabelWifi = new System.Windows.Forms.ToolStripStatusLabel();
            this.SystemTimer = new System.Windows.Forms.Timer(this.components);
            this.btnEnARM = new System.Windows.Forms.Button();
            this.wifiSignal = new WindowWidgets.SignalStrength();
            this.btnArmHome = new System.Windows.Forms.Button();
            this.btnArmParking = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabFKine = new System.Windows.Forms.TabPage();
            this.gbFKineSol = new System.Windows.Forms.GroupBox();
            this.gbRPY = new System.Windows.Forms.GroupBox();
            this.tbRoll = new System.Windows.Forms.TextBox();
            this.tbPitch = new System.Windows.Forms.TextBox();
            this.tbYaw = new System.Windows.Forms.TextBox();
            this.labelRoll = new System.Windows.Forms.Label();
            this.labelPitch = new System.Windows.Forms.Label();
            this.labelYaw = new System.Windows.Forms.Label();
            this.gbQuaternion = new System.Windows.Forms.GroupBox();
            this.tbE3 = new System.Windows.Forms.TextBox();
            this.tbE2 = new System.Windows.Forms.TextBox();
            this.tbE1 = new System.Windows.Forms.TextBox();
            this.tbE0 = new System.Windows.Forms.TextBox();
            this.labelE3 = new System.Windows.Forms.Label();
            this.labelE2 = new System.Windows.Forms.Label();
            this.labelE1 = new System.Windows.Forms.Label();
            this.labelE0 = new System.Windows.Forms.Label();
            this.gbXYZ = new System.Windows.Forms.GroupBox();
            this.tbPz = new System.Windows.Forms.TextBox();
            this.tbPy = new System.Windows.Forms.TextBox();
            this.tbPx = new System.Windows.Forms.TextBox();
            this.labelPz = new System.Windows.Forms.Label();
            this.labelPy = new System.Windows.Forms.Label();
            this.labelPx = new System.Windows.Forms.Label();
            this.gbRmatrix = new System.Windows.Forms.GroupBox();
            this.labelR33 = new System.Windows.Forms.Label();
            this.labelR23 = new System.Windows.Forms.Label();
            this.labelR32 = new System.Windows.Forms.Label();
            this.labelR22 = new System.Windows.Forms.Label();
            this.labelR31 = new System.Windows.Forms.Label();
            this.labelR21 = new System.Windows.Forms.Label();
            this.labelR13 = new System.Windows.Forms.Label();
            this.labelR12 = new System.Windows.Forms.Label();
            this.labelR11 = new System.Windows.Forms.Label();
            this.tbR33 = new System.Windows.Forms.TextBox();
            this.tbR23 = new System.Windows.Forms.TextBox();
            this.tbR13 = new System.Windows.Forms.TextBox();
            this.tbR32 = new System.Windows.Forms.TextBox();
            this.tbR22 = new System.Windows.Forms.TextBox();
            this.tbR12 = new System.Windows.Forms.TextBox();
            this.tbR31 = new System.Windows.Forms.TextBox();
            this.tbR21 = new System.Windows.Forms.TextBox();
            this.tbR11 = new System.Windows.Forms.TextBox();
            this.gbFKine = new System.Windows.Forms.GroupBox();
            this.btnRstFKine = new System.Windows.Forms.Button();
            this.labelFkine = new System.Windows.Forms.Label();
            this.btnRunFKine = new System.Windows.Forms.Button();
            this.labelTeta3 = new System.Windows.Forms.Label();
            this.labelTeta2 = new System.Windows.Forms.Label();
            this.labelTeta1 = new System.Windows.Forms.Label();
            this.tbTeta3 = new System.Windows.Forms.TextBox();
            this.tbTeta2 = new System.Windows.Forms.TextBox();
            this.tbTeta1 = new System.Windows.Forms.TextBox();
            this.tabMainControl = new System.Windows.Forms.TabPage();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.cboxSobelDetect = new System.Windows.Forms.CheckBox();
            this.cboxCannyDetect = new System.Windows.Forms.CheckBox();
            this.cboxShapeDetect = new System.Windows.Forms.CheckBox();
            this.cboxColorTrack = new System.Windows.Forms.CheckBox();
            this.btnSnap = new System.Windows.Forms.Button();
            this.cboxObjectDetect = new System.Windows.Forms.CheckBox();
            this.ServoStatus8 = new System.Windows.Forms.PictureBox();
            this.ServoStatus7 = new System.Windows.Forms.PictureBox();
            this.gbSensor = new System.Windows.Forms.GroupBox();
            this.labelDist = new System.Windows.Forms.Label();
            this.gboxWheel = new System.Windows.Forms.GroupBox();
            this.btnSetDuty = new System.Windows.Forms.Button();
            this.tboxDuty = new System.Windows.Forms.TextBox();
            this.labelDuty = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnBwd = new System.Windows.Forms.Button();
            this.btnFwd = new System.Windows.Forms.Button();
            this.labelServo7 = new System.Windows.Forms.Label();
            this.labelServo8 = new System.Windows.Forms.Label();
            this.gbServoRemote = new System.Windows.Forms.GroupBox();
            this.btnSetServo6 = new System.Windows.Forms.Button();
            this.tboxServo6 = new System.Windows.Forms.TextBox();
            this.btnSetServo5 = new System.Windows.Forms.Button();
            this.tboxServo5 = new System.Windows.Forms.TextBox();
            this.btnSetServo4 = new System.Windows.Forms.Button();
            this.tboxServo4 = new System.Windows.Forms.TextBox();
            this.btnSetServo3 = new System.Windows.Forms.Button();
            this.tboxServo3 = new System.Windows.Forms.TextBox();
            this.btnSetServo2 = new System.Windows.Forms.Button();
            this.tboxServo2 = new System.Windows.Forms.TextBox();
            this.btnSetServo1 = new System.Windows.Forms.Button();
            this.tboxServo1 = new System.Windows.Forms.TextBox();
            this.ServoStatus6 = new System.Windows.Forms.PictureBox();
            this.ServoStatus5 = new System.Windows.Forms.PictureBox();
            this.ServoStatus4 = new System.Windows.Forms.PictureBox();
            this.ServoStatus3 = new System.Windows.Forms.PictureBox();
            this.ServoStatus2 = new System.Windows.Forms.PictureBox();
            this.ServoStatus1 = new System.Windows.Forms.PictureBox();
            this.labelServo6 = new System.Windows.Forms.Label();
            this.labelServo5 = new System.Windows.Forms.Label();
            this.labelServo4 = new System.Windows.Forms.Label();
            this.labelServo3 = new System.Windows.Forms.Label();
            this.labelServo2 = new System.Windows.Forms.Label();
            this.labelServo1 = new System.Windows.Forms.Label();
            this.tbarServo6 = new System.Windows.Forms.TrackBar();
            this.tbarServo1 = new System.Windows.Forms.TrackBar();
            this.tbarServo2 = new System.Windows.Forms.TrackBar();
            this.tbarServo3 = new System.Windows.Forms.TrackBar();
            this.tbarServo4 = new System.Windows.Forms.TrackBar();
            this.tbarServo5 = new System.Windows.Forms.TrackBar();
            this.tbarServo8 = new System.Windows.Forms.TrackBar();
            this.tbarServo7 = new System.Windows.Forms.TrackBar();
            this.cameraWindow = new motion.CameraWindow();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabIKine = new System.Windows.Forms.TabPage();
            this.gbIKineSol = new System.Windows.Forms.GroupBox();
            this.labelTeta3Inv = new System.Windows.Forms.Label();
            this.labelTeta2Inv = new System.Windows.Forms.Label();
            this.labelTeta1Inv = new System.Windows.Forms.Label();
            this.tbTeta3Inv = new System.Windows.Forms.TextBox();
            this.tbTeta2Inv = new System.Windows.Forms.TextBox();
            this.tbTeta1Inv = new System.Windows.Forms.TextBox();
            this.gbIKine = new System.Windows.Forms.GroupBox();
            this.btnRstIKine = new System.Windows.Forms.Button();
            this.labelIKine = new System.Windows.Forms.Label();
            this.btnRunIKine = new System.Windows.Forms.Button();
            this.labelPzInv = new System.Windows.Forms.Label();
            this.labelPyInv = new System.Windows.Forms.Label();
            this.labelPxInv = new System.Windows.Forms.Label();
            this.tbPzInv = new System.Windows.Forms.TextBox();
            this.tbPyInv = new System.Windows.Forms.TextBox();
            this.tbPxInv = new System.Windows.Forms.TextBox();
            this.tabAlgo = new System.Windows.Forms.TabPage();
            this.gbFunc = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelFuncSts = new System.Windows.Forms.Label();
            this.btnRstFunc = new System.Windows.Forms.Button();
            this.btnRunSquare = new System.Windows.Forms.Button();
            this.btnRunPickPlace = new System.Windows.Forms.Button();
            this.gbLine = new System.Windows.Forms.GroupBox();
            this.labelPxLine13 = new System.Windows.Forms.Label();
            this.labelPxLine12 = new System.Windows.Forms.Label();
            this.labelPoint13 = new System.Windows.Forms.Label();
            this.labelPoint12 = new System.Windows.Forms.Label();
            this.labelPoint11 = new System.Windows.Forms.Label();
            this.labelLineSts = new System.Windows.Forms.Label();
            this.btnRstLine = new System.Windows.Forms.Button();
            this.labelPzLine13 = new System.Windows.Forms.Label();
            this.btnRunLine = new System.Windows.Forms.Button();
            this.labelPyLine13 = new System.Windows.Forms.Label();
            this.tbPz13 = new System.Windows.Forms.TextBox();
            this.tbPy13 = new System.Windows.Forms.TextBox();
            this.tbPx13 = new System.Windows.Forms.TextBox();
            this.labelPzLine12 = new System.Windows.Forms.Label();
            this.labelPyLine12 = new System.Windows.Forms.Label();
            this.tbPz12 = new System.Windows.Forms.TextBox();
            this.tbPy12 = new System.Windows.Forms.TextBox();
            this.tbPx12 = new System.Windows.Forms.TextBox();
            this.labelPzLine11 = new System.Windows.Forms.Label();
            this.labelPyLine11 = new System.Windows.Forms.Label();
            this.labelPxLine11 = new System.Windows.Forms.Label();
            this.tbPz11 = new System.Windows.Forms.TextBox();
            this.tbPy11 = new System.Windows.Forms.TextBox();
            this.tbPx11 = new System.Windows.Forms.TextBox();
            this.tbRad = new System.Windows.Forms.TextBox();
            this.lblsum1 = new System.Windows.Forms.Label();
            this.lblsum2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabFKine.SuspendLayout();
            this.gbFKineSol.SuspendLayout();
            this.gbRPY.SuspendLayout();
            this.gbQuaternion.SuspendLayout();
            this.gbXYZ.SuspendLayout();
            this.gbRmatrix.SuspendLayout();
            this.gbFKine.SuspendLayout();
            this.tabMainControl.SuspendLayout();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServoStatus8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServoStatus7)).BeginInit();
            this.gbSensor.SuspendLayout();
            this.gboxWheel.SuspendLayout();
            this.gbServoRemote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServoStatus6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServoStatus5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServoStatus4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServoStatus3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServoStatus2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServoStatus1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarServo6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarServo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarServo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarServo3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarServo4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarServo5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarServo8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarServo7)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabIKine.SuspendLayout();
            this.gbIKineSol.SuspendLayout();
            this.gbIKine.SuspendLayout();
            this.tabAlgo.SuspendLayout();
            this.gbFunc.SuspendLayout();
            this.gbLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(14, 593);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(85, 32);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Files
            // 
            this.Files.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Files.Name = "Files";
            this.Files.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(920, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.filesToolStripMenuItem.Text = "Files";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslabelStatus,
            this.tslabelWifi});
            this.statusStrip1.Location = new System.Drawing.Point(0, 630);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(920, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslabelStatus
            // 
            this.tslabelStatus.Name = "tslabelStatus";
            this.tslabelStatus.Size = new System.Drawing.Size(131, 17);
            this.tslabelStatus.Text = "Click \"Connect\" to start";
            // 
            // tslabelWifi
            // 
            this.tslabelWifi.Name = "tslabelWifi";
            this.tslabelWifi.Size = new System.Drawing.Size(0, 17);
            // 
            // SystemTimer
            // 
            this.SystemTimer.Interval = 1000;
            this.SystemTimer.Tick += new System.EventHandler(this.SystemTimer_Tick);
            // 
            // btnEnARM
            // 
            this.btnEnARM.Enabled = false;
            this.btnEnARM.Location = new System.Drawing.Point(104, 593);
            this.btnEnARM.Name = "btnEnARM";
            this.btnEnARM.Size = new System.Drawing.Size(94, 32);
            this.btnEnARM.TabIndex = 7;
            this.btnEnARM.Text = "Enable ARM";
            this.btnEnARM.UseVisualStyleBackColor = true;
            this.btnEnARM.Click += new System.EventHandler(this.btnEnARM_Click);
            // 
            // wifiSignal
            // 
            this.wifiSignal.BackgroundStyle = WindowWidgets.SignalStrengthBackgroundStyle.Normal;
            this.wifiSignal.BarLayout = WindowWidgets.SignalStrengthLayout.LeftToRight;
            this.wifiSignal.BarSpacing = 2;
            this.wifiSignal.BarStepSize = 10;
            this.wifiSignal.CenterGradientColor = System.Drawing.Color.WhiteSmoke;
            this.wifiSignal.EmptyBarColor = System.Drawing.Color.Gray;
            this.wifiSignal.GoodSignalColor = System.Drawing.Color.Green;
            this.wifiSignal.GoodSignalThreshold = 8F;
            this.wifiSignal.Location = new System.Drawing.Point(865, 596);
            this.wifiSignal.Margin = new System.Windows.Forms.Padding(4);
            this.wifiSignal.MaximumValue = 10F;
            this.wifiSignal.MinimumValue = 0F;
            this.wifiSignal.Name = "wifiSignal";
            this.wifiSignal.NoSignalColor = System.Drawing.Color.Red;
            this.wifiSignal.NoSignalThreshold = 0F;
            this.wifiSignal.NumberOfBars = 5;
            this.wifiSignal.PoorSignalColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.wifiSignal.PoorSignalThreshold = 5F;
            this.wifiSignal.Size = new System.Drawing.Size(43, 32);
            this.wifiSignal.SmallBarHeight = 5;
            this.wifiSignal.UseSolidBars = true;
            this.wifiSignal.Value = 0F;
            this.wifiSignal.WeakSignalColor = System.Drawing.Color.Red;
            this.wifiSignal.WeakSignalThreshold = 20F;
            this.wifiSignal.XColor = System.Drawing.Color.White;
            this.wifiSignal.XIfNoSignal = false;
            this.wifiSignal.XWidth = 1.5F;
            // 
            // btnArmHome
            // 
            this.btnArmHome.Enabled = false;
            this.btnArmHome.Location = new System.Drawing.Point(205, 594);
            this.btnArmHome.Name = "btnArmHome";
            this.btnArmHome.Size = new System.Drawing.Size(99, 32);
            this.btnArmHome.TabIndex = 8;
            this.btnArmHome.Text = "Default Position";
            this.btnArmHome.UseVisualStyleBackColor = true;
            this.btnArmHome.Click += new System.EventHandler(this.btnArmHome_Click);
            // 
            // btnArmParking
            // 
            this.btnArmParking.Enabled = false;
            this.btnArmParking.Location = new System.Drawing.Point(309, 595);
            this.btnArmParking.Name = "btnArmParking";
            this.btnArmParking.Size = new System.Drawing.Size(99, 32);
            this.btnArmParking.TabIndex = 10;
            this.btnArmParking.Text = "Parking Position";
            this.btnArmParking.UseVisualStyleBackColor = true;
            this.btnArmParking.Click += new System.EventHandler(this.btnArmParking_Click);
            // 
            // tabFKine
            // 
            this.tabFKine.Controls.Add(this.gbFKineSol);
            this.tabFKine.Controls.Add(this.gbFKine);
            this.tabFKine.Location = new System.Drawing.Point(4, 22);
            this.tabFKine.Margin = new System.Windows.Forms.Padding(2);
            this.tabFKine.Name = "tabFKine";
            this.tabFKine.Padding = new System.Windows.Forms.Padding(2);
            this.tabFKine.Size = new System.Drawing.Size(900, 528);
            this.tabFKine.TabIndex = 2;
            this.tabFKine.Text = "Forward Kinematics";
            this.tabFKine.UseVisualStyleBackColor = true;
            // 
            // gbFKineSol
            // 
            this.gbFKineSol.Controls.Add(this.gbRPY);
            this.gbFKineSol.Controls.Add(this.gbQuaternion);
            this.gbFKineSol.Controls.Add(this.gbXYZ);
            this.gbFKineSol.Controls.Add(this.gbRmatrix);
            this.gbFKineSol.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFKineSol.Location = new System.Drawing.Point(320, 93);
            this.gbFKineSol.Margin = new System.Windows.Forms.Padding(2);
            this.gbFKineSol.Name = "gbFKineSol";
            this.gbFKineSol.Padding = new System.Windows.Forms.Padding(2);
            this.gbFKineSol.Size = new System.Drawing.Size(516, 333);
            this.gbFKineSol.TabIndex = 1;
            this.gbFKineSol.TabStop = false;
            this.gbFKineSol.Text = "Forward Kinematics Solution";
            // 
            // gbRPY
            // 
            this.gbRPY.Controls.Add(this.tbRoll);
            this.gbRPY.Controls.Add(this.tbPitch);
            this.gbRPY.Controls.Add(this.tbYaw);
            this.gbRPY.Controls.Add(this.labelRoll);
            this.gbRPY.Controls.Add(this.labelPitch);
            this.gbRPY.Controls.Add(this.labelYaw);
            this.gbRPY.Location = new System.Drawing.Point(292, 179);
            this.gbRPY.Margin = new System.Windows.Forms.Padding(2);
            this.gbRPY.Name = "gbRPY";
            this.gbRPY.Padding = new System.Windows.Forms.Padding(2);
            this.gbRPY.Size = new System.Drawing.Size(210, 141);
            this.gbRPY.TabIndex = 3;
            this.gbRPY.TabStop = false;
            this.gbRPY.Text = "ZYX Euler Angles";
            // 
            // tbRoll
            // 
            this.tbRoll.Enabled = false;
            this.tbRoll.Location = new System.Drawing.Point(59, 110);
            this.tbRoll.Margin = new System.Windows.Forms.Padding(2);
            this.tbRoll.Multiline = true;
            this.tbRoll.Name = "tbRoll";
            this.tbRoll.Size = new System.Drawing.Size(131, 24);
            this.tbRoll.TabIndex = 22;
            // 
            // tbPitch
            // 
            this.tbPitch.Enabled = false;
            this.tbPitch.Location = new System.Drawing.Point(59, 70);
            this.tbPitch.Margin = new System.Windows.Forms.Padding(2);
            this.tbPitch.Multiline = true;
            this.tbPitch.Name = "tbPitch";
            this.tbPitch.Size = new System.Drawing.Size(131, 24);
            this.tbPitch.TabIndex = 21;
            // 
            // tbYaw
            // 
            this.tbYaw.Enabled = false;
            this.tbYaw.Location = new System.Drawing.Point(59, 32);
            this.tbYaw.Margin = new System.Windows.Forms.Padding(2);
            this.tbYaw.Multiline = true;
            this.tbYaw.Name = "tbYaw";
            this.tbYaw.Size = new System.Drawing.Size(131, 24);
            this.tbYaw.TabIndex = 18;
            // 
            // labelRoll
            // 
            this.labelRoll.AutoSize = true;
            this.labelRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRoll.Location = new System.Drawing.Point(19, 110);
            this.labelRoll.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRoll.Name = "labelRoll";
            this.labelRoll.Size = new System.Drawing.Size(41, 17);
            this.labelRoll.TabIndex = 20;
            this.labelRoll.Text = "Roll:";
            // 
            // labelPitch
            // 
            this.labelPitch.AutoSize = true;
            this.labelPitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPitch.Location = new System.Drawing.Point(11, 71);
            this.labelPitch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPitch.Name = "labelPitch";
            this.labelPitch.Size = new System.Drawing.Size(49, 17);
            this.labelPitch.TabIndex = 19;
            this.labelPitch.Text = "Pitch:";
            // 
            // labelYaw
            // 
            this.labelYaw.AutoSize = true;
            this.labelYaw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYaw.Location = new System.Drawing.Point(18, 32);
            this.labelYaw.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelYaw.Name = "labelYaw";
            this.labelYaw.Size = new System.Drawing.Size(42, 17);
            this.labelYaw.TabIndex = 18;
            this.labelYaw.Text = "Yaw:";
            // 
            // gbQuaternion
            // 
            this.gbQuaternion.Controls.Add(this.tbE3);
            this.gbQuaternion.Controls.Add(this.tbE2);
            this.gbQuaternion.Controls.Add(this.tbE1);
            this.gbQuaternion.Controls.Add(this.tbE0);
            this.gbQuaternion.Controls.Add(this.labelE3);
            this.gbQuaternion.Controls.Add(this.labelE2);
            this.gbQuaternion.Controls.Add(this.labelE1);
            this.gbQuaternion.Controls.Add(this.labelE0);
            this.gbQuaternion.Location = new System.Drawing.Point(12, 177);
            this.gbQuaternion.Margin = new System.Windows.Forms.Padding(2);
            this.gbQuaternion.Name = "gbQuaternion";
            this.gbQuaternion.Padding = new System.Windows.Forms.Padding(2);
            this.gbQuaternion.Size = new System.Drawing.Size(212, 141);
            this.gbQuaternion.TabIndex = 2;
            this.gbQuaternion.TabStop = false;
            this.gbQuaternion.Text = "Quaternion Values";
            // 
            // tbE3
            // 
            this.tbE3.Enabled = false;
            this.tbE3.Location = new System.Drawing.Point(53, 110);
            this.tbE3.Margin = new System.Windows.Forms.Padding(2);
            this.tbE3.Multiline = true;
            this.tbE3.Name = "tbE3";
            this.tbE3.Size = new System.Drawing.Size(131, 24);
            this.tbE3.TabIndex = 17;
            // 
            // tbE2
            // 
            this.tbE2.Enabled = false;
            this.tbE2.Location = new System.Drawing.Point(53, 82);
            this.tbE2.Margin = new System.Windows.Forms.Padding(2);
            this.tbE2.Multiline = true;
            this.tbE2.Name = "tbE2";
            this.tbE2.Size = new System.Drawing.Size(131, 24);
            this.tbE2.TabIndex = 16;
            // 
            // tbE1
            // 
            this.tbE1.Enabled = false;
            this.tbE1.Location = new System.Drawing.Point(53, 52);
            this.tbE1.Margin = new System.Windows.Forms.Padding(2);
            this.tbE1.Multiline = true;
            this.tbE1.Name = "tbE1";
            this.tbE1.Size = new System.Drawing.Size(131, 24);
            this.tbE1.TabIndex = 15;
            // 
            // tbE0
            // 
            this.tbE0.Enabled = false;
            this.tbE0.Location = new System.Drawing.Point(53, 21);
            this.tbE0.Margin = new System.Windows.Forms.Padding(2);
            this.tbE0.Multiline = true;
            this.tbE0.Name = "tbE0";
            this.tbE0.Size = new System.Drawing.Size(131, 24);
            this.tbE0.TabIndex = 11;
            // 
            // labelE3
            // 
            this.labelE3.AutoSize = true;
            this.labelE3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelE3.Location = new System.Drawing.Point(24, 115);
            this.labelE3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelE3.Name = "labelE3";
            this.labelE3.Size = new System.Drawing.Size(31, 17);
            this.labelE3.TabIndex = 14;
            this.labelE3.Text = "e3:";
            // 
            // labelE2
            // 
            this.labelE2.AutoSize = true;
            this.labelE2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelE2.Location = new System.Drawing.Point(24, 86);
            this.labelE2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelE2.Name = "labelE2";
            this.labelE2.Size = new System.Drawing.Size(31, 17);
            this.labelE2.TabIndex = 13;
            this.labelE2.Text = "e2:";
            // 
            // labelE1
            // 
            this.labelE1.AutoSize = true;
            this.labelE1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelE1.Location = new System.Drawing.Point(24, 56);
            this.labelE1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelE1.Name = "labelE1";
            this.labelE1.Size = new System.Drawing.Size(31, 17);
            this.labelE1.TabIndex = 12;
            this.labelE1.Text = "e1:";
            // 
            // labelE0
            // 
            this.labelE0.AutoSize = true;
            this.labelE0.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelE0.Location = new System.Drawing.Point(24, 24);
            this.labelE0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelE0.Name = "labelE0";
            this.labelE0.Size = new System.Drawing.Size(31, 17);
            this.labelE0.TabIndex = 11;
            this.labelE0.Text = "e0:";
            // 
            // gbXYZ
            // 
            this.gbXYZ.Controls.Add(this.tbPz);
            this.gbXYZ.Controls.Add(this.tbPy);
            this.gbXYZ.Controls.Add(this.tbPx);
            this.gbXYZ.Controls.Add(this.labelPz);
            this.gbXYZ.Controls.Add(this.labelPy);
            this.gbXYZ.Controls.Add(this.labelPx);
            this.gbXYZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbXYZ.Location = new System.Drawing.Point(334, 25);
            this.gbXYZ.Margin = new System.Windows.Forms.Padding(2);
            this.gbXYZ.Name = "gbXYZ";
            this.gbXYZ.Padding = new System.Windows.Forms.Padding(2);
            this.gbXYZ.Size = new System.Drawing.Size(168, 147);
            this.gbXYZ.TabIndex = 1;
            this.gbXYZ.TabStop = false;
            this.gbXYZ.Text = "Position Vector";
            // 
            // tbPz
            // 
            this.tbPz.Enabled = false;
            this.tbPz.Location = new System.Drawing.Point(38, 102);
            this.tbPz.Margin = new System.Windows.Forms.Padding(2);
            this.tbPz.Multiline = true;
            this.tbPz.Name = "tbPz";
            this.tbPz.Size = new System.Drawing.Size(121, 24);
            this.tbPz.TabIndex = 25;
            // 
            // tbPy
            // 
            this.tbPy.Enabled = false;
            this.tbPy.Location = new System.Drawing.Point(38, 69);
            this.tbPy.Margin = new System.Windows.Forms.Padding(2);
            this.tbPy.Multiline = true;
            this.tbPy.Name = "tbPy";
            this.tbPy.Size = new System.Drawing.Size(121, 24);
            this.tbPy.TabIndex = 24;
            // 
            // tbPx
            // 
            this.tbPx.Enabled = false;
            this.tbPx.Location = new System.Drawing.Point(38, 32);
            this.tbPx.Margin = new System.Windows.Forms.Padding(2);
            this.tbPx.Multiline = true;
            this.tbPx.Name = "tbPx";
            this.tbPx.Size = new System.Drawing.Size(121, 24);
            this.tbPx.TabIndex = 11;
            // 
            // labelPz
            // 
            this.labelPz.AutoSize = true;
            this.labelPz.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPz.Location = new System.Drawing.Point(7, 105);
            this.labelPz.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPz.Name = "labelPz";
            this.labelPz.Size = new System.Drawing.Size(31, 17);
            this.labelPz.TabIndex = 23;
            this.labelPz.Text = "Pz:";
            // 
            // labelPy
            // 
            this.labelPy.AutoSize = true;
            this.labelPy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPy.Location = new System.Drawing.Point(7, 71);
            this.labelPy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPy.Name = "labelPy";
            this.labelPy.Size = new System.Drawing.Size(31, 17);
            this.labelPy.TabIndex = 22;
            this.labelPy.Text = "Py:";
            // 
            // labelPx
            // 
            this.labelPx.AutoSize = true;
            this.labelPx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPx.Location = new System.Drawing.Point(7, 35);
            this.labelPx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPx.Name = "labelPx";
            this.labelPx.Size = new System.Drawing.Size(30, 17);
            this.labelPx.TabIndex = 21;
            this.labelPx.Text = "Px:";
            // 
            // gbRmatrix
            // 
            this.gbRmatrix.Controls.Add(this.labelR33);
            this.gbRmatrix.Controls.Add(this.labelR23);
            this.gbRmatrix.Controls.Add(this.labelR32);
            this.gbRmatrix.Controls.Add(this.labelR22);
            this.gbRmatrix.Controls.Add(this.labelR31);
            this.gbRmatrix.Controls.Add(this.labelR21);
            this.gbRmatrix.Controls.Add(this.labelR13);
            this.gbRmatrix.Controls.Add(this.labelR12);
            this.gbRmatrix.Controls.Add(this.labelR11);
            this.gbRmatrix.Controls.Add(this.tbR33);
            this.gbRmatrix.Controls.Add(this.tbR23);
            this.gbRmatrix.Controls.Add(this.tbR13);
            this.gbRmatrix.Controls.Add(this.tbR32);
            this.gbRmatrix.Controls.Add(this.tbR22);
            this.gbRmatrix.Controls.Add(this.tbR12);
            this.gbRmatrix.Controls.Add(this.tbR31);
            this.gbRmatrix.Controls.Add(this.tbR21);
            this.gbRmatrix.Controls.Add(this.tbR11);
            this.gbRmatrix.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbRmatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRmatrix.Location = new System.Drawing.Point(12, 25);
            this.gbRmatrix.Margin = new System.Windows.Forms.Padding(2);
            this.gbRmatrix.Name = "gbRmatrix";
            this.gbRmatrix.Padding = new System.Windows.Forms.Padding(2);
            this.gbRmatrix.Size = new System.Drawing.Size(311, 147);
            this.gbRmatrix.TabIndex = 0;
            this.gbRmatrix.TabStop = false;
            this.gbRmatrix.Text = "R Matrix";
            // 
            // labelR33
            // 
            this.labelR33.AutoSize = true;
            this.labelR33.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelR33.Location = new System.Drawing.Point(206, 115);
            this.labelR33.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelR33.Name = "labelR33";
            this.labelR33.Size = new System.Drawing.Size(37, 17);
            this.labelR33.TabIndex = 20;
            this.labelR33.Text = "r33:";
            // 
            // labelR23
            // 
            this.labelR23.AutoSize = true;
            this.labelR23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelR23.Location = new System.Drawing.Point(206, 80);
            this.labelR23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelR23.Name = "labelR23";
            this.labelR23.Size = new System.Drawing.Size(37, 17);
            this.labelR23.TabIndex = 19;
            this.labelR23.Text = "r23:";
            // 
            // labelR32
            // 
            this.labelR32.AutoSize = true;
            this.labelR32.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelR32.Location = new System.Drawing.Point(104, 115);
            this.labelR32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelR32.Name = "labelR32";
            this.labelR32.Size = new System.Drawing.Size(37, 17);
            this.labelR32.TabIndex = 18;
            this.labelR32.Text = "r32:";
            // 
            // labelR22
            // 
            this.labelR22.AutoSize = true;
            this.labelR22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelR22.Location = new System.Drawing.Point(104, 80);
            this.labelR22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelR22.Name = "labelR22";
            this.labelR22.Size = new System.Drawing.Size(37, 17);
            this.labelR22.TabIndex = 17;
            this.labelR22.Text = "r22:";
            // 
            // labelR31
            // 
            this.labelR31.AutoSize = true;
            this.labelR31.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelR31.Location = new System.Drawing.Point(4, 114);
            this.labelR31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelR31.Name = "labelR31";
            this.labelR31.Size = new System.Drawing.Size(37, 17);
            this.labelR31.TabIndex = 16;
            this.labelR31.Text = "r31:";
            // 
            // labelR21
            // 
            this.labelR21.AutoSize = true;
            this.labelR21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelR21.Location = new System.Drawing.Point(4, 80);
            this.labelR21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelR21.Name = "labelR21";
            this.labelR21.Size = new System.Drawing.Size(37, 17);
            this.labelR21.TabIndex = 15;
            this.labelR21.Text = "r21:";
            // 
            // labelR13
            // 
            this.labelR13.AutoSize = true;
            this.labelR13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelR13.Location = new System.Drawing.Point(206, 41);
            this.labelR13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelR13.Name = "labelR13";
            this.labelR13.Size = new System.Drawing.Size(37, 17);
            this.labelR13.TabIndex = 14;
            this.labelR13.Text = "r13:";
            // 
            // labelR12
            // 
            this.labelR12.AutoSize = true;
            this.labelR12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelR12.Location = new System.Drawing.Point(104, 41);
            this.labelR12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelR12.Name = "labelR12";
            this.labelR12.Size = new System.Drawing.Size(37, 17);
            this.labelR12.TabIndex = 13;
            this.labelR12.Text = "r12:";
            // 
            // labelR11
            // 
            this.labelR11.AutoSize = true;
            this.labelR11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelR11.Location = new System.Drawing.Point(4, 41);
            this.labelR11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelR11.Name = "labelR11";
            this.labelR11.Size = new System.Drawing.Size(37, 17);
            this.labelR11.TabIndex = 11;
            this.labelR11.Text = "r11:";
            // 
            // tbR33
            // 
            this.tbR33.Enabled = false;
            this.tbR33.Location = new System.Drawing.Point(243, 111);
            this.tbR33.Margin = new System.Windows.Forms.Padding(2);
            this.tbR33.Multiline = true;
            this.tbR33.Name = "tbR33";
            this.tbR33.Size = new System.Drawing.Size(59, 24);
            this.tbR33.TabIndex = 12;
            // 
            // tbR23
            // 
            this.tbR23.Enabled = false;
            this.tbR23.Location = new System.Drawing.Point(243, 76);
            this.tbR23.Margin = new System.Windows.Forms.Padding(2);
            this.tbR23.Multiline = true;
            this.tbR23.Name = "tbR23";
            this.tbR23.Size = new System.Drawing.Size(59, 24);
            this.tbR23.TabIndex = 11;
            // 
            // tbR13
            // 
            this.tbR13.Enabled = false;
            this.tbR13.Location = new System.Drawing.Point(243, 39);
            this.tbR13.Margin = new System.Windows.Forms.Padding(2);
            this.tbR13.Multiline = true;
            this.tbR13.Name = "tbR13";
            this.tbR13.Size = new System.Drawing.Size(59, 24);
            this.tbR13.TabIndex = 10;
            // 
            // tbR32
            // 
            this.tbR32.Enabled = false;
            this.tbR32.Location = new System.Drawing.Point(141, 111);
            this.tbR32.Margin = new System.Windows.Forms.Padding(2);
            this.tbR32.Multiline = true;
            this.tbR32.Name = "tbR32";
            this.tbR32.Size = new System.Drawing.Size(59, 24);
            this.tbR32.TabIndex = 9;
            // 
            // tbR22
            // 
            this.tbR22.Enabled = false;
            this.tbR22.Location = new System.Drawing.Point(141, 76);
            this.tbR22.Margin = new System.Windows.Forms.Padding(2);
            this.tbR22.Multiline = true;
            this.tbR22.Name = "tbR22";
            this.tbR22.Size = new System.Drawing.Size(59, 24);
            this.tbR22.TabIndex = 8;
            // 
            // tbR12
            // 
            this.tbR12.Enabled = false;
            this.tbR12.Location = new System.Drawing.Point(141, 39);
            this.tbR12.Margin = new System.Windows.Forms.Padding(2);
            this.tbR12.Multiline = true;
            this.tbR12.Name = "tbR12";
            this.tbR12.Size = new System.Drawing.Size(59, 24);
            this.tbR12.TabIndex = 7;
            // 
            // tbR31
            // 
            this.tbR31.Enabled = false;
            this.tbR31.Location = new System.Drawing.Point(42, 111);
            this.tbR31.Margin = new System.Windows.Forms.Padding(2);
            this.tbR31.Multiline = true;
            this.tbR31.Name = "tbR31";
            this.tbR31.Size = new System.Drawing.Size(59, 24);
            this.tbR31.TabIndex = 6;
            // 
            // tbR21
            // 
            this.tbR21.Enabled = false;
            this.tbR21.Location = new System.Drawing.Point(42, 76);
            this.tbR21.Margin = new System.Windows.Forms.Padding(2);
            this.tbR21.Multiline = true;
            this.tbR21.Name = "tbR21";
            this.tbR21.Size = new System.Drawing.Size(59, 24);
            this.tbR21.TabIndex = 5;
            // 
            // tbR11
            // 
            this.tbR11.Enabled = false;
            this.tbR11.Location = new System.Drawing.Point(42, 39);
            this.tbR11.Margin = new System.Windows.Forms.Padding(2);
            this.tbR11.Multiline = true;
            this.tbR11.Name = "tbR11";
            this.tbR11.Size = new System.Drawing.Size(59, 24);
            this.tbR11.TabIndex = 4;
            this.tbR11.TextChanged += new System.EventHandler(this.tbR11_TextChanged);
            // 
            // gbFKine
            // 
            this.gbFKine.Controls.Add(this.btnRstFKine);
            this.gbFKine.Controls.Add(this.labelFkine);
            this.gbFKine.Controls.Add(this.btnRunFKine);
            this.gbFKine.Controls.Add(this.labelTeta3);
            this.gbFKine.Controls.Add(this.labelTeta2);
            this.gbFKine.Controls.Add(this.labelTeta1);
            this.gbFKine.Controls.Add(this.tbTeta3);
            this.gbFKine.Controls.Add(this.tbTeta2);
            this.gbFKine.Controls.Add(this.tbTeta1);
            this.gbFKine.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFKine.Location = new System.Drawing.Point(68, 150);
            this.gbFKine.Margin = new System.Windows.Forms.Padding(2);
            this.gbFKine.Name = "gbFKine";
            this.gbFKine.Padding = new System.Windows.Forms.Padding(2);
            this.gbFKine.Size = new System.Drawing.Size(239, 193);
            this.gbFKine.TabIndex = 0;
            this.gbFKine.TabStop = false;
            this.gbFKine.Text = "Forward Kinematics";
            // 
            // btnRstFKine
            // 
            this.btnRstFKine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRstFKine.Location = new System.Drawing.Point(12, 145);
            this.btnRstFKine.Margin = new System.Windows.Forms.Padding(2);
            this.btnRstFKine.Name = "btnRstFKine";
            this.btnRstFKine.Size = new System.Drawing.Size(106, 29);
            this.btnRstFKine.TabIndex = 11;
            this.btnRstFKine.Text = "Reset";
            this.btnRstFKine.UseVisualStyleBackColor = true;
            this.btnRstFKine.Click += new System.EventHandler(this.btnRstFKine_Click);
            // 
            // labelFkine
            // 
            this.labelFkine.AutoSize = true;
            this.labelFkine.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFkine.ForeColor = System.Drawing.Color.Black;
            this.labelFkine.Location = new System.Drawing.Point(17, 31);
            this.labelFkine.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFkine.Name = "labelFkine";
            this.labelFkine.Size = new System.Drawing.Size(157, 13);
            this.labelFkine.TabIndex = 10;
            this.labelFkine.Text = "Key In Theta Values (Deg)";
            // 
            // btnRunFKine
            // 
            this.btnRunFKine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunFKine.Location = new System.Drawing.Point(122, 145);
            this.btnRunFKine.Margin = new System.Windows.Forms.Padding(2);
            this.btnRunFKine.Name = "btnRunFKine";
            this.btnRunFKine.Size = new System.Drawing.Size(106, 29);
            this.btnRunFKine.TabIndex = 9;
            this.btnRunFKine.Text = "Run";
            this.btnRunFKine.UseVisualStyleBackColor = true;
            this.btnRunFKine.Click += new System.EventHandler(this.btnRunFKine_Click);
            // 
            // labelTeta3
            // 
            this.labelTeta3.AutoSize = true;
            this.labelTeta3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeta3.Location = new System.Drawing.Point(34, 116);
            this.labelTeta3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTeta3.Name = "labelTeta3";
            this.labelTeta3.Size = new System.Drawing.Size(31, 17);
            this.labelTeta3.TabIndex = 8;
            this.labelTeta3.Text = "θ3:";
            // 
            // labelTeta2
            // 
            this.labelTeta2.AutoSize = true;
            this.labelTeta2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeta2.Location = new System.Drawing.Point(34, 92);
            this.labelTeta2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTeta2.Name = "labelTeta2";
            this.labelTeta2.Size = new System.Drawing.Size(31, 17);
            this.labelTeta2.TabIndex = 7;
            this.labelTeta2.Text = "θ2:";
            // 
            // labelTeta1
            // 
            this.labelTeta1.AutoSize = true;
            this.labelTeta1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeta1.Location = new System.Drawing.Point(34, 65);
            this.labelTeta1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTeta1.Name = "labelTeta1";
            this.labelTeta1.Size = new System.Drawing.Size(31, 17);
            this.labelTeta1.TabIndex = 6;
            this.labelTeta1.Text = "θ1:";
            // 
            // tbTeta3
            // 
            this.tbTeta3.Location = new System.Drawing.Point(73, 114);
            this.tbTeta3.Margin = new System.Windows.Forms.Padding(2);
            this.tbTeta3.Multiline = true;
            this.tbTeta3.Name = "tbTeta3";
            this.tbTeta3.Size = new System.Drawing.Size(131, 24);
            this.tbTeta3.TabIndex = 5;
            // 
            // tbTeta2
            // 
            this.tbTeta2.Location = new System.Drawing.Point(73, 89);
            this.tbTeta2.Margin = new System.Windows.Forms.Padding(2);
            this.tbTeta2.Multiline = true;
            this.tbTeta2.Name = "tbTeta2";
            this.tbTeta2.Size = new System.Drawing.Size(131, 24);
            this.tbTeta2.TabIndex = 4;
            // 
            // tbTeta1
            // 
            this.tbTeta1.Location = new System.Drawing.Point(73, 63);
            this.tbTeta1.Margin = new System.Windows.Forms.Padding(2);
            this.tbTeta1.Multiline = true;
            this.tbTeta1.Name = "tbTeta1";
            this.tbTeta1.Size = new System.Drawing.Size(131, 24);
            this.tbTeta1.TabIndex = 3;
            // 
            // tabMainControl
            // 
            this.tabMainControl.BackColor = System.Drawing.Color.Transparent;
            this.tabMainControl.Controls.Add(this.gbFilter);
            this.tabMainControl.Controls.Add(this.ServoStatus8);
            this.tabMainControl.Controls.Add(this.ServoStatus7);
            this.tabMainControl.Controls.Add(this.gbSensor);
            this.tabMainControl.Controls.Add(this.gboxWheel);
            this.tabMainControl.Controls.Add(this.labelServo7);
            this.tabMainControl.Controls.Add(this.labelServo8);
            this.tabMainControl.Controls.Add(this.gbServoRemote);
            this.tabMainControl.Controls.Add(this.tbarServo8);
            this.tabMainControl.Controls.Add(this.tbarServo7);
            this.tabMainControl.Controls.Add(this.cameraWindow);
            this.tabMainControl.Location = new System.Drawing.Point(4, 22);
            this.tabMainControl.Name = "tabMainControl";
            this.tabMainControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabMainControl.Size = new System.Drawing.Size(900, 528);
            this.tabMainControl.TabIndex = 0;
            this.tabMainControl.Text = "Manual Control";
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.cboxSobelDetect);
            this.gbFilter.Controls.Add(this.cboxCannyDetect);
            this.gbFilter.Controls.Add(this.cboxShapeDetect);
            this.gbFilter.Controls.Add(this.cboxColorTrack);
            this.gbFilter.Controls.Add(this.btnSnap);
            this.gbFilter.Controls.Add(this.cboxObjectDetect);
            this.gbFilter.Location = new System.Drawing.Point(6, 452);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(270, 73);
            this.gbFilter.TabIndex = 32;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Video Camera Control";
            // 
            // cboxSobelDetect
            // 
            this.cboxSobelDetect.AutoSize = true;
            this.cboxSobelDetect.Location = new System.Drawing.Point(214, 34);
            this.cboxSobelDetect.Name = "cboxSobelDetect";
            this.cboxSobelDetect.Size = new System.Drawing.Size(53, 17);
            this.cboxSobelDetect.TabIndex = 35;
            this.cboxSobelDetect.Text = "Sobel";
            this.cboxSobelDetect.UseVisualStyleBackColor = true;
            this.cboxSobelDetect.CheckedChanged += new System.EventHandler(this.cboxSobelDetect_CheckedChanged);
            // 
            // cboxCannyDetect
            // 
            this.cboxCannyDetect.AutoSize = true;
            this.cboxCannyDetect.Location = new System.Drawing.Point(214, 17);
            this.cboxCannyDetect.Name = "cboxCannyDetect";
            this.cboxCannyDetect.Size = new System.Drawing.Size(56, 17);
            this.cboxCannyDetect.TabIndex = 34;
            this.cboxCannyDetect.Text = "Canny";
            this.cboxCannyDetect.UseVisualStyleBackColor = true;
            this.cboxCannyDetect.CheckedChanged += new System.EventHandler(this.cboxCannyDetect_CheckedChanged);
            // 
            // cboxShapeDetect
            // 
            this.cboxShapeDetect.AutoSize = true;
            this.cboxShapeDetect.Location = new System.Drawing.Point(96, 50);
            this.cboxShapeDetect.Name = "cboxShapeDetect";
            this.cboxShapeDetect.Size = new System.Drawing.Size(106, 17);
            this.cboxShapeDetect.TabIndex = 33;
            this.cboxShapeDetect.Text = "Shape Detection";
            this.cboxShapeDetect.UseVisualStyleBackColor = true;
            this.cboxShapeDetect.CheckedChanged += new System.EventHandler(this.cboxShapeDetect_CheckedChanged);
            // 
            // cboxColorTrack
            // 
            this.cboxColorTrack.AutoSize = true;
            this.cboxColorTrack.Location = new System.Drawing.Point(96, 34);
            this.cboxColorTrack.Name = "cboxColorTrack";
            this.cboxColorTrack.Size = new System.Drawing.Size(99, 17);
            this.cboxColorTrack.TabIndex = 32;
            this.cboxColorTrack.Text = "Color Detection";
            this.cboxColorTrack.UseVisualStyleBackColor = true;
            this.cboxColorTrack.CheckedChanged += new System.EventHandler(this.cboxColorTrack_CheckedChanged);
            // 
            // btnSnap
            // 
            this.btnSnap.Location = new System.Drawing.Point(5, 19);
            this.btnSnap.Margin = new System.Windows.Forms.Padding(2);
            this.btnSnap.Name = "btnSnap";
            this.btnSnap.Size = new System.Drawing.Size(75, 30);
            this.btnSnap.TabIndex = 25;
            this.btnSnap.Text = "Snap photo";
            this.btnSnap.UseVisualStyleBackColor = true;
            this.btnSnap.Click += new System.EventHandler(this.btnSnap_Click);
            // 
            // cboxObjectDetect
            // 
            this.cboxObjectDetect.AutoSize = true;
            this.cboxObjectDetect.Location = new System.Drawing.Point(96, 17);
            this.cboxObjectDetect.Name = "cboxObjectDetect";
            this.cboxObjectDetect.Size = new System.Drawing.Size(106, 17);
            this.cboxObjectDetect.TabIndex = 31;
            this.cboxObjectDetect.Text = "Object Detection";
            this.cboxObjectDetect.UseVisualStyleBackColor = true;
            this.cboxObjectDetect.CheckedChanged += new System.EventHandler(this.cboxObjectDetect_CheckedChanged);
            // 
            // ServoStatus8
            // 
            this.ServoStatus8.Image = ((System.Drawing.Image)(resources.GetObject("ServoStatus8.Image")));
            this.ServoStatus8.Location = new System.Drawing.Point(468, 408);
            this.ServoStatus8.Name = "ServoStatus8";
            this.ServoStatus8.Size = new System.Drawing.Size(24, 24);
            this.ServoStatus8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ServoStatus8.TabIndex = 30;
            this.ServoStatus8.TabStop = false;
            // 
            // ServoStatus7
            // 
            this.ServoStatus7.Image = ((System.Drawing.Image)(resources.GetObject("ServoStatus7.Image")));
            this.ServoStatus7.Location = new System.Drawing.Point(504, 10);
            this.ServoStatus7.Name = "ServoStatus7";
            this.ServoStatus7.Size = new System.Drawing.Size(24, 24);
            this.ServoStatus7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ServoStatus7.TabIndex = 24;
            this.ServoStatus7.TabStop = false;
            // 
            // gbSensor
            // 
            this.gbSensor.Controls.Add(this.labelDist);
            this.gbSensor.Location = new System.Drawing.Point(546, 465);
            this.gbSensor.Margin = new System.Windows.Forms.Padding(2);
            this.gbSensor.Name = "gbSensor";
            this.gbSensor.Padding = new System.Windows.Forms.Padding(2);
            this.gbSensor.Size = new System.Drawing.Size(126, 64);
            this.gbSensor.TabIndex = 29;
            this.gbSensor.TabStop = false;
            this.gbSensor.Text = "Distance sensor";
            // 
            // labelDist
            // 
            this.labelDist.AutoSize = true;
            this.labelDist.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDist.Location = new System.Drawing.Point(22, 21);
            this.labelDist.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDist.Name = "labelDist";
            this.labelDist.Size = new System.Drawing.Size(65, 24);
            this.labelDist.TabIndex = 28;
            this.labelDist.Text = "--- mm";
            // 
            // gboxWheel
            // 
            this.gboxWheel.Controls.Add(this.btnSetDuty);
            this.gboxWheel.Controls.Add(this.tboxDuty);
            this.gboxWheel.Controls.Add(this.labelDuty);
            this.gboxWheel.Controls.Add(this.btnStop);
            this.gboxWheel.Controls.Add(this.btnRight);
            this.gboxWheel.Controls.Add(this.btnLeft);
            this.gboxWheel.Controls.Add(this.btnBwd);
            this.gboxWheel.Controls.Add(this.btnFwd);
            this.gboxWheel.Enabled = false;
            this.gboxWheel.Location = new System.Drawing.Point(544, 362);
            this.gboxWheel.Margin = new System.Windows.Forms.Padding(2);
            this.gboxWheel.Name = "gboxWheel";
            this.gboxWheel.Padding = new System.Windows.Forms.Padding(2);
            this.gboxWheel.Size = new System.Drawing.Size(347, 100);
            this.gboxWheel.TabIndex = 27;
            this.gboxWheel.TabStop = false;
            this.gboxWheel.Text = "Wheels Control";
            // 
            // btnSetDuty
            // 
            this.btnSetDuty.Location = new System.Drawing.Point(6, 72);
            this.btnSetDuty.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetDuty.Name = "btnSetDuty";
            this.btnSetDuty.Size = new System.Drawing.Size(91, 25);
            this.btnSetDuty.TabIndex = 7;
            this.btnSetDuty.Text = "Set DutyCycle";
            this.btnSetDuty.UseVisualStyleBackColor = true;
            this.btnSetDuty.Click += new System.EventHandler(this.btnSetDuty_Click);
            // 
            // tboxDuty
            // 
            this.tboxDuty.Location = new System.Drawing.Point(6, 45);
            this.tboxDuty.Name = "tboxDuty";
            this.tboxDuty.Size = new System.Drawing.Size(91, 20);
            this.tboxDuty.TabIndex = 6;
            this.tboxDuty.WordWrap = false;
            // 
            // labelDuty
            // 
            this.labelDuty.AutoSize = true;
            this.labelDuty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDuty.ForeColor = System.Drawing.Color.Blue;
            this.labelDuty.Location = new System.Drawing.Point(27, 19);
            this.labelDuty.Name = "labelDuty";
            this.labelDuty.Size = new System.Drawing.Size(34, 20);
            this.labelDuty.TabIndex = 5;
            this.labelDuty.Text = "0%";
            this.labelDuty.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(193, 41);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(68, 25);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(269, 41);
            this.btnRight.Margin = new System.Windows.Forms.Padding(2);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(68, 25);
            this.btnRight.TabIndex = 3;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(115, 41);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(2);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(68, 25);
            this.btnLeft.TabIndex = 2;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnBwd
            // 
            this.btnBwd.Location = new System.Drawing.Point(193, 72);
            this.btnBwd.Margin = new System.Windows.Forms.Padding(2);
            this.btnBwd.Name = "btnBwd";
            this.btnBwd.Size = new System.Drawing.Size(68, 25);
            this.btnBwd.TabIndex = 1;
            this.btnBwd.Text = "Backward";
            this.btnBwd.UseVisualStyleBackColor = true;
            this.btnBwd.Click += new System.EventHandler(this.btnBwd_Click);
            // 
            // btnFwd
            // 
            this.btnFwd.Location = new System.Drawing.Point(193, 7);
            this.btnFwd.Margin = new System.Windows.Forms.Padding(2);
            this.btnFwd.Name = "btnFwd";
            this.btnFwd.Size = new System.Drawing.Size(68, 25);
            this.btnFwd.TabIndex = 0;
            this.btnFwd.Text = "Forward";
            this.btnFwd.UseVisualStyleBackColor = true;
            this.btnFwd.Click += new System.EventHandler(this.btnFwd_Click);
            // 
            // labelServo7
            // 
            this.labelServo7.AutoSize = true;
            this.labelServo7.BackColor = System.Drawing.SystemColors.Control;
            this.labelServo7.Location = new System.Drawing.Point(491, 399);
            this.labelServo7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelServo7.Name = "labelServo7";
            this.labelServo7.Size = new System.Drawing.Size(37, 13);
            this.labelServo7.TabIndex = 20;
            this.labelServo7.Text = "Tilt: 0°";
            // 
            // labelServo8
            // 
            this.labelServo8.AutoSize = true;
            this.labelServo8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelServo8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelServo8.Location = new System.Drawing.Point(14, 431);
            this.labelServo8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelServo8.Name = "labelServo8";
            this.labelServo8.Size = new System.Drawing.Size(42, 13);
            this.labelServo8.TabIndex = 21;
            this.labelServo8.Text = "Pan: 0°";
            // 
            // gbServoRemote
            // 
            this.gbServoRemote.Controls.Add(this.btnSetServo6);
            this.gbServoRemote.Controls.Add(this.tboxServo6);
            this.gbServoRemote.Controls.Add(this.btnSetServo5);
            this.gbServoRemote.Controls.Add(this.tboxServo5);
            this.gbServoRemote.Controls.Add(this.btnSetServo4);
            this.gbServoRemote.Controls.Add(this.tboxServo4);
            this.gbServoRemote.Controls.Add(this.btnSetServo3);
            this.gbServoRemote.Controls.Add(this.tboxServo3);
            this.gbServoRemote.Controls.Add(this.btnSetServo2);
            this.gbServoRemote.Controls.Add(this.tboxServo2);
            this.gbServoRemote.Controls.Add(this.btnSetServo1);
            this.gbServoRemote.Controls.Add(this.tboxServo1);
            this.gbServoRemote.Controls.Add(this.ServoStatus6);
            this.gbServoRemote.Controls.Add(this.ServoStatus5);
            this.gbServoRemote.Controls.Add(this.ServoStatus4);
            this.gbServoRemote.Controls.Add(this.ServoStatus3);
            this.gbServoRemote.Controls.Add(this.ServoStatus2);
            this.gbServoRemote.Controls.Add(this.ServoStatus1);
            this.gbServoRemote.Controls.Add(this.labelServo6);
            this.gbServoRemote.Controls.Add(this.labelServo5);
            this.gbServoRemote.Controls.Add(this.labelServo4);
            this.gbServoRemote.Controls.Add(this.labelServo3);
            this.gbServoRemote.Controls.Add(this.labelServo2);
            this.gbServoRemote.Controls.Add(this.labelServo1);
            this.gbServoRemote.Controls.Add(this.tbarServo6);
            this.gbServoRemote.Controls.Add(this.tbarServo1);
            this.gbServoRemote.Controls.Add(this.tbarServo2);
            this.gbServoRemote.Controls.Add(this.tbarServo3);
            this.gbServoRemote.Controls.Add(this.tbarServo4);
            this.gbServoRemote.Controls.Add(this.tbarServo5);
            this.gbServoRemote.Location = new System.Drawing.Point(546, 10);
            this.gbServoRemote.Name = "gbServoRemote";
            this.gbServoRemote.Size = new System.Drawing.Size(346, 347);
            this.gbServoRemote.TabIndex = 26;
            this.gbServoRemote.TabStop = false;
            this.gbServoRemote.Text = "Robot ARM RC Servos Control";
            // 
            // btnSetServo6
            // 
            this.btnSetServo6.Location = new System.Drawing.Point(268, 314);
            this.btnSetServo6.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetServo6.Name = "btnSetServo6";
            this.btnSetServo6.Size = new System.Drawing.Size(35, 20);
            this.btnSetServo6.TabIndex = 35;
            this.btnSetServo6.Text = "Set";
            this.btnSetServo6.UseVisualStyleBackColor = true;
            this.btnSetServo6.Click += new System.EventHandler(this.btnSetServo6_Click);
            // 
            // tboxServo6
            // 
            this.tboxServo6.Location = new System.Drawing.Point(213, 314);
            this.tboxServo6.Margin = new System.Windows.Forms.Padding(2);
            this.tboxServo6.Name = "tboxServo6";
            this.tboxServo6.Size = new System.Drawing.Size(51, 20);
            this.tboxServo6.TabIndex = 34;
            this.tboxServo6.Text = "0";
            // 
            // btnSetServo5
            // 
            this.btnSetServo5.Location = new System.Drawing.Point(268, 260);
            this.btnSetServo5.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetServo5.Name = "btnSetServo5";
            this.btnSetServo5.Size = new System.Drawing.Size(35, 20);
            this.btnSetServo5.TabIndex = 33;
            this.btnSetServo5.Text = "Set";
            this.btnSetServo5.UseVisualStyleBackColor = true;
            this.btnSetServo5.Click += new System.EventHandler(this.btnSetServo5_Click);
            // 
            // tboxServo5
            // 
            this.tboxServo5.Location = new System.Drawing.Point(213, 261);
            this.tboxServo5.Margin = new System.Windows.Forms.Padding(2);
            this.tboxServo5.Name = "tboxServo5";
            this.tboxServo5.Size = new System.Drawing.Size(51, 20);
            this.tboxServo5.TabIndex = 32;
            this.tboxServo5.Text = "0";
            // 
            // btnSetServo4
            // 
            this.btnSetServo4.Location = new System.Drawing.Point(268, 207);
            this.btnSetServo4.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetServo4.Name = "btnSetServo4";
            this.btnSetServo4.Size = new System.Drawing.Size(35, 20);
            this.btnSetServo4.TabIndex = 31;
            this.btnSetServo4.Text = "Set";
            this.btnSetServo4.UseVisualStyleBackColor = true;
            this.btnSetServo4.Click += new System.EventHandler(this.btnSetServo4_Click);
            // 
            // tboxServo4
            // 
            this.tboxServo4.Location = new System.Drawing.Point(213, 208);
            this.tboxServo4.Margin = new System.Windows.Forms.Padding(2);
            this.tboxServo4.Name = "tboxServo4";
            this.tboxServo4.Size = new System.Drawing.Size(51, 20);
            this.tboxServo4.TabIndex = 30;
            this.tboxServo4.Text = "0";
            // 
            // btnSetServo3
            // 
            this.btnSetServo3.Location = new System.Drawing.Point(268, 153);
            this.btnSetServo3.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetServo3.Name = "btnSetServo3";
            this.btnSetServo3.Size = new System.Drawing.Size(35, 20);
            this.btnSetServo3.TabIndex = 29;
            this.btnSetServo3.Text = "Set";
            this.btnSetServo3.UseVisualStyleBackColor = true;
            this.btnSetServo3.Click += new System.EventHandler(this.btnSetServo3_Click);
            // 
            // tboxServo3
            // 
            this.tboxServo3.Location = new System.Drawing.Point(213, 154);
            this.tboxServo3.Margin = new System.Windows.Forms.Padding(2);
            this.tboxServo3.Name = "tboxServo3";
            this.tboxServo3.Size = new System.Drawing.Size(51, 20);
            this.tboxServo3.TabIndex = 28;
            this.tboxServo3.Text = "0";
            // 
            // btnSetServo2
            // 
            this.btnSetServo2.Location = new System.Drawing.Point(268, 99);
            this.btnSetServo2.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetServo2.Name = "btnSetServo2";
            this.btnSetServo2.Size = new System.Drawing.Size(35, 20);
            this.btnSetServo2.TabIndex = 27;
            this.btnSetServo2.Text = "Set";
            this.btnSetServo2.UseVisualStyleBackColor = true;
            this.btnSetServo2.Click += new System.EventHandler(this.btnSetServo2_Click);
            // 
            // tboxServo2
            // 
            this.tboxServo2.Location = new System.Drawing.Point(213, 100);
            this.tboxServo2.Margin = new System.Windows.Forms.Padding(2);
            this.tboxServo2.Name = "tboxServo2";
            this.tboxServo2.Size = new System.Drawing.Size(51, 20);
            this.tboxServo2.TabIndex = 26;
            this.tboxServo2.Text = "0";
            // 
            // btnSetServo1
            // 
            this.btnSetServo1.Location = new System.Drawing.Point(268, 45);
            this.btnSetServo1.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetServo1.Name = "btnSetServo1";
            this.btnSetServo1.Size = new System.Drawing.Size(35, 20);
            this.btnSetServo1.TabIndex = 25;
            this.btnSetServo1.Text = "Set";
            this.btnSetServo1.UseVisualStyleBackColor = true;
            this.btnSetServo1.Click += new System.EventHandler(this.btnSetServo1_Click);
            // 
            // tboxServo1
            // 
            this.tboxServo1.Location = new System.Drawing.Point(213, 46);
            this.tboxServo1.Margin = new System.Windows.Forms.Padding(2);
            this.tboxServo1.Name = "tboxServo1";
            this.tboxServo1.Size = new System.Drawing.Size(51, 20);
            this.tboxServo1.TabIndex = 24;
            this.tboxServo1.Text = "0";
            this.tboxServo1.WordWrap = false;
            // 
            // ServoStatus6
            // 
            this.ServoStatus6.Image = ((System.Drawing.Image)(resources.GetObject("ServoStatus6.Image")));
            this.ServoStatus6.Location = new System.Drawing.Point(316, 297);
            this.ServoStatus6.Name = "ServoStatus6";
            this.ServoStatus6.Size = new System.Drawing.Size(24, 24);
            this.ServoStatus6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ServoStatus6.TabIndex = 23;
            this.ServoStatus6.TabStop = false;
            // 
            // ServoStatus5
            // 
            this.ServoStatus5.Image = ((System.Drawing.Image)(resources.GetObject("ServoStatus5.Image")));
            this.ServoStatus5.Location = new System.Drawing.Point(316, 242);
            this.ServoStatus5.Name = "ServoStatus5";
            this.ServoStatus5.Size = new System.Drawing.Size(24, 24);
            this.ServoStatus5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ServoStatus5.TabIndex = 22;
            this.ServoStatus5.TabStop = false;
            // 
            // ServoStatus4
            // 
            this.ServoStatus4.Image = ((System.Drawing.Image)(resources.GetObject("ServoStatus4.Image")));
            this.ServoStatus4.Location = new System.Drawing.Point(316, 187);
            this.ServoStatus4.Name = "ServoStatus4";
            this.ServoStatus4.Size = new System.Drawing.Size(24, 24);
            this.ServoStatus4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ServoStatus4.TabIndex = 21;
            this.ServoStatus4.TabStop = false;
            // 
            // ServoStatus3
            // 
            this.ServoStatus3.Image = ((System.Drawing.Image)(resources.GetObject("ServoStatus3.Image")));
            this.ServoStatus3.Location = new System.Drawing.Point(316, 133);
            this.ServoStatus3.Name = "ServoStatus3";
            this.ServoStatus3.Size = new System.Drawing.Size(24, 24);
            this.ServoStatus3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ServoStatus3.TabIndex = 20;
            this.ServoStatus3.TabStop = false;
            // 
            // ServoStatus2
            // 
            this.ServoStatus2.Image = ((System.Drawing.Image)(resources.GetObject("ServoStatus2.Image")));
            this.ServoStatus2.Location = new System.Drawing.Point(316, 79);
            this.ServoStatus2.Name = "ServoStatus2";
            this.ServoStatus2.Size = new System.Drawing.Size(24, 24);
            this.ServoStatus2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ServoStatus2.TabIndex = 19;
            this.ServoStatus2.TabStop = false;
            // 
            // ServoStatus1
            // 
            this.ServoStatus1.Image = ((System.Drawing.Image)(resources.GetObject("ServoStatus1.Image")));
            this.ServoStatus1.Location = new System.Drawing.Point(316, 25);
            this.ServoStatus1.Name = "ServoStatus1";
            this.ServoStatus1.Size = new System.Drawing.Size(24, 24);
            this.ServoStatus1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ServoStatus1.TabIndex = 18;
            this.ServoStatus1.TabStop = false;
            // 
            // labelServo6
            // 
            this.labelServo6.AutoSize = true;
            this.labelServo6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelServo6.Location = new System.Drawing.Point(25, 319);
            this.labelServo6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelServo6.Name = "labelServo6";
            this.labelServo6.Size = new System.Drawing.Size(70, 13);
            this.labelServo6.TabIndex = 17;
            this.labelServo6.Text = "Auxiliary 2: 0°";
            // 
            // labelServo5
            // 
            this.labelServo5.AutoSize = true;
            this.labelServo5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelServo5.Location = new System.Drawing.Point(25, 266);
            this.labelServo5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelServo5.Name = "labelServo5";
            this.labelServo5.Size = new System.Drawing.Size(70, 13);
            this.labelServo5.TabIndex = 16;
            this.labelServo5.Text = "Auxiliary 1: 0°";
            // 
            // labelServo4
            // 
            this.labelServo4.AutoSize = true;
            this.labelServo4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelServo4.Location = new System.Drawing.Point(25, 211);
            this.labelServo4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelServo4.Name = "labelServo4";
            this.labelServo4.Size = new System.Drawing.Size(57, 13);
            this.labelServo4.TabIndex = 15;
            this.labelServo4.Text = "Gripper: 0°";
            // 
            // labelServo3
            // 
            this.labelServo3.AutoSize = true;
            this.labelServo3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelServo3.Location = new System.Drawing.Point(25, 157);
            this.labelServo3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelServo3.Name = "labelServo3";
            this.labelServo3.Size = new System.Drawing.Size(100, 13);
            this.labelServo3.TabIndex = 14;
            this.labelServo3.Text = "Gripper Rotation: 0°";
            // 
            // labelServo2
            // 
            this.labelServo2.AutoSize = true;
            this.labelServo2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelServo2.Location = new System.Drawing.Point(25, 104);
            this.labelServo2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelServo2.Name = "labelServo2";
            this.labelServo2.Size = new System.Drawing.Size(77, 13);
            this.labelServo2.TabIndex = 13;
            this.labelServo2.Text = "Upper Joint: 0°";
            // 
            // labelServo1
            // 
            this.labelServo1.AutoSize = true;
            this.labelServo1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelServo1.Location = new System.Drawing.Point(25, 49);
            this.labelServo1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelServo1.Name = "labelServo1";
            this.labelServo1.Size = new System.Drawing.Size(77, 13);
            this.labelServo1.TabIndex = 12;
            this.labelServo1.Text = "Lower Joint: 0°";
            // 
            // tbarServo6
            // 
            this.tbarServo6.AutoSize = false;
            this.tbarServo6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbarServo6.Location = new System.Drawing.Point(18, 288);
            this.tbarServo6.Margin = new System.Windows.Forms.Padding(2);
            this.tbarServo6.Maximum = 18000;
            this.tbarServo6.Minimum = -18000;
            this.tbarServo6.Name = "tbarServo6";
            this.tbarServo6.Size = new System.Drawing.Size(293, 50);
            this.tbarServo6.TabIndex = 11;
            this.tbarServo6.ValueChanged += new System.EventHandler(this.tbarServo6_ValueChanged);
            // 
            // tbarServo1
            // 
            this.tbarServo1.AutoSize = false;
            this.tbarServo1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbarServo1.Location = new System.Drawing.Point(18, 18);
            this.tbarServo1.Margin = new System.Windows.Forms.Padding(2);
            this.tbarServo1.Maximum = 18000;
            this.tbarServo1.Minimum = -18000;
            this.tbarServo1.Name = "tbarServo1";
            this.tbarServo1.Size = new System.Drawing.Size(293, 50);
            this.tbarServo1.TabIndex = 6;
            this.tbarServo1.ValueChanged += new System.EventHandler(this.tbarServo1_ValueChanged);
            // 
            // tbarServo2
            // 
            this.tbarServo2.AutoSize = false;
            this.tbarServo2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbarServo2.Location = new System.Drawing.Point(18, 72);
            this.tbarServo2.Margin = new System.Windows.Forms.Padding(2);
            this.tbarServo2.Maximum = 18000;
            this.tbarServo2.Minimum = -18000;
            this.tbarServo2.Name = "tbarServo2";
            this.tbarServo2.Size = new System.Drawing.Size(293, 50);
            this.tbarServo2.TabIndex = 7;
            this.tbarServo2.ValueChanged += new System.EventHandler(this.tbarServo2_ValueChanged);
            // 
            // tbarServo3
            // 
            this.tbarServo3.AutoSize = false;
            this.tbarServo3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbarServo3.Location = new System.Drawing.Point(18, 126);
            this.tbarServo3.Margin = new System.Windows.Forms.Padding(2);
            this.tbarServo3.Maximum = 18000;
            this.tbarServo3.Minimum = -18000;
            this.tbarServo3.Name = "tbarServo3";
            this.tbarServo3.Size = new System.Drawing.Size(293, 50);
            this.tbarServo3.TabIndex = 8;
            this.tbarServo3.ValueChanged += new System.EventHandler(this.tbarServo3_ValueChanged);
            // 
            // tbarServo4
            // 
            this.tbarServo4.AutoSize = false;
            this.tbarServo4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbarServo4.Location = new System.Drawing.Point(18, 180);
            this.tbarServo4.Margin = new System.Windows.Forms.Padding(2);
            this.tbarServo4.Maximum = 18000;
            this.tbarServo4.Minimum = -18000;
            this.tbarServo4.Name = "tbarServo4";
            this.tbarServo4.Size = new System.Drawing.Size(293, 50);
            this.tbarServo4.TabIndex = 9;
            this.tbarServo4.ValueChanged += new System.EventHandler(this.tbarServo4_ValueChanged);
            // 
            // tbarServo5
            // 
            this.tbarServo5.AutoSize = false;
            this.tbarServo5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbarServo5.Location = new System.Drawing.Point(18, 234);
            this.tbarServo5.Margin = new System.Windows.Forms.Padding(2);
            this.tbarServo5.Maximum = 18000;
            this.tbarServo5.Minimum = -18000;
            this.tbarServo5.Name = "tbarServo5";
            this.tbarServo5.Size = new System.Drawing.Size(293, 50);
            this.tbarServo5.TabIndex = 10;
            this.tbarServo5.ValueChanged += new System.EventHandler(this.tbarServo5_ValueChanged);
            // 
            // tbarServo8
            // 
            this.tbarServo8.AutoSize = false;
            this.tbarServo8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbarServo8.Location = new System.Drawing.Point(6, 399);
            this.tbarServo8.Margin = new System.Windows.Forms.Padding(2);
            this.tbarServo8.Maximum = 18000;
            this.tbarServo8.Minimum = -18000;
            this.tbarServo8.Name = "tbarServo8";
            this.tbarServo8.Size = new System.Drawing.Size(457, 50);
            this.tbarServo8.TabIndex = 19;
            this.tbarServo8.ValueChanged += new System.EventHandler(this.tbarServo8_ValueChanged);
            // 
            // tbarServo7
            // 
            this.tbarServo7.AutoSize = false;
            this.tbarServo7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbarServo7.Location = new System.Drawing.Point(495, 39);
            this.tbarServo7.Margin = new System.Windows.Forms.Padding(2);
            this.tbarServo7.Maximum = 18000;
            this.tbarServo7.Minimum = -18000;
            this.tbarServo7.Name = "tbarServo7";
            this.tbarServo7.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbarServo7.Size = new System.Drawing.Size(46, 354);
            this.tbarServo7.TabIndex = 18;
            this.tbarServo7.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbarServo7.ValueChanged += new System.EventHandler(this.tbarServo7_ValueChanged);
            // 
            // cameraWindow
            // 
            this.cameraWindow.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cameraWindow.Camera = null;
            this.cameraWindow.Location = new System.Drawing.Point(6, 3);
            this.cameraWindow.Margin = new System.Windows.Forms.Padding(0);
            this.cameraWindow.Name = "cameraWindow";
            this.cameraWindow.Size = new System.Drawing.Size(480, 390);
            this.cameraWindow.TabIndex = 0;
            this.cameraWindow.Text = "cameraWindow1";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMainControl);
            this.tabControl.Controls.Add(this.tabFKine);
            this.tabControl.Controls.Add(this.tabIKine);
            this.tabControl.Controls.Add(this.tabAlgo);
            this.tabControl.Location = new System.Drawing.Point(14, 33);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(908, 554);
            this.tabControl.TabIndex = 2;
            // 
            // tabIKine
            // 
            this.tabIKine.Controls.Add(this.gbIKineSol);
            this.tabIKine.Controls.Add(this.gbIKine);
            this.tabIKine.Location = new System.Drawing.Point(4, 22);
            this.tabIKine.Margin = new System.Windows.Forms.Padding(2);
            this.tabIKine.Name = "tabIKine";
            this.tabIKine.Padding = new System.Windows.Forms.Padding(2);
            this.tabIKine.Size = new System.Drawing.Size(900, 528);
            this.tabIKine.TabIndex = 3;
            this.tabIKine.Text = "Inverse Kinematics";
            this.tabIKine.UseVisualStyleBackColor = true;
            // 
            // gbIKineSol
            // 
            this.gbIKineSol.Controls.Add(this.labelTeta3Inv);
            this.gbIKineSol.Controls.Add(this.labelTeta2Inv);
            this.gbIKineSol.Controls.Add(this.labelTeta1Inv);
            this.gbIKineSol.Controls.Add(this.tbTeta3Inv);
            this.gbIKineSol.Controls.Add(this.tbTeta2Inv);
            this.gbIKineSol.Controls.Add(this.tbTeta1Inv);
            this.gbIKineSol.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbIKineSol.Location = new System.Drawing.Point(424, 61);
            this.gbIKineSol.Margin = new System.Windows.Forms.Padding(2);
            this.gbIKineSol.Name = "gbIKineSol";
            this.gbIKineSol.Padding = new System.Windows.Forms.Padding(2);
            this.gbIKineSol.Size = new System.Drawing.Size(211, 113);
            this.gbIKineSol.TabIndex = 5;
            this.gbIKineSol.TabStop = false;
            this.gbIKineSol.Text = "Inverse Kinematics Solution";
            // 
            // labelTeta3Inv
            // 
            this.labelTeta3Inv.AutoSize = true;
            this.labelTeta3Inv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeta3Inv.Location = new System.Drawing.Point(12, 79);
            this.labelTeta3Inv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTeta3Inv.Name = "labelTeta3Inv";
            this.labelTeta3Inv.Size = new System.Drawing.Size(31, 17);
            this.labelTeta3Inv.TabIndex = 14;
            this.labelTeta3Inv.Text = "θ3:";
            // 
            // labelTeta2Inv
            // 
            this.labelTeta2Inv.AutoSize = true;
            this.labelTeta2Inv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeta2Inv.Location = new System.Drawing.Point(12, 54);
            this.labelTeta2Inv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTeta2Inv.Name = "labelTeta2Inv";
            this.labelTeta2Inv.Size = new System.Drawing.Size(31, 17);
            this.labelTeta2Inv.TabIndex = 13;
            this.labelTeta2Inv.Text = "θ2:";
            // 
            // labelTeta1Inv
            // 
            this.labelTeta1Inv.AutoSize = true;
            this.labelTeta1Inv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeta1Inv.Location = new System.Drawing.Point(12, 28);
            this.labelTeta1Inv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTeta1Inv.Name = "labelTeta1Inv";
            this.labelTeta1Inv.Size = new System.Drawing.Size(31, 17);
            this.labelTeta1Inv.TabIndex = 12;
            this.labelTeta1Inv.Text = "θ1:";
            // 
            // tbTeta3Inv
            // 
            this.tbTeta3Inv.Enabled = false;
            this.tbTeta3Inv.Location = new System.Drawing.Point(51, 76);
            this.tbTeta3Inv.Margin = new System.Windows.Forms.Padding(2);
            this.tbTeta3Inv.Multiline = true;
            this.tbTeta3Inv.Name = "tbTeta3Inv";
            this.tbTeta3Inv.Size = new System.Drawing.Size(131, 24);
            this.tbTeta3Inv.TabIndex = 11;
            // 
            // tbTeta2Inv
            // 
            this.tbTeta2Inv.Enabled = false;
            this.tbTeta2Inv.Location = new System.Drawing.Point(51, 51);
            this.tbTeta2Inv.Margin = new System.Windows.Forms.Padding(2);
            this.tbTeta2Inv.Multiline = true;
            this.tbTeta2Inv.Name = "tbTeta2Inv";
            this.tbTeta2Inv.Size = new System.Drawing.Size(131, 24);
            this.tbTeta2Inv.TabIndex = 10;
            // 
            // tbTeta1Inv
            // 
            this.tbTeta1Inv.Enabled = false;
            this.tbTeta1Inv.Location = new System.Drawing.Point(51, 25);
            this.tbTeta1Inv.Margin = new System.Windows.Forms.Padding(2);
            this.tbTeta1Inv.Multiline = true;
            this.tbTeta1Inv.Name = "tbTeta1Inv";
            this.tbTeta1Inv.Size = new System.Drawing.Size(131, 24);
            this.tbTeta1Inv.TabIndex = 9;
            // 
            // gbIKine
            // 
            this.gbIKine.Controls.Add(this.btnRstIKine);
            this.gbIKine.Controls.Add(this.labelIKine);
            this.gbIKine.Controls.Add(this.btnRunIKine);
            this.gbIKine.Controls.Add(this.labelPzInv);
            this.gbIKine.Controls.Add(this.labelPyInv);
            this.gbIKine.Controls.Add(this.labelPxInv);
            this.gbIKine.Controls.Add(this.tbPzInv);
            this.gbIKine.Controls.Add(this.tbPyInv);
            this.gbIKine.Controls.Add(this.tbPxInv);
            this.gbIKine.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbIKine.Location = new System.Drawing.Point(124, 47);
            this.gbIKine.Margin = new System.Windows.Forms.Padding(2);
            this.gbIKine.Name = "gbIKine";
            this.gbIKine.Padding = new System.Windows.Forms.Padding(2);
            this.gbIKine.Size = new System.Drawing.Size(239, 180);
            this.gbIKine.TabIndex = 4;
            this.gbIKine.TabStop = false;
            this.gbIKine.Text = "Inverse Kinematics";
            // 
            // btnRstIKine
            // 
            this.btnRstIKine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRstIKine.Location = new System.Drawing.Point(12, 139);
            this.btnRstIKine.Margin = new System.Windows.Forms.Padding(2);
            this.btnRstIKine.Name = "btnRstIKine";
            this.btnRstIKine.Size = new System.Drawing.Size(106, 29);
            this.btnRstIKine.TabIndex = 11;
            this.btnRstIKine.Text = "Reset";
            this.btnRstIKine.UseVisualStyleBackColor = true;
            this.btnRstIKine.Click += new System.EventHandler(this.btnRstIKine_Click);
            // 
            // labelIKine
            // 
            this.labelIKine.AutoSize = true;
            this.labelIKine.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIKine.ForeColor = System.Drawing.Color.Black;
            this.labelIKine.Location = new System.Drawing.Point(10, 25);
            this.labelIKine.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIKine.Name = "labelIKine";
            this.labelIKine.Size = new System.Drawing.Size(152, 13);
            this.labelIKine.TabIndex = 10;
            this.labelIKine.Text = "Key In Px Py Values Here";
            // 
            // btnRunIKine
            // 
            this.btnRunIKine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunIKine.Location = new System.Drawing.Point(122, 139);
            this.btnRunIKine.Margin = new System.Windows.Forms.Padding(2);
            this.btnRunIKine.Name = "btnRunIKine";
            this.btnRunIKine.Size = new System.Drawing.Size(106, 29);
            this.btnRunIKine.TabIndex = 9;
            this.btnRunIKine.Text = "Run";
            this.btnRunIKine.UseVisualStyleBackColor = true;
            this.btnRunIKine.Click += new System.EventHandler(this.btnRunIKine_Click);
            // 
            // labelPzInv
            // 
            this.labelPzInv.AutoSize = true;
            this.labelPzInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPzInv.Location = new System.Drawing.Point(34, 110);
            this.labelPzInv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPzInv.Name = "labelPzInv";
            this.labelPzInv.Size = new System.Drawing.Size(31, 17);
            this.labelPzInv.TabIndex = 8;
            this.labelPzInv.Text = "Pz:";
            // 
            // labelPyInv
            // 
            this.labelPyInv.AutoSize = true;
            this.labelPyInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPyInv.Location = new System.Drawing.Point(34, 86);
            this.labelPyInv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPyInv.Name = "labelPyInv";
            this.labelPyInv.Size = new System.Drawing.Size(31, 17);
            this.labelPyInv.TabIndex = 7;
            this.labelPyInv.Text = "Py:";
            // 
            // labelPxInv
            // 
            this.labelPxInv.AutoSize = true;
            this.labelPxInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPxInv.Location = new System.Drawing.Point(34, 59);
            this.labelPxInv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPxInv.Name = "labelPxInv";
            this.labelPxInv.Size = new System.Drawing.Size(30, 17);
            this.labelPxInv.TabIndex = 6;
            this.labelPxInv.Text = "Px:";
            // 
            // tbPzInv
            // 
            this.tbPzInv.Enabled = false;
            this.tbPzInv.Location = new System.Drawing.Point(73, 108);
            this.tbPzInv.Margin = new System.Windows.Forms.Padding(2);
            this.tbPzInv.Multiline = true;
            this.tbPzInv.Name = "tbPzInv";
            this.tbPzInv.Size = new System.Drawing.Size(131, 24);
            this.tbPzInv.TabIndex = 5;
            // 
            // tbPyInv
            // 
            this.tbPyInv.Location = new System.Drawing.Point(73, 83);
            this.tbPyInv.Margin = new System.Windows.Forms.Padding(2);
            this.tbPyInv.Multiline = true;
            this.tbPyInv.Name = "tbPyInv";
            this.tbPyInv.Size = new System.Drawing.Size(131, 24);
            this.tbPyInv.TabIndex = 4;
            // 
            // tbPxInv
            // 
            this.tbPxInv.Location = new System.Drawing.Point(73, 57);
            this.tbPxInv.Margin = new System.Windows.Forms.Padding(2);
            this.tbPxInv.Multiline = true;
            this.tbPxInv.Name = "tbPxInv";
            this.tbPxInv.Size = new System.Drawing.Size(131, 24);
            this.tbPxInv.TabIndex = 3;
            // 
            // tabAlgo
            // 
            this.tabAlgo.Controls.Add(this.gbFunc);
            this.tabAlgo.Controls.Add(this.gbLine);
            this.tabAlgo.Location = new System.Drawing.Point(4, 22);
            this.tabAlgo.Margin = new System.Windows.Forms.Padding(2);
            this.tabAlgo.Name = "tabAlgo";
            this.tabAlgo.Padding = new System.Windows.Forms.Padding(2);
            this.tabAlgo.Size = new System.Drawing.Size(900, 528);
            this.tabAlgo.TabIndex = 4;
            this.tabAlgo.Text = "Movement Algorithm";
            this.tabAlgo.UseVisualStyleBackColor = true;
            // 
            // gbFunc
            // 
            this.gbFunc.Controls.Add(this.button1);
            this.gbFunc.Controls.Add(this.labelFuncSts);
            this.gbFunc.Controls.Add(this.btnRstFunc);
            this.gbFunc.Controls.Add(this.btnRunSquare);
            this.gbFunc.Controls.Add(this.btnRunPickPlace);
            this.gbFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFunc.Location = new System.Drawing.Point(199, 334);
            this.gbFunc.Margin = new System.Windows.Forms.Padding(2);
            this.gbFunc.Name = "gbFunc";
            this.gbFunc.Padding = new System.Windows.Forms.Padding(2);
            this.gbFunc.Size = new System.Drawing.Size(501, 150);
            this.gbFunc.TabIndex = 19;
            this.gbFunc.TabStop = false;
            this.gbFunc.Text = "Functions";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(344, 26);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 46);
            this.button1.TabIndex = 32;
            this.button1.Text = "1M";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelFuncSts
            // 
            this.labelFuncSts.AutoSize = true;
            this.labelFuncSts.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFuncSts.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.labelFuncSts.Location = new System.Drawing.Point(232, 96);
            this.labelFuncSts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFuncSts.Name = "labelFuncSts";
            this.labelFuncSts.Size = new System.Drawing.Size(36, 13);
            this.labelFuncSts.TabIndex = 31;
            this.labelFuncSts.Text = "Done!";
            this.labelFuncSts.Visible = false;
            // 
            // btnRstFunc
            // 
            this.btnRstFunc.BackColor = System.Drawing.Color.Lime;
            this.btnRstFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRstFunc.Location = new System.Drawing.Point(398, 96);
            this.btnRstFunc.Margin = new System.Windows.Forms.Padding(2);
            this.btnRstFunc.Name = "btnRstFunc";
            this.btnRstFunc.Size = new System.Drawing.Size(74, 29);
            this.btnRstFunc.TabIndex = 28;
            this.btnRstFunc.Text = "Reset";
            this.btnRstFunc.UseVisualStyleBackColor = false;
            this.btnRstFunc.Click += new System.EventHandler(this.btnRstFunc_Click);
            // 
            // btnRunSquare
            // 
            this.btnRunSquare.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunSquare.Location = new System.Drawing.Point(178, 26);
            this.btnRunSquare.Margin = new System.Windows.Forms.Padding(2);
            this.btnRunSquare.Name = "btnRunSquare";
            this.btnRunSquare.Size = new System.Drawing.Size(142, 46);
            this.btnRunSquare.TabIndex = 28;
            this.btnRunSquare.Text = "SQUARE DRAW";
            this.btnRunSquare.UseVisualStyleBackColor = true;
            this.btnRunSquare.Click += new System.EventHandler(this.btnRunSquare_Click);
            // 
            // btnRunPickPlace
            // 
            this.btnRunPickPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunPickPlace.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunPickPlace.Location = new System.Drawing.Point(28, 26);
            this.btnRunPickPlace.Margin = new System.Windows.Forms.Padding(2);
            this.btnRunPickPlace.Name = "btnRunPickPlace";
            this.btnRunPickPlace.Size = new System.Drawing.Size(126, 46);
            this.btnRunPickPlace.TabIndex = 27;
            this.btnRunPickPlace.Text = "PICK \'N\' PLACE";
            this.btnRunPickPlace.UseVisualStyleBackColor = true;
            this.btnRunPickPlace.Click += new System.EventHandler(this.btnRunPickPlace_Click);
            // 
            // gbLine
            // 
            this.gbLine.Controls.Add(this.labelPxLine13);
            this.gbLine.Controls.Add(this.labelPxLine12);
            this.gbLine.Controls.Add(this.labelPoint13);
            this.gbLine.Controls.Add(this.labelPoint12);
            this.gbLine.Controls.Add(this.labelPoint11);
            this.gbLine.Controls.Add(this.labelLineSts);
            this.gbLine.Controls.Add(this.btnRstLine);
            this.gbLine.Controls.Add(this.labelPzLine13);
            this.gbLine.Controls.Add(this.btnRunLine);
            this.gbLine.Controls.Add(this.labelPyLine13);
            this.gbLine.Controls.Add(this.tbPz13);
            this.gbLine.Controls.Add(this.tbPy13);
            this.gbLine.Controls.Add(this.tbPx13);
            this.gbLine.Controls.Add(this.labelPzLine12);
            this.gbLine.Controls.Add(this.labelPyLine12);
            this.gbLine.Controls.Add(this.tbPz12);
            this.gbLine.Controls.Add(this.tbPy12);
            this.gbLine.Controls.Add(this.tbPx12);
            this.gbLine.Controls.Add(this.labelPzLine11);
            this.gbLine.Controls.Add(this.labelPyLine11);
            this.gbLine.Controls.Add(this.labelPxLine11);
            this.gbLine.Controls.Add(this.tbPz11);
            this.gbLine.Controls.Add(this.tbPy11);
            this.gbLine.Controls.Add(this.tbPx11);
            this.gbLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLine.Location = new System.Drawing.Point(199, 65);
            this.gbLine.Margin = new System.Windows.Forms.Padding(2);
            this.gbLine.Name = "gbLine";
            this.gbLine.Padding = new System.Windows.Forms.Padding(2);
            this.gbLine.Size = new System.Drawing.Size(501, 166);
            this.gbLine.TabIndex = 18;
            this.gbLine.TabStop = false;
            this.gbLine.Text = "Draw Line";
            this.gbLine.Enter += new System.EventHandler(this.gbLine_Enter);
            // 
            // labelPxLine13
            // 
            this.labelPxLine13.AutoSize = true;
            this.labelPxLine13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPxLine13.Location = new System.Drawing.Point(265, 30);
            this.labelPxLine13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPxLine13.Name = "labelPxLine13";
            this.labelPxLine13.Size = new System.Drawing.Size(30, 17);
            this.labelPxLine13.TabIndex = 32;
            this.labelPxLine13.Text = "Px:";
            // 
            // labelPxLine12
            // 
            this.labelPxLine12.AutoSize = true;
            this.labelPxLine12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPxLine12.Location = new System.Drawing.Point(146, 30);
            this.labelPxLine12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPxLine12.Name = "labelPxLine12";
            this.labelPxLine12.Size = new System.Drawing.Size(30, 17);
            this.labelPxLine12.TabIndex = 31;
            this.labelPxLine12.Text = "Px:";
            // 
            // labelPoint13
            // 
            this.labelPoint13.AutoSize = true;
            this.labelPoint13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPoint13.Location = new System.Drawing.Point(316, 9);
            this.labelPoint13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPoint13.Name = "labelPoint13";
            this.labelPoint13.Size = new System.Drawing.Size(25, 13);
            this.labelPoint13.TabIndex = 30;
            this.labelPoint13.Text = "1.3";
            // 
            // labelPoint12
            // 
            this.labelPoint12.AutoSize = true;
            this.labelPoint12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPoint12.Location = new System.Drawing.Point(196, 9);
            this.labelPoint12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPoint12.Name = "labelPoint12";
            this.labelPoint12.Size = new System.Drawing.Size(25, 13);
            this.labelPoint12.TabIndex = 29;
            this.labelPoint12.Text = "1.2";
            // 
            // labelPoint11
            // 
            this.labelPoint11.AutoSize = true;
            this.labelPoint11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPoint11.Location = new System.Drawing.Point(76, 9);
            this.labelPoint11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPoint11.Name = "labelPoint11";
            this.labelPoint11.Size = new System.Drawing.Size(25, 13);
            this.labelPoint11.TabIndex = 28;
            this.labelPoint11.Text = "1.1";
            // 
            // labelLineSts
            // 
            this.labelLineSts.AutoSize = true;
            this.labelLineSts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLineSts.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.labelLineSts.Location = new System.Drawing.Point(191, 119);
            this.labelLineSts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLineSts.Name = "labelLineSts";
            this.labelLineSts.Size = new System.Drawing.Size(113, 17);
            this.labelLineSts.TabIndex = 27;
            this.labelLineSts.Text = "Done Drawing!";
            this.labelLineSts.Visible = false;
            // 
            // btnRstLine
            // 
            this.btnRstLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRstLine.Location = new System.Drawing.Point(380, 70);
            this.btnRstLine.Margin = new System.Windows.Forms.Padding(2);
            this.btnRstLine.Name = "btnRstLine";
            this.btnRstLine.Size = new System.Drawing.Size(106, 29);
            this.btnRstLine.TabIndex = 12;
            this.btnRstLine.Text = "Reset";
            this.btnRstLine.UseVisualStyleBackColor = true;
            this.btnRstLine.Click += new System.EventHandler(this.btnRstLine_Click);
            // 
            // labelPzLine13
            // 
            this.labelPzLine13.AutoSize = true;
            this.labelPzLine13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPzLine13.Location = new System.Drawing.Point(264, 79);
            this.labelPzLine13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPzLine13.Name = "labelPzLine13";
            this.labelPzLine13.Size = new System.Drawing.Size(31, 17);
            this.labelPzLine13.TabIndex = 26;
            this.labelPzLine13.Text = "Pz:";
            // 
            // btnRunLine
            // 
            this.btnRunLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunLine.Location = new System.Drawing.Point(380, 30);
            this.btnRunLine.Margin = new System.Windows.Forms.Padding(2);
            this.btnRunLine.Name = "btnRunLine";
            this.btnRunLine.Size = new System.Drawing.Size(106, 29);
            this.btnRunLine.TabIndex = 12;
            this.btnRunLine.Text = "Move Line";
            this.btnRunLine.UseVisualStyleBackColor = true;
            this.btnRunLine.Click += new System.EventHandler(this.btnRunLine_Click);
            // 
            // labelPyLine13
            // 
            this.labelPyLine13.AutoSize = true;
            this.labelPyLine13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPyLine13.Location = new System.Drawing.Point(265, 54);
            this.labelPyLine13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPyLine13.Name = "labelPyLine13";
            this.labelPyLine13.Size = new System.Drawing.Size(31, 17);
            this.labelPyLine13.TabIndex = 25;
            this.labelPyLine13.Text = "Py:";
            // 
            // tbPz13
            // 
            this.tbPz13.Enabled = false;
            this.tbPz13.Location = new System.Drawing.Point(296, 76);
            this.tbPz13.Margin = new System.Windows.Forms.Padding(2);
            this.tbPz13.Multiline = true;
            this.tbPz13.Name = "tbPz13";
            this.tbPz13.Size = new System.Drawing.Size(60, 24);
            this.tbPz13.TabIndex = 23;
            this.tbPz13.Text = "0";
            // 
            // tbPy13
            // 
            this.tbPy13.Location = new System.Drawing.Point(296, 51);
            this.tbPy13.Margin = new System.Windows.Forms.Padding(2);
            this.tbPy13.Multiline = true;
            this.tbPy13.Name = "tbPy13";
            this.tbPy13.Size = new System.Drawing.Size(60, 24);
            this.tbPy13.TabIndex = 22;
            // 
            // tbPx13
            // 
            this.tbPx13.Location = new System.Drawing.Point(296, 25);
            this.tbPx13.Margin = new System.Windows.Forms.Padding(2);
            this.tbPx13.Multiline = true;
            this.tbPx13.Name = "tbPx13";
            this.tbPx13.Size = new System.Drawing.Size(60, 24);
            this.tbPx13.TabIndex = 21;
            // 
            // labelPzLine12
            // 
            this.labelPzLine12.AutoSize = true;
            this.labelPzLine12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPzLine12.Location = new System.Drawing.Point(146, 79);
            this.labelPzLine12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPzLine12.Name = "labelPzLine12";
            this.labelPzLine12.Size = new System.Drawing.Size(31, 17);
            this.labelPzLine12.TabIndex = 20;
            this.labelPzLine12.Text = "Pz:";
            // 
            // labelPyLine12
            // 
            this.labelPyLine12.AutoSize = true;
            this.labelPyLine12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPyLine12.Location = new System.Drawing.Point(146, 54);
            this.labelPyLine12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPyLine12.Name = "labelPyLine12";
            this.labelPyLine12.Size = new System.Drawing.Size(31, 17);
            this.labelPyLine12.TabIndex = 19;
            this.labelPyLine12.Text = "Py:";
            // 
            // tbPz12
            // 
            this.tbPz12.Enabled = false;
            this.tbPz12.Location = new System.Drawing.Point(178, 76);
            this.tbPz12.Margin = new System.Windows.Forms.Padding(2);
            this.tbPz12.Multiline = true;
            this.tbPz12.Name = "tbPz12";
            this.tbPz12.Size = new System.Drawing.Size(60, 24);
            this.tbPz12.TabIndex = 17;
            this.tbPz12.Text = "0";
            // 
            // tbPy12
            // 
            this.tbPy12.Enabled = false;
            this.tbPy12.Location = new System.Drawing.Point(178, 51);
            this.tbPy12.Margin = new System.Windows.Forms.Padding(2);
            this.tbPy12.Multiline = true;
            this.tbPy12.Name = "tbPy12";
            this.tbPy12.Size = new System.Drawing.Size(60, 24);
            this.tbPy12.TabIndex = 16;
            // 
            // tbPx12
            // 
            this.tbPx12.Enabled = false;
            this.tbPx12.Location = new System.Drawing.Point(178, 25);
            this.tbPx12.Margin = new System.Windows.Forms.Padding(2);
            this.tbPx12.Multiline = true;
            this.tbPx12.Name = "tbPx12";
            this.tbPx12.Size = new System.Drawing.Size(60, 24);
            this.tbPx12.TabIndex = 15;
            // 
            // labelPzLine11
            // 
            this.labelPzLine11.AutoSize = true;
            this.labelPzLine11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPzLine11.Location = new System.Drawing.Point(25, 79);
            this.labelPzLine11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPzLine11.Name = "labelPzLine11";
            this.labelPzLine11.Size = new System.Drawing.Size(31, 17);
            this.labelPzLine11.TabIndex = 14;
            this.labelPzLine11.Text = "Pz:";
            // 
            // labelPyLine11
            // 
            this.labelPyLine11.AutoSize = true;
            this.labelPyLine11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPyLine11.Location = new System.Drawing.Point(25, 54);
            this.labelPyLine11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPyLine11.Name = "labelPyLine11";
            this.labelPyLine11.Size = new System.Drawing.Size(31, 17);
            this.labelPyLine11.TabIndex = 13;
            this.labelPyLine11.Text = "Py:";
            // 
            // labelPxLine11
            // 
            this.labelPxLine11.AutoSize = true;
            this.labelPxLine11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPxLine11.Location = new System.Drawing.Point(23, 30);
            this.labelPxLine11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPxLine11.Name = "labelPxLine11";
            this.labelPxLine11.Size = new System.Drawing.Size(30, 17);
            this.labelPxLine11.TabIndex = 12;
            this.labelPxLine11.Text = "Px:";
            // 
            // tbPz11
            // 
            this.tbPz11.Enabled = false;
            this.tbPz11.Location = new System.Drawing.Point(57, 76);
            this.tbPz11.Margin = new System.Windows.Forms.Padding(2);
            this.tbPz11.Multiline = true;
            this.tbPz11.Name = "tbPz11";
            this.tbPz11.Size = new System.Drawing.Size(60, 24);
            this.tbPz11.TabIndex = 11;
            this.tbPz11.TabStop = false;
            this.tbPz11.Text = "0";
            // 
            // tbPy11
            // 
            this.tbPy11.Location = new System.Drawing.Point(57, 51);
            this.tbPy11.Margin = new System.Windows.Forms.Padding(2);
            this.tbPy11.Multiline = true;
            this.tbPy11.Name = "tbPy11";
            this.tbPy11.Size = new System.Drawing.Size(60, 24);
            this.tbPy11.TabIndex = 10;
            // 
            // tbPx11
            // 
            this.tbPx11.Location = new System.Drawing.Point(57, 25);
            this.tbPx11.Margin = new System.Windows.Forms.Padding(2);
            this.tbPx11.Multiline = true;
            this.tbPx11.Name = "tbPx11";
            this.tbPx11.Size = new System.Drawing.Size(60, 24);
            this.tbPx11.TabIndex = 9;
            // 
            // tbRad
            // 
            this.tbRad.Location = new System.Drawing.Point(332, 31);
            this.tbRad.Multiline = true;
            this.tbRad.Name = "tbRad";
            this.tbRad.Size = new System.Drawing.Size(67, 28);
            this.tbRad.TabIndex = 33;
            // 
            // lblsum1
            // 
            this.lblsum1.AutoSize = true;
            this.lblsum1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsum1.ForeColor = System.Drawing.Color.Black;
            this.lblsum1.Location = new System.Drawing.Point(717, 600);
            this.lblsum1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblsum1.Name = "lblsum1";
            this.lblsum1.Size = new System.Drawing.Size(51, 18);
            this.lblsum1.TabIndex = 39;
            this.lblsum1.Text = "sum1";
            this.lblsum1.Visible = false;
            // 
            // lblsum2
            // 
            this.lblsum2.AutoSize = true;
            this.lblsum2.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsum2.ForeColor = System.Drawing.Color.Black;
            this.lblsum2.Location = new System.Drawing.Point(789, 600);
            this.lblsum2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblsum2.Name = "lblsum2";
            this.lblsum2.Size = new System.Drawing.Size(51, 18);
            this.lblsum2.TabIndex = 40;
            this.lblsum2.Text = "sum1";
            this.lblsum2.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(920, 652);
            this.Controls.Add(this.lblsum2);
            this.Controls.Add(this.lblsum1);
            this.Controls.Add(this.btnArmParking);
            this.Controls.Add(this.btnArmHome);
            this.Controls.Add(this.wifiSignal);
            this.Controls.Add(this.btnEnARM);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnConnect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(936, 687);
            this.Name = "MainForm";
            this.Text = "GROUP 05 ECE225 Robotics";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabFKine.ResumeLayout(false);
            this.gbFKineSol.ResumeLayout(false);
            this.gbRPY.ResumeLayout(false);
            this.gbRPY.PerformLayout();
            this.gbQuaternion.ResumeLayout(false);
            this.gbQuaternion.PerformLayout();
            this.gbXYZ.ResumeLayout(false);
            this.gbXYZ.PerformLayout();
            this.gbRmatrix.ResumeLayout(false);
            this.gbRmatrix.PerformLayout();
            this.gbFKine.ResumeLayout(false);
            this.gbFKine.PerformLayout();
            this.tabMainControl.ResumeLayout(false);
            this.tabMainControl.PerformLayout();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServoStatus8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServoStatus7)).EndInit();
            this.gbSensor.ResumeLayout(false);
            this.gbSensor.PerformLayout();
            this.gboxWheel.ResumeLayout(false);
            this.gboxWheel.PerformLayout();
            this.gbServoRemote.ResumeLayout(false);
            this.gbServoRemote.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServoStatus6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServoStatus5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServoStatus4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServoStatus3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServoStatus2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ServoStatus1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarServo6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarServo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarServo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarServo3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarServo4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarServo5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarServo8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarServo7)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabIKine.ResumeLayout(false);
            this.gbIKineSol.ResumeLayout(false);
            this.gbIKineSol.PerformLayout();
            this.gbIKine.ResumeLayout(false);
            this.gbIKine.PerformLayout();
            this.tabAlgo.ResumeLayout(false);
            this.gbFunc.ResumeLayout(false);
            this.gbFunc.PerformLayout();
            this.gbLine.ResumeLayout(false);
            this.gbLine.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip Files;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslabelStatus;
        private System.Windows.Forms.Timer SystemTimer;
        private System.Windows.Forms.ToolStripStatusLabel tslabelWifi;
        private System.Windows.Forms.Button btnEnARM;
        private WindowWidgets.SignalStrength wifiSignal;
        private System.Windows.Forms.Button btnArmHome;
        private System.Windows.Forms.Button btnArmParking;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabFKine;
        private System.Windows.Forms.GroupBox gbFKineSol;
        private System.Windows.Forms.GroupBox gbRPY;
        private System.Windows.Forms.TextBox tbRoll;
        private System.Windows.Forms.TextBox tbPitch;
        private System.Windows.Forms.TextBox tbYaw;
        private System.Windows.Forms.Label labelRoll;
        private System.Windows.Forms.Label labelPitch;
        private System.Windows.Forms.Label labelYaw;
        private System.Windows.Forms.GroupBox gbQuaternion;
        private System.Windows.Forms.TextBox tbE3;
        private System.Windows.Forms.TextBox tbE2;
        private System.Windows.Forms.TextBox tbE1;
        private System.Windows.Forms.TextBox tbE0;
        private System.Windows.Forms.Label labelE3;
        private System.Windows.Forms.Label labelE2;
        private System.Windows.Forms.Label labelE1;
        private System.Windows.Forms.Label labelE0;
        private System.Windows.Forms.GroupBox gbXYZ;
        private System.Windows.Forms.TextBox tbPz;
        private System.Windows.Forms.TextBox tbPy;
        private System.Windows.Forms.TextBox tbPx;
        private System.Windows.Forms.Label labelPz;
        private System.Windows.Forms.Label labelPy;
        private System.Windows.Forms.Label labelPx;
        private System.Windows.Forms.GroupBox gbRmatrix;
        private System.Windows.Forms.Label labelR33;
        private System.Windows.Forms.Label labelR23;
        private System.Windows.Forms.Label labelR32;
        private System.Windows.Forms.Label labelR22;
        private System.Windows.Forms.Label labelR31;
        private System.Windows.Forms.Label labelR21;
        private System.Windows.Forms.Label labelR13;
        private System.Windows.Forms.Label labelR12;
        private System.Windows.Forms.Label labelR11;
        private System.Windows.Forms.TextBox tbR33;
        private System.Windows.Forms.TextBox tbR23;
        private System.Windows.Forms.TextBox tbR13;
        private System.Windows.Forms.TextBox tbR32;
        private System.Windows.Forms.TextBox tbR22;
        private System.Windows.Forms.TextBox tbR12;
        private System.Windows.Forms.TextBox tbR31;
        private System.Windows.Forms.TextBox tbR21;
        private System.Windows.Forms.TextBox tbR11;
        private System.Windows.Forms.GroupBox gbFKine;
        private System.Windows.Forms.Button btnRstFKine;
        private System.Windows.Forms.Label labelFkine;
        private System.Windows.Forms.Button btnRunFKine;
        private System.Windows.Forms.Label labelTeta3;
        private System.Windows.Forms.Label labelTeta2;
        private System.Windows.Forms.Label labelTeta1;
        private System.Windows.Forms.TextBox tbTeta3;
        private System.Windows.Forms.TextBox tbTeta2;
        private System.Windows.Forms.TextBox tbTeta1;
        private System.Windows.Forms.TabPage tabMainControl;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.CheckBox cboxShapeDetect;
        private System.Windows.Forms.CheckBox cboxColorTrack;
        private System.Windows.Forms.Button btnSnap;
        private System.Windows.Forms.CheckBox cboxObjectDetect;
        private System.Windows.Forms.PictureBox ServoStatus8;
        private System.Windows.Forms.PictureBox ServoStatus7;
        private System.Windows.Forms.GroupBox gbSensor;
        private System.Windows.Forms.Label labelDist;
        private System.Windows.Forms.GroupBox gboxWheel;
        private System.Windows.Forms.Button btnSetDuty;
        private System.Windows.Forms.TextBox tboxDuty;
        private System.Windows.Forms.Label labelDuty;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnBwd;
        private System.Windows.Forms.Button btnFwd;
        private System.Windows.Forms.Label labelServo7;
        private System.Windows.Forms.Label labelServo8;
        private System.Windows.Forms.GroupBox gbServoRemote;
        private System.Windows.Forms.Button btnSetServo6;
        private System.Windows.Forms.TextBox tboxServo6;
        private System.Windows.Forms.Button btnSetServo5;
        private System.Windows.Forms.TextBox tboxServo5;
        private System.Windows.Forms.Button btnSetServo4;
        private System.Windows.Forms.TextBox tboxServo4;
        private System.Windows.Forms.Button btnSetServo3;
        private System.Windows.Forms.TextBox tboxServo3;
        private System.Windows.Forms.Button btnSetServo2;
        private System.Windows.Forms.TextBox tboxServo2;
        private System.Windows.Forms.Button btnSetServo1;
        private System.Windows.Forms.TextBox tboxServo1;
        private System.Windows.Forms.PictureBox ServoStatus6;
        private System.Windows.Forms.PictureBox ServoStatus5;
        private System.Windows.Forms.PictureBox ServoStatus4;
        private System.Windows.Forms.PictureBox ServoStatus3;
        private System.Windows.Forms.PictureBox ServoStatus2;
        private System.Windows.Forms.PictureBox ServoStatus1;
        private System.Windows.Forms.Label labelServo6;
        private System.Windows.Forms.Label labelServo5;
        private System.Windows.Forms.Label labelServo4;
        private System.Windows.Forms.Label labelServo3;
        private System.Windows.Forms.Label labelServo2;
        private System.Windows.Forms.Label labelServo1;
        private System.Windows.Forms.TrackBar tbarServo6;
        private System.Windows.Forms.TrackBar tbarServo1;
        private System.Windows.Forms.TrackBar tbarServo2;
        private System.Windows.Forms.TrackBar tbarServo3;
        private System.Windows.Forms.TrackBar tbarServo4;
        private System.Windows.Forms.TrackBar tbarServo5;
        private System.Windows.Forms.TrackBar tbarServo8;
        private System.Windows.Forms.TrackBar tbarServo7;
        private motion.CameraWindow cameraWindow;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.CheckBox cboxSobelDetect;
        private System.Windows.Forms.CheckBox cboxCannyDetect;
        private System.Windows.Forms.Label lblsum1;
        private System.Windows.Forms.Label lblsum2;
        private System.Windows.Forms.TabPage tabIKine;
        private System.Windows.Forms.TabPage tabAlgo;
        private System.Windows.Forms.GroupBox gbIKineSol;
        private System.Windows.Forms.Label labelTeta3Inv;
        private System.Windows.Forms.Label labelTeta2Inv;
        private System.Windows.Forms.Label labelTeta1Inv;
        private System.Windows.Forms.TextBox tbTeta3Inv;
        private System.Windows.Forms.TextBox tbTeta2Inv;
        private System.Windows.Forms.TextBox tbTeta1Inv;
        private System.Windows.Forms.GroupBox gbIKine;
        private System.Windows.Forms.Button btnRstIKine;
        private System.Windows.Forms.Label labelIKine;
        private System.Windows.Forms.Button btnRunIKine;
        private System.Windows.Forms.Label labelPzInv;
        private System.Windows.Forms.Label labelPyInv;
        private System.Windows.Forms.Label labelPxInv;
        private System.Windows.Forms.TextBox tbPzInv;
        private System.Windows.Forms.TextBox tbPyInv;
        private System.Windows.Forms.TextBox tbPxInv;
        private System.Windows.Forms.TextBox tbRad;
        private System.Windows.Forms.GroupBox gbFunc;
        private System.Windows.Forms.Label labelFuncSts;
        private System.Windows.Forms.Button btnRstFunc;
        private System.Windows.Forms.Button btnRunSquare;
        private System.Windows.Forms.Button btnRunPickPlace;
        private System.Windows.Forms.GroupBox gbLine;
        private System.Windows.Forms.Label labelLineSts;
        private System.Windows.Forms.Button btnRstLine;
        private System.Windows.Forms.Label labelPzLine13;
        private System.Windows.Forms.Button btnRunLine;
        private System.Windows.Forms.Label labelPyLine13;
        private System.Windows.Forms.TextBox tbPz13;
        private System.Windows.Forms.TextBox tbPy13;
        private System.Windows.Forms.TextBox tbPx13;
        private System.Windows.Forms.Label labelPzLine12;
        private System.Windows.Forms.Label labelPyLine12;
        private System.Windows.Forms.TextBox tbPz12;
        private System.Windows.Forms.TextBox tbPy12;
        private System.Windows.Forms.TextBox tbPx12;
        private System.Windows.Forms.Label labelPzLine11;
        private System.Windows.Forms.Label labelPyLine11;
        private System.Windows.Forms.Label labelPxLine11;
        private System.Windows.Forms.TextBox tbPz11;
        private System.Windows.Forms.TextBox tbPy11;
        private System.Windows.Forms.TextBox tbPx11;
        private System.Windows.Forms.Label labelPxLine13;
        private System.Windows.Forms.Label labelPxLine12;
        private System.Windows.Forms.Label labelPoint13;
        private System.Windows.Forms.Label labelPoint12;
        private System.Windows.Forms.Label labelPoint11;
        private System.Windows.Forms.Button button1;
    }
}

