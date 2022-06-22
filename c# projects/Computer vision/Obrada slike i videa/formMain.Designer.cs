namespace Obrada_slike_i_videa
{
    partial class formMain
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
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblContourValue = new System.Windows.Forms.Label();
            this.lblContour = new System.Windows.Forms.Label();
            this.trbContour = new System.Windows.Forms.TrackBar();
            this.lblContrastValue = new System.Windows.Forms.Label();
            this.lblBrightnessValue = new System.Windows.Forms.Label();
            this.lblContrast = new System.Windows.Forms.Label();
            this.lblBrightness = new System.Windows.Forms.Label();
            this.trbContrast = new System.Windows.Forms.TrackBar();
            this.trbBrightness = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnContourFilter = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnDetection = new System.Windows.Forms.Button();
            this.pnlSelectData = new System.Windows.Forms.Panel();
            this.cbxGPU = new System.Windows.Forms.CheckBox();
            this.btnSceneImage = new System.Windows.Forms.Button();
            this.txtSceneImage = new System.Windows.Forms.TextBox();
            this.lblSceneImage = new System.Windows.Forms.Label();
            this.btnModelImage = new System.Windows.Forms.Button();
            this.txtModelImage = new System.Windows.Forms.TextBox();
            this.lblModelImage = new System.Windows.Forms.Label();
            this.gbxSource = new System.Windows.Forms.GroupBox();
            this.rbtImage = new System.Windows.Forms.RadioButton();
            this.rbtWeb = new System.Windows.Forms.RadioButton();
            this.rbtVideo = new System.Windows.Forms.RadioButton();
            this.pnlImageShow = new System.Windows.Forms.Panel();
            this.imgResult = new Emgu.CV.UI.ImageBox();
            this.ofdModel = new System.Windows.Forms.OpenFileDialog();
            this.ofdScene = new System.Windows.Forms.OpenFileDialog();
            this.stsLabel = new System.Windows.Forms.StatusStrip();
            this.timeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlOptions.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbContour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbBrightness)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlSelectData.SuspendLayout();
            this.gbxSource.SuspendLayout();
            this.pnlImageShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgResult)).BeginInit();
            this.stsLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOptions
            // 
            this.pnlOptions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlOptions.Controls.Add(this.panel2);
            this.pnlOptions.Controls.Add(this.panel1);
            this.pnlOptions.Controls.Add(this.pnlSelectData);
            this.pnlOptions.Controls.Add(this.gbxSource);
            this.pnlOptions.Location = new System.Drawing.Point(13, 13);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(955, 215);
            this.pnlOptions.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblContourValue);
            this.panel2.Controls.Add(this.lblContour);
            this.panel2.Controls.Add(this.trbContour);
            this.panel2.Controls.Add(this.lblContrastValue);
            this.panel2.Controls.Add(this.lblBrightnessValue);
            this.panel2.Controls.Add(this.lblContrast);
            this.panel2.Controls.Add(this.lblBrightness);
            this.panel2.Controls.Add(this.trbContrast);
            this.panel2.Controls.Add(this.trbBrightness);
            this.panel2.Location = new System.Drawing.Point(450, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(321, 205);
            this.panel2.TabIndex = 4;
            // 
            // lblContourValue
            // 
            this.lblContourValue.AutoSize = true;
            this.lblContourValue.Location = new System.Drawing.Point(300, 158);
            this.lblContourValue.Name = "lblContourValue";
            this.lblContourValue.Size = new System.Drawing.Size(19, 13);
            this.lblContourValue.TabIndex = 17;
            this.lblContourValue.Text = "50";
            // 
            // lblContour
            // 
            this.lblContour.AutoSize = true;
            this.lblContour.Location = new System.Drawing.Point(127, 126);
            this.lblContour.Name = "lblContour";
            this.lblContour.Size = new System.Drawing.Size(44, 13);
            this.lblContour.TabIndex = 16;
            this.lblContour.Text = "Contour";
            // 
            // trbContour
            // 
            this.trbContour.Location = new System.Drawing.Point(4, 147);
            this.trbContour.Maximum = 255;
            this.trbContour.Name = "trbContour";
            this.trbContour.Size = new System.Drawing.Size(293, 45);
            this.trbContour.TabIndex = 15;
            this.trbContour.Value = 50;
            this.trbContour.ValueChanged += new System.EventHandler(this.trbContour_ValueChanged);
            // 
            // lblContrastValue
            // 
            this.lblContrastValue.AutoSize = true;
            this.lblContrastValue.Location = new System.Drawing.Point(300, 98);
            this.lblContrastValue.Name = "lblContrastValue";
            this.lblContrastValue.Size = new System.Drawing.Size(19, 13);
            this.lblContrastValue.TabIndex = 14;
            this.lblContrastValue.Text = "50";
            // 
            // lblBrightnessValue
            // 
            this.lblBrightnessValue.AutoSize = true;
            this.lblBrightnessValue.Location = new System.Drawing.Point(300, 38);
            this.lblBrightnessValue.Name = "lblBrightnessValue";
            this.lblBrightnessValue.Size = new System.Drawing.Size(19, 13);
            this.lblBrightnessValue.TabIndex = 13;
            this.lblBrightnessValue.Text = "50";
            // 
            // lblContrast
            // 
            this.lblContrast.AutoSize = true;
            this.lblContrast.Location = new System.Drawing.Point(127, 66);
            this.lblContrast.Name = "lblContrast";
            this.lblContrast.Size = new System.Drawing.Size(46, 13);
            this.lblContrast.TabIndex = 12;
            this.lblContrast.Text = "Contrast";
            // 
            // lblBrightness
            // 
            this.lblBrightness.AutoSize = true;
            this.lblBrightness.Location = new System.Drawing.Point(127, 4);
            this.lblBrightness.Name = "lblBrightness";
            this.lblBrightness.Size = new System.Drawing.Size(56, 13);
            this.lblBrightness.TabIndex = 11;
            this.lblBrightness.Text = "Brightness";
            // 
            // trbContrast
            // 
            this.trbContrast.Location = new System.Drawing.Point(4, 87);
            this.trbContrast.Maximum = 100;
            this.trbContrast.Name = "trbContrast";
            this.trbContrast.Size = new System.Drawing.Size(293, 45);
            this.trbContrast.TabIndex = 10;
            this.trbContrast.Value = 50;
            this.trbContrast.ValueChanged += new System.EventHandler(this.trbContrast_ValueChanged);
            // 
            // trbBrightness
            // 
            this.trbBrightness.Location = new System.Drawing.Point(1, 26);
            this.trbBrightness.Maximum = 100;
            this.trbBrightness.Name = "trbBrightness";
            this.trbBrightness.Size = new System.Drawing.Size(296, 45);
            this.trbBrightness.TabIndex = 9;
            this.trbBrightness.Value = 50;
            this.trbBrightness.ValueChanged += new System.EventHandler(this.trbBrightness_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnContourFilter);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnDetection);
            this.panel1.Location = new System.Drawing.Point(774, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 205);
            this.panel1.TabIndex = 3;
            // 
            // btnContourFilter
            // 
            this.btnContourFilter.Location = new System.Drawing.Point(3, 85);
            this.btnContourFilter.Name = "btnContourFilter";
            this.btnContourFilter.Size = new System.Drawing.Size(168, 56);
            this.btnContourFilter.TabIndex = 4;
            this.btnContourFilter.Text = "Perform contour filter";
            this.btnContourFilter.UseVisualStyleBackColor = true;
            this.btnContourFilter.Click += new System.EventHandler(this.btnContourFilter_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(3, 147);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(168, 55);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnDetection
            // 
            this.btnDetection.Location = new System.Drawing.Point(3, 5);
            this.btnDetection.Name = "btnDetection";
            this.btnDetection.Size = new System.Drawing.Size(168, 74);
            this.btnDetection.TabIndex = 2;
            this.btnDetection.Text = "Perform SURF detection";
            this.btnDetection.UseVisualStyleBackColor = true;
            this.btnDetection.Click += new System.EventHandler(this.btnDetection_Click);
            // 
            // pnlSelectData
            // 
            this.pnlSelectData.Controls.Add(this.cbxGPU);
            this.pnlSelectData.Controls.Add(this.btnSceneImage);
            this.pnlSelectData.Controls.Add(this.txtSceneImage);
            this.pnlSelectData.Controls.Add(this.lblSceneImage);
            this.pnlSelectData.Controls.Add(this.btnModelImage);
            this.pnlSelectData.Controls.Add(this.txtModelImage);
            this.pnlSelectData.Controls.Add(this.lblModelImage);
            this.pnlSelectData.Location = new System.Drawing.Point(144, 3);
            this.pnlSelectData.Name = "pnlSelectData";
            this.pnlSelectData.Size = new System.Drawing.Size(303, 205);
            this.pnlSelectData.TabIndex = 1;
            // 
            // cbxGPU
            // 
            this.cbxGPU.AutoSize = true;
            this.cbxGPU.Checked = true;
            this.cbxGPU.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxGPU.Location = new System.Drawing.Point(76, 97);
            this.cbxGPU.Name = "cbxGPU";
            this.cbxGPU.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbxGPU.Size = new System.Drawing.Size(106, 17);
            this.cbxGPU.TabIndex = 8;
            this.cbxGPU.Text = "Execute on GPU";
            this.cbxGPU.UseVisualStyleBackColor = true;
            // 
            // btnSceneImage
            // 
            this.btnSceneImage.Location = new System.Drawing.Point(243, 42);
            this.btnSceneImage.Name = "btnSceneImage";
            this.btnSceneImage.Size = new System.Drawing.Size(57, 21);
            this.btnSceneImage.TabIndex = 5;
            this.btnSceneImage.Text = "...";
            this.btnSceneImage.UseVisualStyleBackColor = true;
            this.btnSceneImage.Click += new System.EventHandler(this.btnSceneImage_Click);
            // 
            // txtSceneImage
            // 
            this.txtSceneImage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtSceneImage.Enabled = false;
            this.txtSceneImage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSceneImage.Location = new System.Drawing.Point(117, 43);
            this.txtSceneImage.Name = "txtSceneImage";
            this.txtSceneImage.Size = new System.Drawing.Size(122, 20);
            this.txtSceneImage.TabIndex = 4;
            // 
            // lblSceneImage
            // 
            this.lblSceneImage.AutoSize = true;
            this.lblSceneImage.Location = new System.Drawing.Point(3, 46);
            this.lblSceneImage.Name = "lblSceneImage";
            this.lblSceneImage.Size = new System.Drawing.Size(109, 13);
            this.lblSceneImage.TabIndex = 3;
            this.lblSceneImage.Text = "Choose scene image:";
            // 
            // btnModelImage
            // 
            this.btnModelImage.Location = new System.Drawing.Point(243, 5);
            this.btnModelImage.Name = "btnModelImage";
            this.btnModelImage.Size = new System.Drawing.Size(57, 21);
            this.btnModelImage.TabIndex = 2;
            this.btnModelImage.Text = "...";
            this.btnModelImage.UseVisualStyleBackColor = true;
            this.btnModelImage.Click += new System.EventHandler(this.btnModelImage_Click);
            // 
            // txtModelImage
            // 
            this.txtModelImage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtModelImage.Enabled = false;
            this.txtModelImage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtModelImage.Location = new System.Drawing.Point(117, 6);
            this.txtModelImage.Name = "txtModelImage";
            this.txtModelImage.Size = new System.Drawing.Size(122, 20);
            this.txtModelImage.TabIndex = 1;
            // 
            // lblModelImage
            // 
            this.lblModelImage.AutoSize = true;
            this.lblModelImage.Location = new System.Drawing.Point(3, 9);
            this.lblModelImage.Name = "lblModelImage";
            this.lblModelImage.Size = new System.Drawing.Size(108, 13);
            this.lblModelImage.TabIndex = 0;
            this.lblModelImage.Text = "Choose model image:";
            // 
            // gbxSource
            // 
            this.gbxSource.Controls.Add(this.rbtImage);
            this.gbxSource.Controls.Add(this.rbtWeb);
            this.gbxSource.Controls.Add(this.rbtVideo);
            this.gbxSource.Location = new System.Drawing.Point(3, 3);
            this.gbxSource.Name = "gbxSource";
            this.gbxSource.Size = new System.Drawing.Size(135, 205);
            this.gbxSource.TabIndex = 0;
            this.gbxSource.TabStop = false;
            this.gbxSource.Text = "Choose image source";
            // 
            // rbtImage
            // 
            this.rbtImage.AutoSize = true;
            this.rbtImage.Checked = true;
            this.rbtImage.Location = new System.Drawing.Point(7, 31);
            this.rbtImage.Name = "rbtImage";
            this.rbtImage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbtImage.Size = new System.Drawing.Size(70, 17);
            this.rbtImage.TabIndex = 0;
            this.rbtImage.TabStop = true;
            this.rbtImage.Text = "Image file";
            this.rbtImage.UseVisualStyleBackColor = true;
            this.rbtImage.CheckedChanged += new System.EventHandler(this.rbtImage_CheckedChanged);
            // 
            // rbtWeb
            // 
            this.rbtWeb.AutoSize = true;
            this.rbtWeb.Location = new System.Drawing.Point(6, 166);
            this.rbtWeb.Name = "rbtWeb";
            this.rbtWeb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbtWeb.Size = new System.Drawing.Size(71, 17);
            this.rbtWeb.TabIndex = 2;
            this.rbtWeb.Text = "Web cam";
            this.rbtWeb.UseVisualStyleBackColor = true;
            this.rbtWeb.CheckedChanged += new System.EventHandler(this.rbtImage_CheckedChanged);
            // 
            // rbtVideo
            // 
            this.rbtVideo.AutoSize = true;
            this.rbtVideo.Location = new System.Drawing.Point(9, 96);
            this.rbtVideo.Name = "rbtVideo";
            this.rbtVideo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbtVideo.Size = new System.Drawing.Size(68, 17);
            this.rbtVideo.TabIndex = 1;
            this.rbtVideo.Text = "Video file";
            this.rbtVideo.UseVisualStyleBackColor = true;
            this.rbtVideo.CheckedChanged += new System.EventHandler(this.rbtImage_CheckedChanged);
            // 
            // pnlImageShow
            // 
            this.pnlImageShow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlImageShow.Controls.Add(this.imgResult);
            this.pnlImageShow.Location = new System.Drawing.Point(13, 234);
            this.pnlImageShow.Name = "pnlImageShow";
            this.pnlImageShow.Size = new System.Drawing.Size(956, 741);
            this.pnlImageShow.TabIndex = 1;
            // 
            // imgResult
            // 
            this.imgResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgResult.Location = new System.Drawing.Point(0, 0);
            this.imgResult.Name = "imgResult";
            this.imgResult.Size = new System.Drawing.Size(952, 737);
            this.imgResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgResult.TabIndex = 2;
            this.imgResult.TabStop = false;
            // 
            // ofdModel
            // 
            this.ofdModel.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif;" +
    " *.png";
            this.ofdModel.Title = "Select image model file...";
            // 
            // ofdScene
            // 
            this.ofdScene.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif;" +
    " *.png";
            this.ofdScene.Title = "Select image scene file...";
            // 
            // stsLabel
            // 
            this.stsLabel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeLabel});
            this.stsLabel.Location = new System.Drawing.Point(0, 978);
            this.stsLabel.Name = "stsLabel";
            this.stsLabel.Size = new System.Drawing.Size(979, 22);
            this.stsLabel.TabIndex = 2;
            // 
            // timeLabel
            // 
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(86, 17);
            this.timeLabel.Text = "Execution time";
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 1000);
            this.Controls.Add(this.stsLabel);
            this.Controls.Add(this.pnlImageShow);
            this.Controls.Add(this.pnlOptions);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "formMain";
            this.Text = "Obrada slike i videa";
            this.pnlOptions.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbContour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbBrightness)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlSelectData.ResumeLayout(false);
            this.pnlSelectData.PerformLayout();
            this.gbxSource.ResumeLayout(false);
            this.gbxSource.PerformLayout();
            this.pnlImageShow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgResult)).EndInit();
            this.stsLabel.ResumeLayout(false);
            this.stsLabel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.GroupBox gbxSource;
        private System.Windows.Forms.RadioButton rbtImage;
        private System.Windows.Forms.RadioButton rbtWeb;
        private System.Windows.Forms.RadioButton rbtVideo;
        private System.Windows.Forms.Panel pnlImageShow;
        private Emgu.CV.UI.ImageBox imgResult;
        private System.Windows.Forms.Panel pnlSelectData;
        private System.Windows.Forms.Button btnSceneImage;
        private System.Windows.Forms.TextBox txtSceneImage;
        private System.Windows.Forms.Label lblSceneImage;
        private System.Windows.Forms.Button btnModelImage;
        private System.Windows.Forms.TextBox txtModelImage;
        private System.Windows.Forms.Label lblModelImage;
        private System.Windows.Forms.CheckBox cbxGPU;
        private System.Windows.Forms.OpenFileDialog ofdModel;
        private System.Windows.Forms.OpenFileDialog ofdScene;
        private System.Windows.Forms.Button btnDetection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip stsLabel;
        private System.Windows.Forms.ToolStripStatusLabel timeLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblContrastValue;
        private System.Windows.Forms.Label lblBrightnessValue;
        private System.Windows.Forms.Label lblContrast;
        private System.Windows.Forms.Label lblBrightness;
        private System.Windows.Forms.TrackBar trbContrast;
        private System.Windows.Forms.TrackBar trbBrightness;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnContourFilter;
        private System.Windows.Forms.Label lblContourValue;
        private System.Windows.Forms.Label lblContour;
        private System.Windows.Forms.TrackBar trbContour;
    }
}

