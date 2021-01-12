using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kinect2;
using Display;
using MyImageToolBox;
using System.IO;
using System.Collections;
using System.Threading;
using Microsoft.Kinect;
using Calculator;
using System.Windows.Media.Media3D;
using System.Diagnostics;

namespace DataRecorderKinect
{
    public partial class Form1 : Form
    {
		private ImageConversion ImageConverter = new ImageConversion();

		bool LiveStreamOpen = false;
        Kinect2Handler myKinect = null;
        PictureBoxDisplay Displayer = new PictureBoxDisplay();
        Load_save_parameter data_handler = null;
        public uint MinDepth = 600;
        public uint MaxDepth = 2300;
        public List<System.Drawing.Point> TriggerArea = new List<System.Drawing.Point>();
        public byte[] BackUpIRDisplay;
        ImageConversion ImageConv = new ImageConversion();
        DrawingTools DrawingEngine = new DrawingTools();
        public Bitmap CalibrationImage = null;
        public int[] workAreaMask = new int[0];
        bool triggerSignal = false;
        public byte[] StillDepthImage = new byte[424 * 512];
        public byte[] StillIrImage = new byte[424 * 512];
        public ushort[] CutDepthStillData = new ushort[424 * 512];
        public ushort[] CutIRStillData = new ushort[424 * 512];
        public ushort[] RawShortInfraredData = new ushort[424 * 512];
        public byte[] StillRGBImage = new byte[1920 * 1080*4];
        bool CollectData = false;
        public string[] AllCutDepthStillImagePath;
        public string[] AllRawIRStillImagePath;
        public string[] AllRawColorImagePath;
        public KinectConversion ConverterKinectData = new KinectConversion();
        public bool Livestream = false;

		public ushort[] CutDepthDataOffline = new ushort[424 * 512];
		public List<System.Drawing.Point> XYPlaneRotationArea = new List<System.Drawing.Point>();
		public List<System.Drawing.Point> MeatAreaTrigger = new List<System.Drawing.Point>();
		public List<System.Drawing.Point> VectorZRotation = new List<System.Drawing.Point>();

		public Bitmap XYRotateImage = null;
		public byte[] CalibrationArea = new byte[512 * 424];
		public byte[] CalibrationAreaMask = new byte[512 * 424];
		public byte[] MeatAreaMask = new byte[512 * 424];
		public ushort[] MeatAreaBackground = new ushort[512 * 424];
		byte[] XYRotateBytes = new byte[424 * 512];
		CameraSpacePoint[] RotateCameraSpacePoint = new CameraSpacePoint[512 * 424];
		CameraSpacePoint[] RotateCameraSpacePointXYZ = new CameraSpacePoint[512 * 424];
		CameraSpacePoint[] RotateCameraSpacePointXYZ2 = new CameraSpacePoint[512 * 424];
		public double[,] RotationsMatrixGlobal = new double[3, 3];
		public double[,] RotationsMatrixXYPlane = new double[3, 3];
		public double[,] RotationsMatrixZAxis = null;
		public double[] BackGroundWorkAreaDepthMask = new double[512 * 424];
		public float avgHeightConveyorRotatet = 0;
		public float avgHeightConveyorRaw = 0;
		public double relativePointX = 0;
		public double relativePointY = 0;
		byte[] newCalibrateImage = new byte[424 * 512];
		public ushort[] BackGroundValueFromSide = new ushort[424 * 512];
		byte[] RawColorImageData = new byte[1920 * 1080 * 4];
		byte[] RawShortInfraredData2 = new byte[512 * 424];

		public CameraSpacePoint OrigoOfPlane = new CameraSpacePoint();
		public CameraSpacePoint XDirectionOfOrigo = new CameraSpacePoint();
		int countImage = 0;

		public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            data_handler = new Load_save_parameter(this);

            myKinect = new Kinect2Handler((int)600, (int)2000);

            UpdateUI();
        }

        private void UpdateUI()
        {
            textBoxMinDepth.Text = MinDepth.ToString();
            textBoxMaxDepth.Text = MaxDepth.ToString();

			textBox1.Text = MaxDepth.ToString();
			textBox2.Text = MinDepth.ToString();



			if (!IsNullOrEmpty(BackUpIRDisplay))
            {
                Displayer.DisplayImages(ref pictureBoxTriggerImage, BackUpIRDisplay);
                CalibrationImage = new Bitmap(pictureBoxTriggerImage.Image);
                pictureBoxTriggerImage.Image = DrawingEngine.draw_workarea(TriggerArea, CalibrationImage);
            }
        }

        public bool IsNullOrEmpty(Array array)
        {
            return (array == null || array.Length == 0);
        }

        void waitDelay(int ds)
        {
            Thread.Sleep(ds);
        }

        public async Task LivestreamTask()
        {
            Livestream = true;
			Stopwatch picturefrq = new Stopwatch();


            while (LiveStreamOpen)
            {
				picturefrq.Restart();
               
                if (radioButton2.Checked == false ||true)
                {
                    await System.Threading.Tasks.Task.Run(() => myKinect.GetNewImages());
                    Displayer.DisplayImages(ref pictureBoxDepth, myKinect.CutDepthImageData);
                    Displayer.DisplayImages(ref pictureBoxIR, myKinect.RawShortIrImageData);
                    Displayer.DisplayImagesRGB(ref pictureBoxRGB, myKinect.RGBRawData,1920,1080);
                    pictureBoxRGB.SizeMode = PictureBoxSizeMode.StretchImage;

                    if (CollectData)
                        TriggerSearch();
                    this.Refresh();
                }
                else
                {
                    await Task.Run(() => waitDelay(1000));
                    this.Refresh();
                }

				textBox3.Text = picturefrq.ElapsedMilliseconds.ToString();
                
            }
            Livestream = false;
        }

        private async void buttonTriggerImage_Click(object sender, EventArgs e)
        {
			if (!LiveStreamOpen)
			{
				await System.Threading.Tasks.Task.Run(() => myKinect.GetNewImages());
				//CalibrationImage = Displayer.GetGrayPictureFromBytes(512, 424, myKinect.CutDepthImageData);
			}



			BackUpIRDisplay = new byte[myKinect.CutDepthImageData.Count()];
            myKinect.CutDepthImageData.CopyTo(BackUpIRDisplay, 0);

            Displayer.DisplayImages(ref pictureBoxTriggerImage, BackUpIRDisplay);
            data_handler.save_variable(x => BackUpIRDisplay);

            CalibrationImage = new Bitmap(pictureBoxTriggerImage.Image);
        }


        private void textBoxMinDepth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MinDepth = Convert.ToUInt16(textBoxMinDepth.Text);
                data_handler.save_variable(x => MinDepth);
                myKinect.SetMinDepth((int)MinDepth);
            }
            catch { }

            
        }

        private void textBoxMaxDepth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MaxDepth = Convert.ToUInt16(textBoxMaxDepth.Text);
                data_handler.save_variable(x => MaxDepth);
                myKinect.SetMaxDepth((int)MaxDepth);
            }
            catch { }
        }

        private void pictureBoxTriggerImage_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;

            if (me.Button == MouseButtons.Left)
            {
                System.Drawing.Point coordinates = me.Location;
                // coordinates.X /= 2;
                // coordinates.Y /= 2;
                TriggerArea.Add(coordinates);
            }
            else
            {
                if (TriggerArea.Count > 0)
                    TriggerArea.RemoveAt(TriggerArea.Count - 1);
            }

            data_handler.save_variable(x => TriggerArea);

            pictureBoxTriggerImage.Image = DrawingEngine.draw_workarea(TriggerArea, CalibrationImage);
            workAreaMask = GetGreenMask(new Bitmap(pictureBoxTriggerImage.Image));


			BackGroundValueFromSide = new ushort[512 * 424];
			for (int i=0; i<workAreaMask.Count(); i++)
			{
				BackGroundValueFromSide[i] = myKinect.CutDepthData[i];
			}

			data_handler.save_variable(x => BackGroundValueFromSide);
			data_handler.save_variable(x => workAreaMask);
        }

        private int[] GetGreenMask(Image ImageMask)
        {
            byte[] CalibrationArea = ImageConv.BitmapToByteArray((Bitmap)ImageMask);
            int[] res = new int[512 * 424];
            for (int i = 0; i < 512 * 424; i++)
            {
                int index = i * 4;
                if (CalibrationArea[index] == 0 && CalibrationArea[index + 1] > 100)
                {
                    res[i] = 1;
                }
                else
                {
                    res[i] = 0;
                }
            }

            return res;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
			if (!LiveStreamOpen)
			{
				LiveStreamOpen = true;
				LivestreamTask();
			}

			if (CollectData)
            {
                CollectData = false;
            }
            else
            {
                CollectData = true;
            }
        }


        private void TriggerSearch()
        {
            int CountPixelOverThreadsHold = 0;
            myKinect.CutDepthImageData.CopyTo(StillDepthImage, 0);
			ushort[] crrtDepth = new ushort[512 * 424];
			myKinect.CutDepthData.CopyTo(crrtDepth, 0);

            for (int i = 0; i < 512 * 424; i++)
            {
                if (workAreaMask[i] == 1)
                {
					if (BackGroundValueFromSide[i] == 0)
					{
						if (crrtDepth[i] > 0)
						{
							CountPixelOverThreadsHold++;
						}
					}
					else
					{
						if (BackGroundValueFromSide[i] - crrtDepth[i] > 200)
						{
							CountPixelOverThreadsHold++;
						}
					}

                }
            }

            if (CountPixelOverThreadsHold < 400)
            {
                triggerSignal = false;
            }
            else if (CountPixelOverThreadsHold > 100 && !triggerSignal)
            {
                triggerSignal = true;

                myKinect.RawShortIrImageData.CopyTo(StillIrImage, 0);
                myKinect.RGBRawData.CopyTo(StillRGBImage, 0);

                myKinect.CutDepthData.CopyTo(CutDepthStillData, 0);
                myKinect.RawShortInfraredData.CopyTo(CutIRStillData,0);

                data_handler.SaveObjectAsNewFile(x => CutDepthStillData);
                data_handler.SaveObjectAsNewFile(x => StillIrImage);
                data_handler.SaveObjectAsNewFile(x => StillRGBImage);
                data_handler.SaveObjectAsNewFile(x => CutIRStillData);

                Displayer.DisplayImages(ref pictureBoxStillDepthImage, StillDepthImage);
                Displayer.DisplayImages(ref pictureBoxStillIRImage, StillIrImage);
                pictureBoxStillRGBImage.Image = Displayer.GetPictureFromData(1920, 1080, StillRGBImage);
                pictureBoxStillRGBImage.SizeMode = PictureBoxSizeMode.StretchImage;

				countImage++;
				textBoxNumberOfImage.Text = countImage.ToString();


			}
		}

		private void TriggerSearch2(int CountPixelOverThreadsHold = 0)
		{
			CameraSpacePoint[] Image3D = new CameraSpacePoint[512 * 424];
			myKinect.coordinateMapper.MapDepthFrameToCameraSpace(myKinect.CutDepthData, Image3D);


			if (CountPixelOverThreadsHold == 0)
			{
				for (int i = 0; i < 512 * 424; i++)
				{
					if (MeatAreaMask[i] == 1)
					{
						double tempZ = avgHeightConveyorRotatet - (Image3D[i].X * RotationsMatrixGlobal[2, 0] + Image3D[i].Y * RotationsMatrixGlobal[2, 1] + Image3D[i].Z * RotationsMatrixGlobal[2, 2]);
						if (0.05f < tempZ)
						{
							CountPixelOverThreadsHold++;
						}
					}
				}
			}


			if ((CountPixelOverThreadsHold < 200 && !triggerSignal) || (CountPixelOverThreadsHold < 100 && triggerSignal))
			{
			     triggerSignal = false;
			}
			else if (CountPixelOverThreadsHold > 100 && !triggerSignal)
			{
				triggerSignal = true;

				myKinect.RawShortIrImageData.CopyTo(StillIrImage, 0);
				myKinect.RGBRawData.CopyTo(StillRGBImage, 0);
				myKinect.CutDepthData.CopyTo(CutDepthStillData, 0);
				myKinect.RawShortInfraredData.CopyTo(CutIRStillData, 0);

				data_handler.SaveObjectAsNewFile(x => CutDepthStillData);
				data_handler.SaveObjectAsNewFile(x => StillIrImage);
				data_handler.SaveObjectAsNewFile(x => StillRGBImage);
				data_handler.SaveObjectAsNewFile(x => CutIRStillData);

				Displayer.DisplayImages(ref pictureBoxStillDepthImage, StillDepthImage);
				Displayer.DisplayImages(ref pictureBoxStillIRImage, StillIrImage);
				pictureBoxStillRGBImage.Image = Displayer.GetPictureFromData(1920, 1080, StillRGBImage);
				pictureBoxStillRGBImage.SizeMode = PictureBoxSizeMode.StretchImage;
			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //LiveStreamOpen = false;
            //while(Livestream) await Task.Run(() => waitDelay(10));

            if (radioButton2.Checked == true)
            {
                string default_folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

                string pathCutStillData = default_folder + "\\CutDepthStillData";
                string pathIRData = default_folder + "\\CutIRStillData";
                string pathColorData = default_folder + "\\StillRGBImage";

                AllCutDepthStillImagePath = System.IO.Directory.GetFiles(pathCutStillData, "C*");
                AllRawIRStillImagePath = System.IO.Directory.GetFiles(pathIRData, "C*");
                AllRawColorImagePath = System.IO.Directory.GetFiles(pathColorData, "S*");

                Array.Sort(AllCutDepthStillImagePath, new AlphanumComparatorFast());
                Array.Sort(AllRawIRStillImagePath, new AlphanumComparatorFast());
                Array.Sort(AllRawColorImagePath, new AlphanumComparatorFast());

                hScrollBar1.Minimum = 1;
                hScrollBar1.Maximum = AllCutDepthStillImagePath.Count() + 9;

                hScrollBar1_ValueChanged(null, null);
            }
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked == false)
                return;

            if (hScrollBar1.Value > AllCutDepthStillImagePath.Count())
                return;

            textBoxPictureNumber.Text = hScrollBar1.Value.ToString();

            try
            {
                System.IO.Stream stream = File.Open(AllRawIRStillImagePath[hScrollBar1.Value - 1], FileMode.Open);
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                var bla = (ushort[])binaryFormatter.Deserialize(stream);
                RawShortInfraredData2 = ConverterKinectData.ConvertIRUshortToImageByte(bla);
                Displayer.DisplayImages(ref pictureBoxStillIRImage, RawShortInfraredData2);
                stream.Dispose();
                stream = null;

                stream = File.Open(AllCutDepthStillImagePath[hScrollBar1.Value - 1], FileMode.Open);
                binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                CutDepthStillData = (ushort[])binaryFormatter.Deserialize(stream);
                Displayer.DisplayImages(ref pictureBoxStillDepthImage, ConverterKinectData.ConvertDepthUshortToImageByte(CutDepthStillData, (int)MinDepth, (int)MaxDepth));
                stream.Dispose();
                stream = null;

                stream = File.Open(AllRawColorImagePath[hScrollBar1.Value - 1], FileMode.Open);
                binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                RawColorImageData = (byte[])binaryFormatter.Deserialize(stream);
                Displayer.DisplayImagesRGB(ref pictureBoxStillRGBImage, RawColorImageData, 1920, 1080);
                pictureBoxStillRGBImage.SizeMode = PictureBoxSizeMode.StretchImage;
                stream.Dispose();
                stream = null;


            }
            catch { }
        }

        private void buttonDeleteImage_Click(object sender, EventArgs e)
        {
            File.Delete(AllRawIRStillImagePath[hScrollBar1.Value - 1]);
            File.Delete(AllCutDepthStillImagePath[hScrollBar1.Value - 1]);
            File.Delete(AllRawColorImagePath[hScrollBar1.Value - 1]);

            AllRawIRStillImagePath = AllRawIRStillImagePath.RemoveAt(hScrollBar1.Value - 1);
            AllCutDepthStillImagePath = AllCutDepthStillImagePath.RemoveAt(hScrollBar1.Value - 1);
            AllRawColorImagePath = AllRawColorImagePath.RemoveAt(hScrollBar1.Value - 1);

            hScrollBar1.Maximum = AllCutDepthStillImagePath.Count() + 9;

            hScrollBar1_ValueChanged(null, null);
        }

		private async void buttonGetOneDepthImage_Click(object sender, EventArgs e)
		{
			if (!LiveStreamOpen)
			{
				await System.Threading.Tasks.Task.Run(() => myKinect.GetNewImages());
				CalibrationImage = Displayer.GetGrayPictureFromBytes(512, 424, myKinect.CutDepthImageData);
			}

			myKinect.CutDepthData.CopyTo(CutDepthDataOffline, 0);

			Image dummy = pictureBoxCalibration.Image;

			data_handler.save_variable(x => CalibrationImage);
			pictureBoxCalibration.Image = CalibrationImage;

			//    pictureBoxClickXYCalibration.Image = CalibrationImage;
			pictureBoxZRotation.Image = CalibrationImage;
			if (dummy != null)
			{
				dummy.Dispose();
				dummy = null;
			}


			pictureBoxCalibration.Image = DrawingEngine.draw_workarea(XYPlaneRotationArea, CalibrationImage);
			pictureBoxZRotation.Image = DrawingEngine.draw_workarea(VectorZRotation, Displayer.GetGrayPictureFromBytes(512, 424, myKinect.RawShortIrImageData));
			pictureBoxMeatTriggerArea.Image = DrawingEngine.draw_workarea(MeatAreaTrigger, CalibrationImage);
		}

		private void buttonDeleteCalibrationArea_Click(object sender, EventArgs e)
		{

		}

		private void buttonDoCalibration_Click(object sender, EventArgs e)
		{
			if (CalibrationImage == null)
				return;

			byte[] calibrationAreaImageData = new byte[424 * 512];
			ushort[] RawDepthCalibrationData = new ushort[424 * 512];
			CalibrationArea = ImageConverter.BitmapToByteArray((Bitmap)pictureBoxCalibration.Image);
			CalibrationAreaMask = new byte[512 * 424];



			data_handler.save_variable(x => CalibrationArea);

			for (int i = 0; i < 512 * 424; i++)
			{
				int index = i * 4;
				if (CalibrationArea[index] == 0 && CalibrationArea[index + 1] > 100)
				{
					RawDepthCalibrationData[i] = CutDepthDataOffline[i];
					CalibrationAreaMask[i] = 1;
				}
				else
				{
					RawDepthCalibrationData[i] = 0;
				}
			}
			data_handler.save_variable(x => CalibrationAreaMask);

			//     data_handler.save_variable(x => workAreaMask);

			CameraSpacePoint[] Point3d = new CameraSpacePoint[424 * 512];
			myKinect.coordinateMapper.MapDepthFrameToCameraSpace(RawDepthCalibrationData, Point3d);
			//   coordinateMapper.MapDepthFrameToCameraSpace(CutDepthDataOffline, Point3d);
			int NumberOfElements = Point3d.Count(x => x.X != float.NegativeInfinity && x.X != float.PositiveInfinity);

			double[,] Amatrix = new double[NumberOfElements, 3];
			double[] Bvector = new double[NumberOfElements];

			int countElm = 0;
			int countPoint = 0;
			while (countElm < 424 * 512 && NumberOfElements > countPoint)
			{
				if (Point3d[countElm].X != float.NegativeInfinity && Point3d[countElm].X != float.PositiveInfinity)
				{
					Amatrix[countPoint, 0] = Point3d[countElm].X;
					Amatrix[countPoint, 1] = Point3d[countElm].Y;
					Amatrix[countPoint, 2] = 1;
					Bvector[countPoint] = Point3d[countElm].Z;

					countPoint++;
				}
				countElm++;
			}

			var Amat = new MyMatrix(Amatrix);
			var Bmat = new MyMatrix(Bvector);
			var TransA = Amat.TransposeMatrix();
			var SuperA = TransA * Amat;
			var ATmultB = TransA * Bmat;
			var invSuperA = SuperA.InverseMatrix3x3();
			var plan = invSuperA * ATmultB;
			var planepara = plan.GetDoubleArray();


			Vector3D vector1 = new Vector3D(0.5, 0, 0.5 * planepara[0, 0]);
			Vector3D vector2 = new Vector3D(0, 3, 3 * planepara[1, 0]);
			Vector3D crossProduct;

			crossProduct = Vector3D.CrossProduct(vector1, vector2);
			crossProduct.Normalize();


			double error = 0;
			for (int i = 0; i < Amatrix.Length / 3; i++)
			{
				error += Math.Abs(planepara[0, 0] * Amatrix[i, 0] + planepara[1, 0] * Amatrix[i, 1] + planepara[2, 0] - Bvector[i]);
			}
			error /= (Amatrix.Length / 3);


			var thetaY = Math.Atan2(planepara[1, 0], 1);
			var thetaX = -Math.Atan2(crossProduct.X, Math.Sqrt(crossProduct.Z * crossProduct.Z + crossProduct.Y * crossProduct.Y));


			MyMatrix RotX = MyMatrix.RoationX3D(-thetaY);
			MyMatrix RotY = MyMatrix.RoationY3D(thetaX);

			double[,] RotTot = (RotY * RotX).GetDoubleArray();

			RotationsMatrixXYPlane = (double[,])RotTot.Clone();

			data_handler.save_variable<double[,]>(x => RotationsMatrixXYPlane);

			if (RotationsMatrixZAxis != null)
			{
				RotationsMatrixGlobal = (new MyMatrix(RotationsMatrixZAxis) * (RotY * RotX)).GetDoubleArray();
				data_handler.save_variable<double[,]>(x => RotationsMatrixGlobal);
			}



			//      RotTot = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };

			myKinect.coordinateMapper.MapDepthFrameToCameraSpace(CutDepthDataOffline, Point3d);

			//var temp = ReconstructImage(Point3d, 0, 0,0,0);
			//DisplayImages(ref pictureBoxCalibarteDepthImage, newCalibrateImage);
			//Point3d.CopyTo(rotateImage,0);

			float minX = float.MaxValue;
			float minY = float.MaxValue;
			float maxX = float.MinValue;
			float maxY = float.MinValue;

			for (int i = 0; i < Point3d.Length; i++)
			{
				if (Point3d[i].X != float.NegativeInfinity && Point3d[i].X != float.PositiveInfinity)
				{
					float tempX = (float)(RotTot[0, 0] * Point3d[i].X + RotTot[0, 1] * Point3d[i].Y + RotTot[0, 2] * Point3d[i].Z);
					float tempY = (float)(RotTot[1, 0] * Point3d[i].X + RotTot[1, 1] * Point3d[i].Y + RotTot[1, 2] * Point3d[i].Z);
					float tempZ = (float)(RotTot[2, 0] * Point3d[i].X + RotTot[2, 1] * Point3d[i].Y + RotTot[2, 2] * Point3d[i].Z);

					Point3d[i].X = tempX;
					Point3d[i].Y = tempY;
					Point3d[i].Z = tempZ;

					if (minX > tempX)
						minX = tempX;
					if (maxX < tempX)
						maxX = tempX;
					if (minY > tempY)
						minY = tempY;
					if (maxY < tempY)
						maxY = tempY;
				}
			}
			RotateCameraSpacePoint = Point3d;
			//    var temp = ReconstructImage(Point3d, maxX - (maxX - minX) / 2f, maxY - (maxY - minY) / 2f);
			//       var temp = ReconstructImage(Point3d, Point3d[205*512+256].X, Point3d[205 * 512 + 256].Y);
			//var temp = ReconstructImage(Point3d, minX, maxX, minY, maxY);
			//DisplayImages(ref pictureBoxCalibarteDepthImage, newCalibrateImage);


			float xPixelPrMeter = 511 / (maxX - minX);
			float yPixelPrMeter = 423 / (maxY - minY);



			ushort[] calibrateImage = new ushort[424 * 512];

			float minvalZ = (float)(Point3d.Except(Point3d.Where(x => x.Z == float.NegativeInfinity)).Min(x => x.Z));

			if (minvalZ < 0)
			{
				minvalZ = -minvalZ;
			}
			else
			{
				minvalZ = 0;
			}


			for (int i = 0; i < Point3d.Length; i++)
			{
				if (Point3d[i].X != float.NegativeInfinity && Point3d[i].X != float.PositiveInfinity)
				{
					int xindex = (int)Math.Round(xPixelPrMeter * (Point3d[i].X - minX));
					int yindex = (int)Math.Round(yPixelPrMeter * ((maxY - minY) - (Point3d[i].Y - minY)));

					int totindex = xindex + yindex * 512;

					totindex = i;
					calibrateImage[totindex] = (ushort)((Point3d[i].Z + minvalZ) * 1000);
					if (calibrateImage[totindex] == ushort.MaxValue)
					{
						calibrateImage[totindex] = 0;
					}
				}
			}

			ushort minval = (ushort)(calibrateImage.Except(calibrateImage.Where(x => x == 0)).Min() - 1);
			float diffHiehgt = calibrateImage.Max() - minval;

			for (int i = 0; i < 424 * 512; i++)
			{
				if (calibrateImage[i] != 0)
				{
					XYRotateBytes[i] = (byte)(((calibrateImage[i] - minval) / diffHiehgt) * 255f);
				}
				else
				{
					XYRotateBytes[i] = 0;
				}

			}


			Displayer.DisplayImages2(ref pictureBoxZRotation, myKinect.RawShortIrImageData);

			XYRotateImage = new Bitmap(pictureBoxZRotation.Image);

			pictureBoxZRotation.Image = DrawingEngine.draw_workarea(VectorZRotation, XYRotateImage);

			buttonGetAvgHeightConveyor_Click(null, null);
		}

		private async void buttonGetAvgHeightConveyor_Click(object sender, EventArgs e)
		{
			if (!LiveStreamOpen)
			{
				await System.Threading.Tasks.Task.Run(() => myKinect.GetNewImages());
			}


			CameraSpacePoint[] spacePoints = new CameraSpacePoint[512 * 424];
			myKinect.coordinateMapper.MapDepthFrameToCameraSpace(myKinect.CutDepthData, spacePoints);

			double sum = 0;
			double SumBefore = 0;
			int countElm = 0;
			for (int i = 0; i < 424 * 512; i++)
			{
				if (CalibrationAreaMask[i] == 1 && spacePoints[i].Z != 0.0f)
				{
					SumBefore += spacePoints[i].Z;
					BackGroundWorkAreaDepthMask[i] = spacePoints[i].X * RotationsMatrixGlobal[2, 0] + spacePoints[i].Y * RotationsMatrixGlobal[2, 1] + spacePoints[i].Z * RotationsMatrixGlobal[2, 2];
					if (!double.IsNaN(BackGroundWorkAreaDepthMask[i]) && BackGroundWorkAreaDepthMask[i] != float.NegativeInfinity)
					{
						sum += BackGroundWorkAreaDepthMask[i];
						countElm++;
					}
				}
			}
			data_handler.save_variable(x => BackGroundWorkAreaDepthMask);
			sum /= countElm;
			avgHeightConveyorRaw = (float)SumBefore / countElm;
			avgHeightConveyorRotatet = (float)sum;
			textBoxAvgHeightCnv.Text = avgHeightConveyorRotatet.ToString();

			data_handler.save_variable(x => avgHeightConveyorRotatet);
		}

		private void buttonZRotation_Click(object sender, EventArgs e)
		{
			if (XYRotateImage == null)
				return;

			CameraSpacePoint[] Points3d = new CameraSpacePoint[424 * 512];
			myKinect.coordinateMapper.MapDepthFrameToCameraSpace(myKinect.CutDepthData, Points3d);

			CameraSpacePoint startPoint = RotateCameraSpacePoint[VectorZRotation[0].X + VectorZRotation[0].Y * 512];
			CameraSpacePoint EndPoint = RotateCameraSpacePoint[VectorZRotation[1].X + VectorZRotation[1].Y * 512];


			var thetaZ = Math.Atan2(EndPoint.X - startPoint.X, EndPoint.Y - startPoint.Y);

			double[,] XYRot = new double[,] { { Math.Cos(thetaZ), -Math.Sin(thetaZ) }, { Math.Sin(thetaZ), Math.Cos(thetaZ) } };

			CameraSpacePoint startPointRot = new CameraSpacePoint();
			CameraSpacePoint EndPointRot = new CameraSpacePoint();

			startPointRot.X = (float)(XYRot[0, 0] * startPoint.X + XYRot[0, 1] * startPoint.Y);
			startPointRot.Y = (float)(XYRot[1, 0] * startPoint.X + XYRot[1, 1] * startPoint.Y);
			EndPointRot.X = (float)(XYRot[0, 0] * EndPoint.X + XYRot[0, 1] * EndPoint.Y);
			EndPointRot.Y = (float)(XYRot[1, 0] * EndPoint.X + XYRot[1, 1] * EndPoint.Y);

			relativePointX = -EndPointRot.X;
			relativePointY = EndPointRot.Y - (EndPointRot.Y - startPointRot.Y) / 2f;

			data_handler.save_variable(x => relativePointX);
			data_handler.save_variable(x => relativePointY);

			MyMatrix RotZ = MyMatrix.RoationZ3D(thetaZ);
			double[,] RotTot = RotZ.GetDoubleArray();

			RotationsMatrixZAxis = (double[,])RotTot.Clone();
			data_handler.save_variable(x => RotationsMatrixZAxis);

			if (RotationsMatrixXYPlane != null)
			{
				RotationsMatrixGlobal = (RotZ * (new MyMatrix(RotationsMatrixXYPlane))).GetDoubleArray();
				data_handler.save_variable(x => RotationsMatrixGlobal);
			}


			for (int i = 0; i < 424; i++)
			{
				for (int j = 0; j < 512; j++)
				{
					int tempX = (int)Math.Round(RotTot[0, 0] * (j - 255) + RotTot[0, 1] * (i - 211)) + 255;
					int tempY = (int)Math.Round(RotTot[1, 0] * (j - 255) + RotTot[1, 1] * (i - 211)) + 211;
					if (tempX < 0 || tempX > 511 || tempY < 0 || tempY > 423)
					{
						newCalibrateImage[i * 512 + j] = 0;
					}
					else
					{
						newCalibrateImage[i * 512 + j] = XYRotateBytes[tempY * 512 + tempX];
					}


				}
			}

			for (int i = 0; i < Points3d.Length; i++)
			{
				if (Points3d[i].X != float.NegativeInfinity && Points3d[i].X != float.PositiveInfinity)
				{
					float tempX = (float)(RotationsMatrixGlobal[0, 0] * Points3d[i].X + RotationsMatrixGlobal[0, 1] * Points3d[i].Y + RotationsMatrixGlobal[0, 2] * Points3d[i].Z);
					float tempY = (float)(RotationsMatrixGlobal[1, 0] * Points3d[i].X + RotationsMatrixGlobal[1, 1] * Points3d[i].Y + RotationsMatrixGlobal[1, 2] * Points3d[i].Z);
					float tempZ = (float)(RotationsMatrixGlobal[2, 0] * Points3d[i].X + RotationsMatrixGlobal[2, 1] * Points3d[i].Y + RotationsMatrixGlobal[2, 2] * Points3d[i].Z);

					Points3d[i].X = tempX;
					Points3d[i].Y = tempY;
					Points3d[i].Z = tempZ;

				}
			}

			Points3d.CopyTo(RotateCameraSpacePointXYZ, 0);

			CameraSpacePoint startPoint2 = RotateCameraSpacePointXYZ[VectorZRotation[0].X + VectorZRotation[0].Y * 512];
			CameraSpacePoint EndPoint2 = RotateCameraSpacePointXYZ[VectorZRotation[1].X + VectorZRotation[1].Y * 512];

			OrigoOfPlane = startPoint2;
			XDirectionOfOrigo = EndPoint2;

			data_handler.save_variable(x => OrigoOfPlane);
			data_handler.save_variable(x => XDirectionOfOrigo);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (!LiveStreamOpen)
			{
				LiveStreamOpen = true;
				LivestreamTask2();
			}
		}

		public async Task LivestreamTask2()
		{
			while (LiveStreamOpen)
			{
				await System.Threading.Tasks.Task.Run(() => myKinect.GetNewImages());

				//         Displayer.DisplayImages(ref pictureBoxDepthImage, myKinect.CutDepthImageData, TriggerAreaPoints);
				//	Displayer.DisplayImages(ref pictureBoxIRImage, myKinect.RawShortIrImageData);
				//
					pictureBox1.Image = Displayer.GetPictureFromData(1920, 1080, myKinect.RGBRawData);
				pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
				//     pictureBoxLiveIR2.Image = pictureBoxIRImage.Image;

				TriggerSearch2();

				this.Refresh();
			}
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			try
			{
				MinDepth = Convert.ToUInt16(textBox2.Text);
				data_handler.save_variable(x => MinDepth);
				LiveStreamOpen = false;
				myKinect = new Kinect2.Kinect2Handler((int)MinDepth, (int)MaxDepth);
			}
			catch { }
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			try
			{
				MaxDepth = Convert.ToUInt16(textBox1.Text);
				data_handler.save_variable(x => MaxDepth);
				LiveStreamOpen = false;
				myKinect = new Kinect2Handler((int)MinDepth, (int)MaxDepth);
			}
			catch { }
		}

		private void pictureBoxCalibration_Click(object sender, EventArgs e)
		{
			MouseEventArgs me = (MouseEventArgs)e;
			if (me.Button == MouseButtons.Left)
			{
				System.Drawing.Point coordinates = me.Location;
				// coordinates.X /= 2;
				// coordinates.Y /= 2;
				XYPlaneRotationArea.Add(coordinates);
			}
			else
			{
				if (XYPlaneRotationArea.Count > 0)
					XYPlaneRotationArea.RemoveAt(XYPlaneRotationArea.Count - 1);
			}

			data_handler.save_variable(x => XYPlaneRotationArea);

			pictureBoxCalibration.Image = DrawingEngine.draw_workarea(XYPlaneRotationArea, CalibrationImage);
		}

		private void pictureBoxZRotation_Click(object sender, EventArgs e)
		{
			MouseEventArgs me = (MouseEventArgs)e;



			if (me.Button == MouseButtons.Left)
			{
				if (VectorZRotation.Count >= 2)
				{
					return;
				}
				System.Drawing.Point coordinates = me.Location;
				VectorZRotation.Add(coordinates);
			}
			else
			{
				if (VectorZRotation.Count > 0)
					VectorZRotation.RemoveAt(VectorZRotation.Count - 1);
			}

			data_handler.save_variable(x => VectorZRotation);

			pictureBoxZRotation.Image = DrawingEngine.draw_workarea(VectorZRotation, XYRotateImage);
		}

		private void pictureBoxMeatTriggerArea_Click(object sender, EventArgs e)
		{
			MouseEventArgs me = (MouseEventArgs)e;
			if (me.Button == MouseButtons.Left)
			{
				System.Drawing.Point coordinates = me.Location;
				// coordinates.X /= 2;
				// coordinates.Y /= 2;
				MeatAreaTrigger.Add(coordinates);
			}
			else
			{
				if (MeatAreaTrigger.Count > 0)
					MeatAreaTrigger.RemoveAt(MeatAreaTrigger.Count - 1);
			}

			data_handler.save_variable(x => MeatAreaTrigger);

			pictureBoxMeatTriggerArea.Image = DrawingEngine.draw_workarea(MeatAreaTrigger, CalibrationImage);
		}

		private void buttonUseMeatArea_Click(object sender, EventArgs e)
		{
			if (CalibrationImage == null)
				return;

			MeatAreaBackground = new ushort[424 * 512];
			byte[] MeatArea = ImageConverter.BitmapToByteArray((Bitmap)pictureBoxMeatTriggerArea.Image);
			MeatAreaMask = new byte[512 * 424];


			for (int i = 0; i < 512 * 424; i++)
			{
				int index = i * 4;
				if (MeatArea[index] == 0 && MeatArea[index + 1] > 100)
				{
					MeatAreaBackground[i] = MeatAreaBackground[i];
					MeatAreaMask[i] = 1;
				}
				else
				{
					MeatAreaBackground[i] = 0;
				}
			}
			data_handler.save_variable(x => MeatAreaMask);
			data_handler.save_variable(x => MeatAreaBackground);

		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void pictureBoxStillDepthImage_Click(object sender, EventArgs e)
		{

		}

		private void tabPage1_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void pictureBoxRGB_Click(object sender, EventArgs e)
		{

		}

		private void pictureBoxDepth_Click(object sender, EventArgs e)
		{

		}

		private void pictureBoxIR_Click(object sender, EventArgs e)
		{

		}

		private void tabPage2_Click(object sender, EventArgs e)
		{

		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void textBoxAvgHeightCnv_TextChanged(object sender, EventArgs e)
		{

		}

		private void label11_Click(object sender, EventArgs e)
		{

		}

		private void textBoxPictureNumber_TextChanged(object sender, EventArgs e)
		{

		}

		private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
		{

		}

		private void pictureBoxStillIRImage_Click(object sender, EventArgs e)
		{

		}

		private void pictureBoxStillRGBImage_Click(object sender, EventArgs e)
		{
			MouseEventArgs me = (MouseEventArgs)e;
			System.Drawing.Point coordinates = me.Location;
			coordinates.X *= 2;
			coordinates.Y *= 2;

			ColorSpacePoint[] colorCoords = new ColorSpacePoint[424 * 512];
			CameraSpacePoint[] spacePoint = new CameraSpacePoint[1920*1080];

			myKinect.coordinateMapper.MapColorFrameToCameraSpace(CutDepthStillData, spacePoint);
			int index = coordinates.X + coordinates.Y * 1920;

			var res = spacePoint[index];

			textBoxXcoord.Text = (res.X * 1000).ToString();
			textBoxYCoord.Text = (res.Y * 1000).ToString();
			textBoxZCoord.Text = (res.Z * 1000).ToString();

		}

		private void tabPage3_Click(object sender, EventArgs e)
		{

		}

		private void buttonSaveIRAsPng_Click(object sender, EventArgs e)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			if (!Directory.Exists(path + @"\IR_image"))
			{
				Directory.CreateDirectory(path + @"\IR_image");
			}
			//		checkBoxOfflineMode.Checked = true;

			for (int i = 1; i < hScrollBar1.Maximum - 9; i++)
			{
				hScrollBar1.Value = i;
				Thread.Sleep(100);
				Bitmap img = Displayer.GetGrayPictureFromBytes(512, 424, RawShortInfraredData2);
				img.Save(path + @"\IR_image\" + i.ToString() + ".png");
			}
		}

		private void buttonSaveRGBasPng_Click(object sender, EventArgs e)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			if(!Directory.Exists(path + @"\RGB_image"))
			{
				Directory.CreateDirectory(path + @"\RGB_image");
			}

			//	checkBoxOfflineMode.Checked = true;
			for (int i = 1; i < hScrollBar1.Maximum - 9; i++)
			{
				hScrollBar1.Value = i;
				Thread.Sleep(100);
				Bitmap img =Displayer.GetPictureFromData(1920, 1080, RawColorImageData);
				img.Save(path + @"\RGB_image\" + i.ToString() + ".png");
			}
		}

		private void buttonCurrentIRImage_Click(object sender, EventArgs e)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			if (!Directory.Exists(path + @"\IR_image"))
			{
				Directory.CreateDirectory(path + @"\IR_image");
			}
			//		checkBoxOfflineMode.Checked = true;

			Bitmap img = Displayer.GetGrayPictureFromBytes(512, 424, RawShortInfraredData2);
			img.Save(path + @"\IR_image\" + hScrollBar1.Value.ToString() + ".png");  

		}

		private void buttonCurrentDepth_Click(object sender, EventArgs e)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			if (!Directory.Exists(path + @"\Depth_Image"))
			{
				Directory.CreateDirectory(path + @"\Depth_Image");
			}
			//		checkBoxOfflineMode.Checked = true;

			Bitmap img = Displayer.GetGrayPictureFromBytes(512, 424, ConverterKinectData.ConvertDepthUshortToImageByte(CutDepthStillData, (int)MinDepth, (int)MaxDepth));
			img.Save(path + @"\Depth_Image\" + hScrollBar1.Value.ToString() + ".png");

		}

		private void buttonCurrentRGB_Click(object sender, EventArgs e)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			if (!Directory.Exists(path + @"\RGB_image"))
			{
				Directory.CreateDirectory(path + @"\RGB_image");
			}
			//		checkBoxOfflineMode.Checked = true;

			Bitmap img = Displayer.GetPictureFromData(1920, 1080, RawColorImageData);
			img.Save(path + @"\RGB_image\" + hScrollBar1.Value.ToString() + ".png");

		}
	}

	public static class Extension 
    {
        public static T[] RemoveAt<T>(this T[] source, int index)
        {
            T[] dest = new T[source.Length - 1];
            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            return dest;
        }
    }


    public class AlphanumComparatorFast : IComparer
    {
        public int Compare(object x, object y)
        {
            string s1 = x as string;
            if (s1 == null)
            {
                return 0;
            }
            string s2 = y as string;
            if (s2 == null)
            {
                return 0;
            }

            int len1 = s1.Length;
            int len2 = s2.Length;
            int marker1 = 0;
            int marker2 = 0;

            // Walk through two the strings with two markers.
            while (marker1 < len1 && marker2 < len2)
            {
                char ch1 = s1[marker1];
                char ch2 = s2[marker2];

                // Some buffers we can build up characters in for each chunk.
                char[] space1 = new char[len1];
                int loc1 = 0;
                char[] space2 = new char[len2];
                int loc2 = 0;

                // Walk through all following characters that are digits or
                // characters in BOTH strings starting at the appropriate marker.
                // Collect char arrays.
                do
                {
                    space1[loc1++] = ch1;
                    marker1++;

                    if (marker1 < len1)
                    {
                        ch1 = s1[marker1];
                    }
                    else
                    {
                        break;
                    }
                } while (char.IsDigit(ch1) == char.IsDigit(space1[0]));

                do
                {
                    space2[loc2++] = ch2;
                    marker2++;

                    if (marker2 < len2)
                    {
                        ch2 = s2[marker2];
                    }
                    else
                    {
                        break;
                    }
                } while (char.IsDigit(ch2) == char.IsDigit(space2[0]));

                // If we have collected numbers, compare them numerically.
                // Otherwise, if we have strings, compare them alphabetically.
                string str1 = new string(space1);
                string str2 = new string(space2);

                int result;

                if (char.IsDigit(space1[0]) && char.IsDigit(space2[0]))
                {
                    int thisNumericChunk = int.Parse(str1);
                    int thatNumericChunk = int.Parse(str2);
                    result = thisNumericChunk.CompareTo(thatNumericChunk);
                }
                else
                {
                    result = str1.CompareTo(str2);
                }

                if (result != 0)
                {
                    return result;
                }
            }
            return len1 - len2;
        }
    }

}
