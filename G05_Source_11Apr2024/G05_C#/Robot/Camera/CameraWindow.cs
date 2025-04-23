

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;

namespace motion
{
	/// <summary>
	/// Summary description for CameraWindow.
	/// </summary>
	public class CameraWindow : System.Windows.Forms.Control
	{
		private Camera	camera = null;
		private bool	autosize = false;
		private bool	needSizeUpdate = false;
		private bool	firstFrame = true;

		private System.Timers.Timer timer;
		private int		flash = 0;
        private Color	rectColor = Color.Black;

        private int Red = 0;
        private int Green = 0;
        private int Blue = 0;
        private bool bOjectDetection = false;
        private bool bColorDetection = false;
        private bool bShapeDetection = false;
        private bool bCannyDetection = false;
        private bool bSobelDetection = false;

        Rectangle[] rects;


        // Camera property
        [Browsable(false)]
		public Camera Camera
		{
			get { return camera; }
			set
			{
				// lock
				Monitor.Enter( this );

				// detach event
				if ( camera != null )
				{
					camera.NewFrame	-= new EventHandler( camera_NewFrame );
					camera.Alarm	-= new EventHandler( camera_Alarm );
					timer.Stop( );
				}

				camera			= value;
				needSizeUpdate	= true;
				firstFrame		= true;
				flash			= 0;

				// atach event
				if ( camera != null )
				{
					camera.NewFrame += new EventHandler( camera_NewFrame );
					camera.Alarm	+= new EventHandler( camera_Alarm );
					timer.Start( );
				}

				// unlock
				Monitor.Exit( this );
			}
		}

		// Constructor
		public CameraWindow( )
		{
			InitializeComponent( );

			SetStyle( ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer |
				ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true );
		}

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
            this.timer = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.timer)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 250D;
            this.timer.SynchronizingObject = this;
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Elapsed);
            ((System.ComponentModel.ISupportInitialize)(this.timer)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		
		// Paint control
		protected override void OnPaint( PaintEventArgs pe )
		{
			if ( ( needSizeUpdate ) || ( firstFrame ) )
			{
				UpdatePosition( );
				needSizeUpdate = false;
			}

			// lock
			Monitor.Enter( this );

			Graphics	g = pe.Graphics;
			Rectangle	rc = this.ClientRectangle;
			Pen			pen = new Pen( rectColor, 1 );

			// draw rectangle
			g.DrawRectangle( pen, rc.X, rc.Y, rc.Width - 1, rc.Height - 1 );

			if ( camera != null )
			{
				try
				{
					camera.Lock( );

					// draw frame
					if ( camera.LastFrame != null )
					{
                        Bitmap b = camera.LastFrame.Clone(rc, camera.LastFrame.PixelFormat);
                        g.DrawImage(b, rc.X + 1, rc.Y + 1, rc.Width - 2, rc.Height - 2);

                        if ( (true == bOjectDetection) || (true == bColorDetection) || (true == bShapeDetection) || (true == bCannyDetection) || (true == bSobelDetection))
                        {
                            if ( true == bOjectDetection )
                            {
                                FindObjects(b, g);
                            }

                            if( true == bColorDetection )
                            {
                                Findcolor(b, g);
                            }
                            if (true == bCannyDetection)
                            {
                                FindCanny(b, g);
                            }
                            if (true == bSobelDetection)
                            {
                                FindSobel(b, g);
                            }

                            if( true == bShapeDetection )
                            {
                               FindShape(b, g);
                            }


                        }


                        firstFrame = false;
					}
					else
					{
						
						Font drawFont = new Font( "Arial", 12 );
						SolidBrush drawBrush = new SolidBrush( Color.White );

						g.DrawString( "CameraWindow ...", drawFont, drawBrush, new PointF( 5, 5 ) );

						drawBrush.Dispose( );
						drawFont.Dispose( );
					}
				}
				catch ( Exception )
				{
				}
				finally
				{
					camera.Unlock( );
				}
			}

			pen.Dispose( );

			// unlock
			Monitor.Exit( this );

			base.OnPaint( pe );
		}

#if true
        private void FindObjects(Bitmap image, Graphics g )
        {
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.MinWidth = 50;
            blobCounter.MinHeight = 50;
            blobCounter.FilterBlobs = true;
            blobCounter.ObjectsOrder = ObjectsOrder.Size;
            Bitmap alterimage = new Bitmap(image);

            EuclideanColorFiltering filter = new EuclideanColorFiltering();
            filter.CenterColor = new RGB(Color.FromArgb(Red, Green, Blue));
            filter.Radius = 100;
            // apply the filter
            filter.ApplyInPlace(alterimage);

            BitmapData objectsData = alterimage.LockBits(new Rectangle(0, 0, alterimage.Width, alterimage.Height), ImageLockMode.ReadOnly, alterimage.PixelFormat);
            // grayscaling
            Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
            grayscaleFilter.Apply(new UnmanagedImage(objectsData));
            // unlock image
            alterimage.UnlockBits(objectsData);

            blobCounter.ProcessImage(alterimage);
            rects = blobCounter.GetObjectsRectangles();

            //Multi Tracking            
            for (int i = 0; rects.Length > i; i++)
            {
                Rectangle objectRect = rects[i];
                using (Pen pen = new Pen(Color.FromArgb(128, 255, 0), 2))
                {
                    g.DrawRectangle(pen, objectRect);
                    g.DrawString((i + 1).ToString(), new Font("Arial", 12), Brushes.Red, objectRect);

                }
            }
        }
#endif

        // Convert list of AForge.NET's points to array of .NET points
        private System.Drawing.Point[] ToPointsArray(List<IntPoint> points)
        {
            System.Drawing.Point[] array = new System.Drawing.Point[points.Count];

            for (int i = 0, n = points.Count; i < n; i++)
            {
                array[i] = new System.Drawing.Point(points[i].X, points[i].Y);
            }

            return array;
        }

        private void FindSobel(Bitmap bitmap, Graphics g)
        {
            Rectangle rc = this.ClientRectangle;
            Grayscale gray = new Grayscale(0.2125, 0.7154, 0.0721); //gray scale filter
            Bitmap img = gray.Apply(bitmap);
            // Apply Sobel Filter
            SobelEdgeDetector filter = new SobelEdgeDetector();
            filter.ApplyInPlace(img);
            // Apply Inverting Filter
            Invert invrfilter = new Invert();
            invrfilter.ApplyInPlace(img);
            // Apply Threshold
            Threshold thresh = new Threshold();
            thresh.ApplyInPlace(img);

            g.DrawImage(img, rc.X + 1, rc.Y + 1, rc.Width - 2, rc.Height - 2);
        }


        private void Findcolor(Bitmap bitmap, Graphics g)
        {
            Rectangle rc = this.ClientRectangle;
            // 3 bitmap objects for 3 color filters
            Bitmap imageR = new Bitmap(bitmap);
            Bitmap imageG = new Bitmap(bitmap);
            Bitmap imageB = new Bitmap(bitmap);

            BlobCounter blobCounter = new BlobCounter();
            blobCounter.MinWidth = 80;
            blobCounter.MinHeight = 80;
            blobCounter.FilterBlobs = true;

            // create filter for RED
            EuclideanColorFiltering filterR = new EuclideanColorFiltering();         
            filterR.CenterColor = new RGB(Color.FromArgb(200, 5, 5));
            filterR.Radius = 100;            
            Bitmap mapR = filterR.Apply(imageR);
            blobCounter.ProcessImage(mapR);
            Rectangle[] rectsR = blobCounter.GetObjectsRectangles();


            for (int i = 0; i < rectsR.Length; i++)
            {
                Rectangle objectRect = rectsR[i];
                using (Pen pen = new Pen(Color.FromArgb(255, 30, 30), 5))
                {
                    g.DrawRectangle(pen, objectRect); 
                    g.DrawString("Red", new Font("Arial", 12), Brushes.Red, objectRect);
                }
            }

            // create filter - Green    
            EuclideanColorFiltering filterG = new EuclideanColorFiltering();       
            filterG.CenterColor = new RGB(Color.FromArgb(10, 245, 10));
            filterG.Radius = 180;
            Bitmap mapG = filterG.Apply(imageG);
            blobCounter.ProcessImage(mapG);
            Rectangle[] rectsG = blobCounter.GetObjectsRectangles();

            for (int i = 0; i < rectsG.Length; i++)
            {
                Rectangle objectRect = rectsG[i];
                using (Pen pen = new Pen(Color.FromArgb(0, 255, 0), 5))
                {
                    g.DrawRectangle(pen, objectRect);
                    g.DrawString("Green", new Font("Arial", 12), Brushes.Green, objectRect);
                }
            }

            // create filter - Blue          
            EuclideanColorFiltering filterB = new EuclideanColorFiltering();
            // set center color and radius             
            filterB.CenterColor = new RGB(Color.FromArgb(5, 5, 245));
            filterB.Radius = 170;
            // apply the filter             
            Bitmap mapB = filterB.Apply(imageB);
            blobCounter.ProcessImage(mapB);
            Rectangle[] rectsB = blobCounter.GetObjectsRectangles();

            for (int i = 0; i < rectsB.Length; i++)
            {
                Rectangle objectRect = rectsB[i];
                using (Pen pen = new Pen(Color.FromArgb(0, 0, 255), 5))
                {
                    g.DrawRectangle(pen, objectRect);
                    g.DrawString("Blue", new Font("Arial", 12), Brushes.Blue, objectRect);
                }
            }
        }


        private  void FindCanny (Bitmap bitmap, Graphics g)
        {
            Rectangle rc = this.ClientRectangle;
            Grayscale gray = new Grayscale(0.2125, 0.7154, 0.0721); //gray scale filter
            Bitmap img = gray.Apply(bitmap);
            // Apply Canny Filter
            CannyEdgeDetector canny = new CannyEdgeDetector(0, 70);
            canny.ApplyInPlace(img);
            // Apply Inverting Filter
            Invert invrfilter = new Invert();
            invrfilter.ApplyInPlace(img);
            // Apply Threshold
            Threshold thresh = new Threshold();
            thresh.ApplyInPlace(img);
            g.DrawImage(img, rc.X + 1, rc.Y + 1, rc.Width - 2, rc.Height - 2);
        }


        // Process image
        private void FindShape(Bitmap bitmap, Graphics g)
        {
            GaussianSharpen filter1 = new GaussianSharpen();
            filter1.ApplyInPlace(bitmap);
            BitmapData bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite, bitmap.PixelFormat);

            // Step 1 - Set background to Black color
            ColorFiltering colorFilter = new ColorFiltering();

            // Set Filter RGB range
            colorFilter.Red = new IntRange(0, 64);
            colorFilter.Green = new IntRange(0, 64);
            colorFilter.Blue = new IntRange(0, 64);
            // Set other colors to false
            colorFilter.FillOutsideRange = false;
            // Apply RGB filter
            colorFilter.ApplyInPlace(bitmapData);

            // Step 2 - Find Objects
            BlobCounter blobCounter = new BlobCounter();

            blobCounter.FilterBlobs = true;
            blobCounter.MinHeight = 50;
            blobCounter.MinWidth = 50;

            blobCounter.ProcessImage(bitmapData);
            Blob[] blobs = blobCounter.GetObjectsInformation();
           
            bitmap.UnlockBits(bitmapData);

            // Step 3 - Check shape and highlight
            SimpleShapeChecker shapeChecker = new SimpleShapeChecker();

            Pen yellowPen = new Pen(Color.Aqua, 2); // circles
            Pen redPen = new Pen(Color.Red, 2);       // quadrilateral
            Pen brownPen = new Pen(Color.Brown, 2);   // quadrilateral with known sub-type
            Pen greenPen = new Pen(Color.Green, 2);   // known triangle
            Pen bluePen = new Pen(Color.Blue, 2);     // triangle

            for (int i = 0, n = blobs.Length; i < n; i++)
            {
                List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobs[i]);
                
                AForge.Point center;
                float radius;

                // Check if circle
                if (shapeChecker.IsCircle(edgePoints, out center, out radius))
                {
                    g.DrawEllipse(yellowPen,
                        (float)(center.X - radius), (float)(center.Y - radius),
                        (float)(radius * 2), (float)(radius * 2));
                    g.DrawString("Circle", new Font("Arial", 12), Brushes.Red, (float)(center.X - radius), (float)(center.Y + radius));
                }
                else
                {
                   
                    List<IntPoint> corners;

                    // Check if triangle or quadrilateral
                    if (shapeChecker.IsConvexPolygon(edgePoints, out corners))
                    {
                        // get sub-type
                        PolygonSubType subType = shapeChecker.CheckPolygonSubType(corners);

                        Pen pen;

                        if (subType == PolygonSubType.Unknown)
                        {
                            pen = (corners.Count == 4) ? redPen : bluePen;
                            
                        }
                        else
                        {
                            pen = (corners.Count == 4) ? brownPen : greenPen;
                            
                        }

                        g.DrawPolygon(pen, ToPointsArray(corners));
                        if (pen == redPen)
                        {
                            g.DrawString("Quadrilateral", new Font("Arial", 12), Brushes.Blue, corners[0].X, corners[0].Y);
                        }
                        else if (pen == bluePen)
                        {
                            g.DrawString("Triangle", new Font("Arial", 12), Brushes.HotPink, corners[0].X, corners[0].Y);
                        }
                        else
                        {
                            g.DrawString(subType.ToString(), new Font("Arial", 12), Brushes.Gold, corners[0].X, corners[0].Y);
                        }
                        
                    }
                }
            }
            // Delete Pen objects
            yellowPen.Dispose();
            redPen.Dispose();
            greenPen.Dispose();
            bluePen.Dispose();
            brownPen.Dispose();

#if false
            // put new image to clipboard
            Clipboard.SetDataObject(bitmap);
            // and to picture box
            pictureBox.Image = bitmap;

            UpdatePictureBoxPosition();
#endif
        }

        public void ObjectDetectionSet( bool bEn )
        {
            bOjectDetection = bEn;
        }

        public void SHapeDetectionSet(bool bEn)
        {
            bShapeDetection = bEn;
        }

        public void SobelDetectionSet(bool bEn)
        {
            bSobelDetection = bEn;
        }

        public void ColorDetectionSet(bool bEn)
        {
            bColorDetection = bEn;
        }

        public void CannyDetectionSet(bool bEn)
        {
            bCannyDetection = bEn;
        }

        // Update position and size of the control
        public void UpdatePosition( )
		{
			// lock
			Monitor.Enter( this );

			if ( ( autosize ) && ( this.Parent != null ) )
			{
				Rectangle	rc = this.Parent.ClientRectangle;
				int			width = 640;
				int			height = 480;

				if ( camera != null )
				{
					camera.Lock( );

					// get frame dimension
					if ( camera.LastFrame != null )
					{
						width = camera.LastFrame.Width;
						height = camera.LastFrame.Height;
					}
					camera.Unlock( );
				}

				//
				this.SuspendLayout( );
				this.Location = new System.Drawing.Point( ( rc.Width - width - 2 ) / 2, ( rc.Height - height - 2 ) / 2 );
				this.Size = new Size( width + 2, height + 2 );
				this.ResumeLayout( );

			}
			// unlock
			Monitor.Exit( this );
		}

        public void SetColorDetection( int R, int G, int B )
        {
            Red = R;
            Green = G;
            Blue = B;
        }

		// On new frame ready
		private void camera_NewFrame( object sender, System.EventArgs e )
		{
			Invalidate();
		}

		// On alarm
		private void camera_Alarm( object sender, System.EventArgs e )
		{
			// flash for 2 seconds
			flash = (int) ( 2 * ( 1000 / timer.Interval ) );
		}

		// On timer
		private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			if ( flash > 0 )
			{
				// calculate color
				if ( --flash == 0 )
				{
					rectColor = Color.Black;
				}
				else
				{
					rectColor = ( rectColor == Color.Red ) ? Color.Black : Color.Red;
				}

				// draw rectangle
				if ( !needSizeUpdate )
				{
					Graphics	g = this.CreateGraphics( );
					Rectangle	rc = this.ClientRectangle;
					Pen			pen = new Pen( rectColor, 1 );

					// draw rectangle
					g.DrawRectangle( pen, rc.X, rc.Y, rc.Width - 1, rc.Height - 1 );

					g.Dispose( );
					pen.Dispose( );
				}
			}
		}
	}
}
