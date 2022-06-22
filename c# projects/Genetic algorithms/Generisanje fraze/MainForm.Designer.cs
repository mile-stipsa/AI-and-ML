namespace Generisanje_fraze
{
    partial class frmMain
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
            this.lblPhrase = new System.Windows.Forms.Label();
            this.txtPhrase = new System.Windows.Forms.TextBox();
            this.pnlPhrase = new System.Windows.Forms.Panel();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.numMutRate = new System.Windows.Forms.NumericUpDown();
            this.lblMutRate = new System.Windows.Forms.Label();
            this.numPopSize = new System.Windows.Forms.NumericUpDown();
            this.lblPopSize = new System.Windows.Forms.Label();
            this.pnlGenPhrases = new System.Windows.Forms.Panel();
            this.lbxGenPhrases = new System.Windows.Forms.ListBox();
            this.pnlData = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblGenNumber = new System.Windows.Forms.Label();
            this.lblBestPhrase = new System.Windows.Forms.Label();
            this.lblBest = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numStopRatio = new System.Windows.Forms.NumericUpDown();
            this.pnlPhrase.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMutRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopSize)).BeginInit();
            this.pnlGenPhrases.SuspendLayout();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStopRatio)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPhrase
            // 
            this.lblPhrase.AutoSize = true;
            this.lblPhrase.Location = new System.Drawing.Point(4, 20);
            this.lblPhrase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhrase.Name = "lblPhrase";
            this.lblPhrase.Size = new System.Drawing.Size(102, 17);
            this.lblPhrase.TabIndex = 0;
            this.lblPhrase.Text = "Enter a phrase";
            // 
            // txtPhrase
            // 
            this.txtPhrase.Location = new System.Drawing.Point(111, 17);
            this.txtPhrase.MaxLength = 30;
            this.txtPhrase.Name = "txtPhrase";
            this.txtPhrase.Size = new System.Drawing.Size(363, 23);
            this.txtPhrase.TabIndex = 1;
            this.txtPhrase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhrase_KeyPress);
            // 
            // pnlPhrase
            // 
            this.pnlPhrase.Controls.Add(this.lblPhrase);
            this.pnlPhrase.Controls.Add(this.txtPhrase);
            this.pnlPhrase.Location = new System.Drawing.Point(12, 12);
            this.pnlPhrase.Name = "pnlPhrase";
            this.pnlPhrase.Size = new System.Drawing.Size(478, 67);
            this.pnlPhrase.TabIndex = 2;
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.numStopRatio);
            this.pnlOptions.Controls.Add(this.label1);
            this.pnlOptions.Controls.Add(this.numMutRate);
            this.pnlOptions.Controls.Add(this.lblMutRate);
            this.pnlOptions.Controls.Add(this.numPopSize);
            this.pnlOptions.Controls.Add(this.lblPopSize);
            this.pnlOptions.Location = new System.Drawing.Point(492, 12);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(242, 116);
            this.pnlOptions.TabIndex = 3;
            // 
            // numMutRate
            // 
            this.numMutRate.DecimalPlaces = 2;
            this.numMutRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numMutRate.Location = new System.Drawing.Point(112, 48);
            this.numMutRate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMutRate.Name = "numMutRate";
            this.numMutRate.Size = new System.Drawing.Size(120, 23);
            this.numMutRate.TabIndex = 3;
            // 
            // lblMutRate
            // 
            this.lblMutRate.AutoSize = true;
            this.lblMutRate.Location = new System.Drawing.Point(4, 50);
            this.lblMutRate.Name = "lblMutRate";
            this.lblMutRate.Size = new System.Drawing.Size(91, 17);
            this.lblMutRate.TabIndex = 2;
            this.lblMutRate.Text = "Mutation rate";
            // 
            // numPopSize
            // 
            this.numPopSize.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numPopSize.Location = new System.Drawing.Point(112, 12);
            this.numPopSize.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numPopSize.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numPopSize.Name = "numPopSize";
            this.numPopSize.Size = new System.Drawing.Size(120, 23);
            this.numPopSize.TabIndex = 1;
            this.numPopSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblPopSize
            // 
            this.lblPopSize.AutoSize = true;
            this.lblPopSize.Location = new System.Drawing.Point(4, 14);
            this.lblPopSize.Name = "lblPopSize";
            this.lblPopSize.Size = new System.Drawing.Size(104, 17);
            this.lblPopSize.TabIndex = 0;
            this.lblPopSize.Text = "Population size";
            // 
            // pnlGenPhrases
            // 
            this.pnlGenPhrases.Controls.Add(this.lbxGenPhrases);
            this.pnlGenPhrases.Location = new System.Drawing.Point(12, 85);
            this.pnlGenPhrases.Name = "pnlGenPhrases";
            this.pnlGenPhrases.Size = new System.Drawing.Size(478, 453);
            this.pnlGenPhrases.TabIndex = 4;
            // 
            // lbxGenPhrases
            // 
            this.lbxGenPhrases.ItemHeight = 16;
            this.lbxGenPhrases.Location = new System.Drawing.Point(3, 3);
            this.lbxGenPhrases.MaximumSize = new System.Drawing.Size(500, 500);
            this.lbxGenPhrases.MinimumSize = new System.Drawing.Size(354, 385);
            this.lbxGenPhrases.Name = "lbxGenPhrases";
            this.lbxGenPhrases.Size = new System.Drawing.Size(471, 436);
            this.lbxGenPhrases.TabIndex = 0;
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.lblStatus);
            this.pnlData.Controls.Add(this.lblTime);
            this.pnlData.Controls.Add(this.lblGenNumber);
            this.pnlData.Controls.Add(this.lblBestPhrase);
            this.pnlData.Controls.Add(this.lblBest);
            this.pnlData.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlData.Location = new System.Drawing.Point(492, 134);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(242, 181);
            this.pnlData.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(4, 142);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(153, 18);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status: Not running";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(4, 110);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(189, 18);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "Execution time:  0.000 s";
            // 
            // lblGenNumber
            // 
            this.lblGenNumber.AutoSize = true;
            this.lblGenNumber.Location = new System.Drawing.Point(4, 75);
            this.lblGenNumber.Name = "lblGenNumber";
            this.lblGenNumber.Size = new System.Drawing.Size(176, 18);
            this.lblGenNumber.TabIndex = 2;
            this.lblGenNumber.Text = "Generation number:  0";
            // 
            // lblBestPhrase
            // 
            this.lblBestPhrase.AutoSize = true;
            this.lblBestPhrase.Location = new System.Drawing.Point(4, 38);
            this.lblBestPhrase.Name = "lblBestPhrase";
            this.lblBestPhrase.Size = new System.Drawing.Size(232, 18);
            this.lblBestPhrase.TabIndex = 1;
            this.lblBestPhrase.Text = "xxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            // 
            // lblBest
            // 
            this.lblBest.AutoSize = true;
            this.lblBest.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBest.Location = new System.Drawing.Point(74, 10);
            this.lblBest.Name = "lblBest";
            this.lblBest.Size = new System.Drawing.Size(98, 18);
            this.lblBest.TabIndex = 0;
            this.lblBest.Text = "Best phrase";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(492, 321);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(242, 62);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Generate phrase";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(616, 457);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(118, 62);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset options";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(492, 457);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(115, 62);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "Stop generating";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnResume
            // 
            this.btnResume.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResume.Location = new System.Drawing.Point(492, 389);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(115, 62);
            this.btnResume.TabIndex = 9;
            this.btnResume.Text = "Continue generating";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPause
            // 
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(616, 389);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(118, 62);
            this.btnPause.TabIndex = 10;
            this.btnPause.Text = "Pause generation";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Stop ratio: ";
            // 
            // numStopRatio
            // 
            this.numStopRatio.DecimalPlaces = 3;
            this.numStopRatio.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numStopRatio.Location = new System.Drawing.Point(112, 81);
            this.numStopRatio.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStopRatio.Name = "numStopRatio";
            this.numStopRatio.Size = new System.Drawing.Size(120, 23);
            this.numStopRatio.TabIndex = 5;
            this.numStopRatio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 549);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlGenPhrases);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.pnlPhrase);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Phrase generation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.pnlPhrase.ResumeLayout(false);
            this.pnlPhrase.PerformLayout();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMutRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopSize)).EndInit();
            this.pnlGenPhrases.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStopRatio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPhrase;
        private System.Windows.Forms.TextBox txtPhrase;
        private System.Windows.Forms.Panel pnlPhrase;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.NumericUpDown numPopSize;
        private System.Windows.Forms.Label lblPopSize;
        private System.Windows.Forms.NumericUpDown numMutRate;
        private System.Windows.Forms.Label lblMutRate;
        private System.Windows.Forms.Panel pnlGenPhrases;
        private System.Windows.Forms.ListBox lbxGenPhrases;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Label lblBest;
        private System.Windows.Forms.Label lblBestPhrase;
        private System.Windows.Forms.Label lblGenNumber;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.NumericUpDown numStopRatio;
        private System.Windows.Forms.Label label1;
    }
}

