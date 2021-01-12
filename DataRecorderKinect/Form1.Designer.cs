namespace DataRecorderKinect
{
    partial class Form1
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxNumberOfImage = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxMaxDepth = new System.Windows.Forms.TextBox();
			this.textBoxMinDepth = new System.Windows.Forms.TextBox();
			this.pictureBoxRGB = new System.Windows.Forms.PictureBox();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonTriggerImage = new System.Windows.Forms.Button();
			this.pictureBoxTriggerImage = new System.Windows.Forms.PictureBox();
			this.pictureBoxDepth = new System.Windows.Forms.PictureBox();
			this.pictureBoxIR = new System.Windows.Forms.PictureBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.buttonUseMeatArea = new System.Windows.Forms.Button();
			this.pictureBoxMeatTriggerArea = new System.Windows.Forms.PictureBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.buttonGetAvgHeightConveyor = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.textBoxAvgHeightCnv = new System.Windows.Forms.TextBox();
			this.buttonDeleteCalibrationArea = new System.Windows.Forms.Button();
			this.buttonGetOneDepthImage = new System.Windows.Forms.Button();
			this.buttonZRotation = new System.Windows.Forms.Button();
			this.buttonDoCalibration = new System.Windows.Forms.Button();
			this.pictureBoxZRotation = new System.Windows.Forms.PictureBox();
			this.pictureBoxCalibration = new System.Windows.Forms.PictureBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.buttonSaveRGBasPng = new System.Windows.Forms.Button();
			this.buttonSaveIRAsPng = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxZCoord = new System.Windows.Forms.TextBox();
			this.textBoxYCoord = new System.Windows.Forms.TextBox();
			this.textBoxXcoord = new System.Windows.Forms.TextBox();
			this.buttonDeleteImage = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.textBoxPictureNumber = new System.Windows.Forms.TextBox();
			this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.pictureBoxStillRGBImage = new System.Windows.Forms.PictureBox();
			this.pictureBoxStillIRImage = new System.Windows.Forms.PictureBox();
			this.pictureBoxStillDepthImage = new System.Windows.Forms.PictureBox();
			this.buttonCurrentIRImage = new System.Windows.Forms.Button();
			this.buttonCurrentDepth = new System.Windows.Forms.Button();
			this.buttonCurrentRGB = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxRGB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTriggerImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDepth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIR)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxMeatTriggerArea)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxZRotation)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCalibration)).BeginInit();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxStillRGBImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxStillIRImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxStillDepthImage)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1880, 987);
			this.tabControl1.TabIndex = 0;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label10);
			this.tabPage1.Controls.Add(this.textBox3);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.textBoxNumberOfImage);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.textBoxMaxDepth);
			this.tabPage1.Controls.Add(this.textBoxMinDepth);
			this.tabPage1.Controls.Add(this.pictureBoxRGB);
			this.tabPage1.Controls.Add(this.buttonOk);
			this.tabPage1.Controls.Add(this.buttonTriggerImage);
			this.tabPage1.Controls.Add(this.pictureBoxTriggerImage);
			this.tabPage1.Controls.Add(this.pictureBoxDepth);
			this.tabPage1.Controls.Add(this.pictureBoxIR);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1872, 961);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Record From Side";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(633, 486);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(54, 13);
			this.label10.TabIndex = 14;
			this.label10.Text = "Framerate";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(617, 502);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(100, 20);
			this.textBox3.TabIndex = 13;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(508, 486);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "NumberOfImage";
			// 
			// textBoxNumberOfImage
			// 
			this.textBoxNumberOfImage.Location = new System.Drawing.Point(501, 502);
			this.textBoxNumberOfImage.Name = "textBoxNumberOfImage";
			this.textBoxNumberOfImage.Size = new System.Drawing.Size(100, 20);
			this.textBoxNumberOfImage.TabIndex = 11;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(382, 486);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Max Depth mm";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(254, 486);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Min Depth mm";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// textBoxMaxDepth
			// 
			this.textBoxMaxDepth.Location = new System.Drawing.Point(371, 502);
			this.textBoxMaxDepth.Name = "textBoxMaxDepth";
			this.textBoxMaxDepth.Size = new System.Drawing.Size(100, 20);
			this.textBoxMaxDepth.TabIndex = 8;
			this.textBoxMaxDepth.TextChanged += new System.EventHandler(this.textBoxMaxDepth_TextChanged);
			// 
			// textBoxMinDepth
			// 
			this.textBoxMinDepth.Location = new System.Drawing.Point(243, 502);
			this.textBoxMinDepth.Name = "textBoxMinDepth";
			this.textBoxMinDepth.Size = new System.Drawing.Size(100, 20);
			this.textBoxMinDepth.TabIndex = 7;
			this.textBoxMinDepth.TextChanged += new System.EventHandler(this.textBoxMinDepth_TextChanged);
			// 
			// pictureBoxRGB
			// 
			this.pictureBoxRGB.Location = new System.Drawing.Point(946, 436);
			this.pictureBoxRGB.Name = "pictureBoxRGB";
			this.pictureBoxRGB.Size = new System.Drawing.Size(960, 540);
			this.pictureBoxRGB.TabIndex = 5;
			this.pictureBoxRGB.TabStop = false;
			this.pictureBoxRGB.Click += new System.EventHandler(this.pictureBoxRGB_Click);
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point(119, 502);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(92, 23);
			this.buttonOk.TabIndex = 4;
			this.buttonOk.Text = "Start Collecting ";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonTriggerImage
			// 
			this.buttonTriggerImage.Location = new System.Drawing.Point(6, 502);
			this.buttonTriggerImage.Name = "buttonTriggerImage";
			this.buttonTriggerImage.Size = new System.Drawing.Size(107, 23);
			this.buttonTriggerImage.TabIndex = 3;
			this.buttonTriggerImage.Text = "Get Trigger Image";
			this.buttonTriggerImage.UseVisualStyleBackColor = true;
			this.buttonTriggerImage.Click += new System.EventHandler(this.buttonTriggerImage_Click);
			// 
			// pictureBoxTriggerImage
			// 
			this.pictureBoxTriggerImage.Location = new System.Drawing.Point(6, 531);
			this.pictureBoxTriggerImage.Name = "pictureBoxTriggerImage";
			this.pictureBoxTriggerImage.Size = new System.Drawing.Size(512, 424);
			this.pictureBoxTriggerImage.TabIndex = 2;
			this.pictureBoxTriggerImage.TabStop = false;
			this.pictureBoxTriggerImage.Click += new System.EventHandler(this.pictureBoxTriggerImage_Click);
			// 
			// pictureBoxDepth
			// 
			this.pictureBoxDepth.Location = new System.Drawing.Point(524, 6);
			this.pictureBoxDepth.Name = "pictureBoxDepth";
			this.pictureBoxDepth.Size = new System.Drawing.Size(512, 424);
			this.pictureBoxDepth.TabIndex = 1;
			this.pictureBoxDepth.TabStop = false;
			this.pictureBoxDepth.Click += new System.EventHandler(this.pictureBoxDepth_Click);
			// 
			// pictureBoxIR
			// 
			this.pictureBoxIR.Location = new System.Drawing.Point(6, 6);
			this.pictureBoxIR.Name = "pictureBoxIR";
			this.pictureBoxIR.Size = new System.Drawing.Size(512, 424);
			this.pictureBoxIR.TabIndex = 0;
			this.pictureBoxIR.TabStop = false;
			this.pictureBoxIR.Click += new System.EventHandler(this.pictureBoxIR_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.pictureBox1);
			this.tabPage2.Controls.Add(this.button1);
			this.tabPage2.Controls.Add(this.buttonUseMeatArea);
			this.tabPage2.Controls.Add(this.pictureBoxMeatTriggerArea);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.Controls.Add(this.textBox1);
			this.tabPage2.Controls.Add(this.textBox2);
			this.tabPage2.Controls.Add(this.buttonGetAvgHeightConveyor);
			this.tabPage2.Controls.Add(this.label8);
			this.tabPage2.Controls.Add(this.textBoxAvgHeightCnv);
			this.tabPage2.Controls.Add(this.buttonDeleteCalibrationArea);
			this.tabPage2.Controls.Add(this.buttonGetOneDepthImage);
			this.tabPage2.Controls.Add(this.buttonZRotation);
			this.tabPage2.Controls.Add(this.buttonDoCalibration);
			this.tabPage2.Controls.Add(this.pictureBoxZRotation);
			this.tabPage2.Controls.Add(this.pictureBoxCalibration);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1872, 961);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Record from above";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(1090, 80);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(776, 437);
			this.pictureBox1.TabIndex = 51;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(1215, 51);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 23);
			this.button1.TabIndex = 50;
			this.button1.Text = "Start collecting";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// buttonUseMeatArea
			// 
			this.buttonUseMeatArea.Location = new System.Drawing.Point(187, 488);
			this.buttonUseMeatArea.Name = "buttonUseMeatArea";
			this.buttonUseMeatArea.Size = new System.Drawing.Size(125, 23);
			this.buttonUseMeatArea.TabIndex = 49;
			this.buttonUseMeatArea.Text = "Use Meat Area";
			this.buttonUseMeatArea.UseVisualStyleBackColor = true;
			this.buttonUseMeatArea.Click += new System.EventHandler(this.buttonUseMeatArea_Click);
			// 
			// pictureBoxMeatTriggerArea
			// 
			this.pictureBoxMeatTriggerArea.Location = new System.Drawing.Point(3, 517);
			this.pictureBoxMeatTriggerArea.Name = "pictureBoxMeatTriggerArea";
			this.pictureBoxMeatTriggerArea.Size = new System.Drawing.Size(512, 424);
			this.pictureBoxMeatTriggerArea.TabIndex = 48;
			this.pictureBoxMeatTriggerArea.TabStop = false;
			this.pictureBoxMeatTriggerArea.Click += new System.EventHandler(this.pictureBoxMeatTriggerArea_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(1332, 9);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(78, 13);
			this.label7.TabIndex = 47;
			this.label7.Text = "Max Depth mm";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(1226, 9);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(75, 13);
			this.label9.TabIndex = 46;
			this.label9.Text = "Min Depth mm";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(1321, 25);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 45;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(1215, 25);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 20);
			this.textBox2.TabIndex = 44;
			this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			// 
			// buttonGetAvgHeightConveyor
			// 
			this.buttonGetAvgHeightConveyor.Location = new System.Drawing.Point(1090, 51);
			this.buttonGetAvgHeightConveyor.Name = "buttonGetAvgHeightConveyor";
			this.buttonGetAvgHeightConveyor.Size = new System.Drawing.Size(100, 23);
			this.buttonGetAvgHeightConveyor.TabIndex = 43;
			this.buttonGetAvgHeightConveyor.Text = "Get Avg Heigth";
			this.buttonGetAvgHeightConveyor.UseVisualStyleBackColor = true;
			this.buttonGetAvgHeightConveyor.Click += new System.EventHandler(this.buttonGetAvgHeightConveyor_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(1087, 9);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(108, 13);
			this.label8.TabIndex = 42;
			this.label8.Text = "Avg Heigth Conveyor";
			// 
			// textBoxAvgHeightCnv
			// 
			this.textBoxAvgHeightCnv.Location = new System.Drawing.Point(1090, 25);
			this.textBoxAvgHeightCnv.Name = "textBoxAvgHeightCnv";
			this.textBoxAvgHeightCnv.Size = new System.Drawing.Size(100, 20);
			this.textBoxAvgHeightCnv.TabIndex = 41;
			this.textBoxAvgHeightCnv.TextChanged += new System.EventHandler(this.textBoxAvgHeightCnv_TextChanged);
			// 
			// buttonDeleteCalibrationArea
			// 
			this.buttonDeleteCalibrationArea.Location = new System.Drawing.Point(148, 8);
			this.buttonDeleteCalibrationArea.Name = "buttonDeleteCalibrationArea";
			this.buttonDeleteCalibrationArea.Size = new System.Drawing.Size(131, 23);
			this.buttonDeleteCalibrationArea.TabIndex = 40;
			this.buttonDeleteCalibrationArea.Text = "Delete Calibration Area";
			this.buttonDeleteCalibrationArea.UseVisualStyleBackColor = true;
			this.buttonDeleteCalibrationArea.Click += new System.EventHandler(this.buttonDeleteCalibrationArea_Click);
			// 
			// buttonGetOneDepthImage
			// 
			this.buttonGetOneDepthImage.Location = new System.Drawing.Point(6, 8);
			this.buttonGetOneDepthImage.Name = "buttonGetOneDepthImage";
			this.buttonGetOneDepthImage.Size = new System.Drawing.Size(136, 23);
			this.buttonGetOneDepthImage.TabIndex = 39;
			this.buttonGetOneDepthImage.Text = "Get One Depth Image";
			this.buttonGetOneDepthImage.UseVisualStyleBackColor = true;
			this.buttonGetOneDepthImage.Click += new System.EventHandler(this.buttonGetOneDepthImage_Click);
			// 
			// buttonZRotation
			// 
			this.buttonZRotation.Location = new System.Drawing.Point(563, 8);
			this.buttonZRotation.Name = "buttonZRotation";
			this.buttonZRotation.Size = new System.Drawing.Size(118, 23);
			this.buttonZRotation.TabIndex = 38;
			this.buttonZRotation.Text = "Calibrate XY rotation";
			this.buttonZRotation.UseVisualStyleBackColor = true;
			this.buttonZRotation.Click += new System.EventHandler(this.buttonZRotation_Click);
			// 
			// buttonDoCalibration
			// 
			this.buttonDoCalibration.Location = new System.Drawing.Point(285, 8);
			this.buttonDoCalibration.Name = "buttonDoCalibration";
			this.buttonDoCalibration.Size = new System.Drawing.Size(102, 23);
			this.buttonDoCalibration.TabIndex = 37;
			this.buttonDoCalibration.Text = "Calibrate Plane";
			this.buttonDoCalibration.UseVisualStyleBackColor = true;
			this.buttonDoCalibration.Click += new System.EventHandler(this.buttonDoCalibration_Click);
			// 
			// pictureBoxZRotation
			// 
			this.pictureBoxZRotation.Location = new System.Drawing.Point(563, 37);
			this.pictureBoxZRotation.Name = "pictureBoxZRotation";
			this.pictureBoxZRotation.Size = new System.Drawing.Size(512, 424);
			this.pictureBoxZRotation.TabIndex = 36;
			this.pictureBoxZRotation.TabStop = false;
			this.pictureBoxZRotation.Click += new System.EventHandler(this.pictureBoxZRotation_Click);
			// 
			// pictureBoxCalibration
			// 
			this.pictureBoxCalibration.Location = new System.Drawing.Point(6, 37);
			this.pictureBoxCalibration.Name = "pictureBoxCalibration";
			this.pictureBoxCalibration.Size = new System.Drawing.Size(512, 424);
			this.pictureBoxCalibration.TabIndex = 35;
			this.pictureBoxCalibration.TabStop = false;
			this.pictureBoxCalibration.Click += new System.EventHandler(this.pictureBoxCalibration_Click);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.buttonCurrentRGB);
			this.tabPage3.Controls.Add(this.buttonCurrentDepth);
			this.tabPage3.Controls.Add(this.buttonCurrentIRImage);
			this.tabPage3.Controls.Add(this.buttonSaveRGBasPng);
			this.tabPage3.Controls.Add(this.buttonSaveIRAsPng);
			this.tabPage3.Controls.Add(this.label6);
			this.tabPage3.Controls.Add(this.label5);
			this.tabPage3.Controls.Add(this.label4);
			this.tabPage3.Controls.Add(this.textBoxZCoord);
			this.tabPage3.Controls.Add(this.textBoxYCoord);
			this.tabPage3.Controls.Add(this.textBoxXcoord);
			this.tabPage3.Controls.Add(this.buttonDeleteImage);
			this.tabPage3.Controls.Add(this.label11);
			this.tabPage3.Controls.Add(this.textBoxPictureNumber);
			this.tabPage3.Controls.Add(this.hScrollBar1);
			this.tabPage3.Controls.Add(this.radioButton2);
			this.tabPage3.Controls.Add(this.radioButton1);
			this.tabPage3.Controls.Add(this.pictureBoxStillRGBImage);
			this.tabPage3.Controls.Add(this.pictureBoxStillIRImage);
			this.tabPage3.Controls.Add(this.pictureBoxStillDepthImage);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(1872, 961);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "ShowImage";
			this.tabPage3.UseVisualStyleBackColor = true;
			this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
			// 
			// buttonSaveRGBasPng
			// 
			this.buttonSaveRGBasPng.Location = new System.Drawing.Point(1234, 247);
			this.buttonSaveRGBasPng.Name = "buttonSaveRGBasPng";
			this.buttonSaveRGBasPng.Size = new System.Drawing.Size(163, 23);
			this.buttonSaveRGBasPng.TabIndex = 22;
			this.buttonSaveRGBasPng.Text = "Save all RGB image as png";
			this.buttonSaveRGBasPng.UseVisualStyleBackColor = true;
			this.buttonSaveRGBasPng.Click += new System.EventHandler(this.buttonSaveRGBasPng_Click);
			// 
			// buttonSaveIRAsPng
			// 
			this.buttonSaveIRAsPng.Location = new System.Drawing.Point(1234, 218);
			this.buttonSaveIRAsPng.Name = "buttonSaveIRAsPng";
			this.buttonSaveIRAsPng.Size = new System.Drawing.Size(163, 23);
			this.buttonSaveIRAsPng.TabIndex = 21;
			this.buttonSaveIRAsPng.Text = "Save all IR as png";
			this.buttonSaveIRAsPng.UseVisualStyleBackColor = true;
			this.buttonSaveIRAsPng.Click += new System.EventHandler(this.buttonSaveIRAsPng_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(1422, 374);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 13);
			this.label6.TabIndex = 20;
			this.label6.Text = "Z in mm";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(1339, 374);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 13);
			this.label5.TabIndex = 19;
			this.label5.Text = "Y in mm";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(1250, 374);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 13);
			this.label4.TabIndex = 18;
			this.label4.Text = "X in mm";
			// 
			// textBoxZCoord
			// 
			this.textBoxZCoord.Location = new System.Drawing.Point(1406, 390);
			this.textBoxZCoord.Name = "textBoxZCoord";
			this.textBoxZCoord.Size = new System.Drawing.Size(80, 20);
			this.textBoxZCoord.TabIndex = 17;
			// 
			// textBoxYCoord
			// 
			this.textBoxYCoord.Location = new System.Drawing.Point(1320, 390);
			this.textBoxYCoord.Name = "textBoxYCoord";
			this.textBoxYCoord.Size = new System.Drawing.Size(80, 20);
			this.textBoxYCoord.TabIndex = 16;
			// 
			// textBoxXcoord
			// 
			this.textBoxXcoord.Location = new System.Drawing.Point(1234, 390);
			this.textBoxXcoord.Name = "textBoxXcoord";
			this.textBoxXcoord.Size = new System.Drawing.Size(80, 20);
			this.textBoxXcoord.TabIndex = 15;
			// 
			// buttonDeleteImage
			// 
			this.buttonDeleteImage.Location = new System.Drawing.Point(692, 492);
			this.buttonDeleteImage.Name = "buttonDeleteImage";
			this.buttonDeleteImage.Size = new System.Drawing.Size(115, 23);
			this.buttonDeleteImage.TabIndex = 14;
			this.buttonDeleteImage.Text = "Delete Image";
			this.buttonDeleteImage.UseVisualStyleBackColor = true;
			this.buttonDeleteImage.Click += new System.EventHandler(this.buttonDeleteImage_Click);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(479, 478);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(80, 13);
			this.label11.TabIndex = 13;
			this.label11.Text = "Picture Number";
			this.label11.Click += new System.EventHandler(this.label11_Click);
			// 
			// textBoxPictureNumber
			// 
			this.textBoxPictureNumber.Location = new System.Drawing.Point(468, 494);
			this.textBoxPictureNumber.Name = "textBoxPictureNumber";
			this.textBoxPictureNumber.Size = new System.Drawing.Size(100, 20);
			this.textBoxPictureNumber.TabIndex = 12;
			this.textBoxPictureNumber.TextChanged += new System.EventHandler(this.textBoxPictureNumber_TextChanged);
			// 
			// hScrollBar1
			// 
			this.hScrollBar1.Location = new System.Drawing.Point(6, 436);
			this.hScrollBar1.Name = "hScrollBar1";
			this.hScrollBar1.Size = new System.Drawing.Size(922, 31);
			this.hScrollBar1.TabIndex = 11;
			this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
			this.hScrollBar1.ValueChanged += new System.EventHandler(this.hScrollBar1_ValueChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(1042, 33);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(87, 17);
			this.radioButton2.TabIndex = 10;
			this.radioButton2.Text = "Offline Image";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(1042, 10);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(87, 17);
			this.radioButton1.TabIndex = 9;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Online Image";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.UseWaitCursor = true;
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// pictureBoxStillRGBImage
			// 
			this.pictureBoxStillRGBImage.Location = new System.Drawing.Point(946, 436);
			this.pictureBoxStillRGBImage.Name = "pictureBoxStillRGBImage";
			this.pictureBoxStillRGBImage.Size = new System.Drawing.Size(960, 540);
			this.pictureBoxStillRGBImage.TabIndex = 8;
			this.pictureBoxStillRGBImage.TabStop = false;
			this.pictureBoxStillRGBImage.Click += new System.EventHandler(this.pictureBoxStillRGBImage_Click);
			// 
			// pictureBoxStillIRImage
			// 
			this.pictureBoxStillIRImage.Location = new System.Drawing.Point(524, 6);
			this.pictureBoxStillIRImage.Name = "pictureBoxStillIRImage";
			this.pictureBoxStillIRImage.Size = new System.Drawing.Size(512, 424);
			this.pictureBoxStillIRImage.TabIndex = 7;
			this.pictureBoxStillIRImage.TabStop = false;
			this.pictureBoxStillIRImage.Click += new System.EventHandler(this.pictureBoxStillIRImage_Click);
			// 
			// pictureBoxStillDepthImage
			// 
			this.pictureBoxStillDepthImage.Location = new System.Drawing.Point(6, 6);
			this.pictureBoxStillDepthImage.Name = "pictureBoxStillDepthImage";
			this.pictureBoxStillDepthImage.Size = new System.Drawing.Size(512, 424);
			this.pictureBoxStillDepthImage.TabIndex = 6;
			this.pictureBoxStillDepthImage.TabStop = false;
			this.pictureBoxStillDepthImage.Click += new System.EventHandler(this.pictureBoxStillDepthImage_Click);
			// 
			// buttonCurrentIRImage
			// 
			this.buttonCurrentIRImage.Location = new System.Drawing.Point(1234, 114);
			this.buttonCurrentIRImage.Name = "buttonCurrentIRImage";
			this.buttonCurrentIRImage.Size = new System.Drawing.Size(163, 23);
			this.buttonCurrentIRImage.TabIndex = 23;
			this.buttonCurrentIRImage.Text = "Save current IR as png";
			this.buttonCurrentIRImage.UseVisualStyleBackColor = true;
			this.buttonCurrentIRImage.Click += new System.EventHandler(this.buttonCurrentIRImage_Click);
			// 
			// buttonCurrentDepth
			// 
			this.buttonCurrentDepth.Location = new System.Drawing.Point(1234, 143);
			this.buttonCurrentDepth.Name = "buttonCurrentDepth";
			this.buttonCurrentDepth.Size = new System.Drawing.Size(163, 23);
			this.buttonCurrentDepth.TabIndex = 24;
			this.buttonCurrentDepth.Text = "Save current depth as png";
			this.buttonCurrentDepth.UseVisualStyleBackColor = true;
			this.buttonCurrentDepth.Click += new System.EventHandler(this.buttonCurrentDepth_Click);
			// 
			// buttonCurrentRGB
			// 
			this.buttonCurrentRGB.Location = new System.Drawing.Point(1234, 172);
			this.buttonCurrentRGB.Name = "buttonCurrentRGB";
			this.buttonCurrentRGB.Size = new System.Drawing.Size(163, 23);
			this.buttonCurrentRGB.TabIndex = 25;
			this.buttonCurrentRGB.Text = "Save current RGB as png";
			this.buttonCurrentRGB.UseVisualStyleBackColor = true;
			this.buttonCurrentRGB.Click += new System.EventHandler(this.buttonCurrentRGB_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1904, 1011);
			this.Controls.Add(this.tabControl1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxRGB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTriggerImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxDepth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIR)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxMeatTriggerArea)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxZRotation)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxCalibration)).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxStillRGBImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxStillIRImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxStillDepthImage)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBoxRGB;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonTriggerImage;
        private System.Windows.Forms.PictureBox pictureBoxTriggerImage;
        private System.Windows.Forms.PictureBox pictureBoxDepth;
        private System.Windows.Forms.PictureBox pictureBoxIR;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMaxDepth;
        private System.Windows.Forms.TextBox textBoxMinDepth;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox pictureBoxStillRGBImage;
        private System.Windows.Forms.PictureBox pictureBoxStillIRImage;
        private System.Windows.Forms.PictureBox pictureBoxStillDepthImage;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxPictureNumber;
        private System.Windows.Forms.Button buttonDeleteImage;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button buttonUseMeatArea;
		private System.Windows.Forms.PictureBox pictureBoxMeatTriggerArea;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button buttonGetAvgHeightConveyor;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBoxAvgHeightCnv;
		private System.Windows.Forms.Button buttonDeleteCalibrationArea;
		private System.Windows.Forms.Button buttonGetOneDepthImage;
		private System.Windows.Forms.Button buttonZRotation;
		private System.Windows.Forms.Button buttonDoCalibration;
		private System.Windows.Forms.PictureBox pictureBoxZRotation;
		private System.Windows.Forms.PictureBox pictureBoxCalibration;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxNumberOfImage;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxZCoord;
		private System.Windows.Forms.TextBox textBoxYCoord;
		private System.Windows.Forms.TextBox textBoxXcoord;
		private System.Windows.Forms.Button buttonSaveRGBasPng;
		private System.Windows.Forms.Button buttonSaveIRAsPng;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button buttonCurrentRGB;
		private System.Windows.Forms.Button buttonCurrentDepth;
		private System.Windows.Forms.Button buttonCurrentIRImage;
	}
}

