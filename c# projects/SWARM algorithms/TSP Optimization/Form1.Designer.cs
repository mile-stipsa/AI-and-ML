namespace TSP_Optimization
{
    partial class tsp_optimization
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
            this.pnlAdjacentNode = new System.Windows.Forms.Panel();
            this.numBeta = new System.Windows.Forms.NumericUpDown();
            this.numAlpha = new System.Windows.Forms.NumericUpDown();
            this.lblBeta = new System.Windows.Forms.Label();
            this.lblAlpha = new System.Windows.Forms.Label();
            this.lblAdjacentText = new System.Windows.Forms.Label();
            this.pnlPheromones = new System.Windows.Forms.Panel();
            this.numDecrease = new System.Windows.Forms.NumericUpDown();
            this.numIncrease = new System.Windows.Forms.NumericUpDown();
            this.lblDecrease = new System.Windows.Forms.Label();
            this.lblIncrease = new System.Windows.Forms.Label();
            this.lblPheromoneFactors = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.numIterations = new System.Windows.Forms.NumericUpDown();
            this.numAnts = new System.Windows.Forms.NumericUpDown();
            this.numPlaces = new System.Windows.Forms.NumericUpDown();
            this.lblIterations = new System.Windows.Forms.Label();
            this.lblAnts = new System.Windows.Forms.Label();
            this.lblPlaces = new System.Windows.Forms.Label();
            this.lblMainParam = new System.Windows.Forms.Label();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lbxInfo = new System.Windows.Forms.ListBox();
            this.lblInitial = new System.Windows.Forms.Label();
            this.lblBestInit = new System.Windows.Forms.Label();
            this.lblBestFound = new System.Windows.Forms.Label();
            this.lblFound = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.pnlAdjacentNode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlpha)).BeginInit();
            this.pnlPheromones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDecrease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIncrease)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAnts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlaces)).BeginInit();
            this.pnlInfo.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAdjacentNode
            // 
            this.pnlAdjacentNode.Controls.Add(this.numBeta);
            this.pnlAdjacentNode.Controls.Add(this.numAlpha);
            this.pnlAdjacentNode.Controls.Add(this.lblBeta);
            this.pnlAdjacentNode.Controls.Add(this.lblAlpha);
            this.pnlAdjacentNode.Controls.Add(this.lblAdjacentText);
            this.pnlAdjacentNode.Location = new System.Drawing.Point(305, 156);
            this.pnlAdjacentNode.Name = "pnlAdjacentNode";
            this.pnlAdjacentNode.Size = new System.Drawing.Size(281, 98);
            this.pnlAdjacentNode.TabIndex = 0;
            // 
            // numBeta
            // 
            this.numBeta.Location = new System.Drawing.Point(164, 68);
            this.numBeta.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numBeta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBeta.Name = "numBeta";
            this.numBeta.Size = new System.Drawing.Size(114, 20);
            this.numBeta.TabIndex = 4;
            this.numBeta.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numAlpha
            // 
            this.numAlpha.Location = new System.Drawing.Point(164, 34);
            this.numAlpha.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numAlpha.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAlpha.Name = "numAlpha";
            this.numAlpha.Size = new System.Drawing.Size(114, 20);
            this.numAlpha.TabIndex = 3;
            this.numAlpha.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblBeta
            // 
            this.lblBeta.AutoSize = true;
            this.lblBeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeta.Location = new System.Drawing.Point(3, 68);
            this.lblBeta.Name = "lblBeta";
            this.lblBeta.Size = new System.Drawing.Size(123, 16);
            this.lblBeta.TabIndex = 2;
            this.lblBeta.Text = "Parameter beta: ";
            // 
            // lblAlpha
            // 
            this.lblAlpha.AutoSize = true;
            this.lblAlpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlpha.Location = new System.Drawing.Point(3, 34);
            this.lblAlpha.Name = "lblAlpha";
            this.lblAlpha.Size = new System.Drawing.Size(131, 16);
            this.lblAlpha.TabIndex = 1;
            this.lblAlpha.Text = "Parameter alpha: ";
            // 
            // lblAdjacentText
            // 
            this.lblAdjacentText.AutoSize = true;
            this.lblAdjacentText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdjacentText.Location = new System.Drawing.Point(15, 0);
            this.lblAdjacentText.Name = "lblAdjacentText";
            this.lblAdjacentText.Size = new System.Drawing.Size(253, 16);
            this.lblAdjacentText.TabIndex = 0;
            this.lblAdjacentText.Text = "Influence of adjacent node distance";
            // 
            // pnlPheromones
            // 
            this.pnlPheromones.Controls.Add(this.numDecrease);
            this.pnlPheromones.Controls.Add(this.numIncrease);
            this.pnlPheromones.Controls.Add(this.lblDecrease);
            this.pnlPheromones.Controls.Add(this.lblIncrease);
            this.pnlPheromones.Controls.Add(this.lblPheromoneFactors);
            this.pnlPheromones.Location = new System.Drawing.Point(305, 260);
            this.pnlPheromones.Name = "pnlPheromones";
            this.pnlPheromones.Size = new System.Drawing.Size(281, 103);
            this.pnlPheromones.TabIndex = 1;
            // 
            // numDecrease
            // 
            this.numDecrease.DecimalPlaces = 2;
            this.numDecrease.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numDecrease.Location = new System.Drawing.Point(164, 64);
            this.numDecrease.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDecrease.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numDecrease.Name = "numDecrease";
            this.numDecrease.Size = new System.Drawing.Size(117, 20);
            this.numDecrease.TabIndex = 5;
            this.numDecrease.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // numIncrease
            // 
            this.numIncrease.DecimalPlaces = 1;
            this.numIncrease.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numIncrease.Location = new System.Drawing.Point(164, 31);
            this.numIncrease.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numIncrease.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numIncrease.Name = "numIncrease";
            this.numIncrease.Size = new System.Drawing.Size(114, 20);
            this.numIncrease.TabIndex = 4;
            this.numIncrease.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblDecrease
            // 
            this.lblDecrease.AutoSize = true;
            this.lblDecrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDecrease.Location = new System.Drawing.Point(3, 64);
            this.lblDecrease.Name = "lblDecrease";
            this.lblDecrease.Size = new System.Drawing.Size(127, 16);
            this.lblDecrease.TabIndex = 3;
            this.lblDecrease.Text = "Decrease factor: ";
            // 
            // lblIncrease
            // 
            this.lblIncrease.AutoSize = true;
            this.lblIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncrease.Location = new System.Drawing.Point(3, 31);
            this.lblIncrease.Name = "lblIncrease";
            this.lblIncrease.Size = new System.Drawing.Size(119, 16);
            this.lblIncrease.TabIndex = 2;
            this.lblIncrease.Text = "Increase factor: ";
            // 
            // lblPheromoneFactors
            // 
            this.lblPheromoneFactors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPheromoneFactors.AutoSize = true;
            this.lblPheromoneFactors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPheromoneFactors.Location = new System.Drawing.Point(72, 0);
            this.lblPheromoneFactors.Name = "lblPheromoneFactors";
            this.lblPheromoneFactors.Size = new System.Drawing.Size(138, 16);
            this.lblPheromoneFactors.TabIndex = 1;
            this.lblPheromoneFactors.Text = "Pheromone factors";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.numIterations);
            this.pnlMain.Controls.Add(this.numAnts);
            this.pnlMain.Controls.Add(this.numPlaces);
            this.pnlMain.Controls.Add(this.lblIterations);
            this.pnlMain.Controls.Add(this.lblAnts);
            this.pnlMain.Controls.Add(this.lblPlaces);
            this.pnlMain.Controls.Add(this.lblMainParam);
            this.pnlMain.Location = new System.Drawing.Point(305, 12);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(281, 138);
            this.pnlMain.TabIndex = 2;
            // 
            // numIterations
            // 
            this.numIterations.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numIterations.Location = new System.Drawing.Point(164, 106);
            this.numIterations.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numIterations.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numIterations.Name = "numIterations";
            this.numIterations.Size = new System.Drawing.Size(114, 20);
            this.numIterations.TabIndex = 6;
            this.numIterations.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // numAnts
            // 
            this.numAnts.Location = new System.Drawing.Point(164, 67);
            this.numAnts.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numAnts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAnts.Name = "numAnts";
            this.numAnts.Size = new System.Drawing.Size(114, 20);
            this.numAnts.TabIndex = 5;
            this.numAnts.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // numPlaces
            // 
            this.numPlaces.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numPlaces.Location = new System.Drawing.Point(164, 29);
            this.numPlaces.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numPlaces.Name = "numPlaces";
            this.numPlaces.Size = new System.Drawing.Size(114, 20);
            this.numPlaces.TabIndex = 4;
            this.numPlaces.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // lblIterations
            // 
            this.lblIterations.AutoSize = true;
            this.lblIterations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIterations.Location = new System.Drawing.Point(3, 106);
            this.lblIterations.Name = "lblIterations";
            this.lblIterations.Size = new System.Drawing.Size(155, 16);
            this.lblIterations.TabIndex = 3;
            this.lblIterations.Text = "Number of iterations: ";
            // 
            // lblAnts
            // 
            this.lblAnts.AutoSize = true;
            this.lblAnts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnts.Location = new System.Drawing.Point(3, 67);
            this.lblAnts.Name = "lblAnts";
            this.lblAnts.Size = new System.Drawing.Size(120, 16);
            this.lblAnts.TabIndex = 2;
            this.lblAnts.Text = "Number of ants: ";
            // 
            // lblPlaces
            // 
            this.lblPlaces.AutoSize = true;
            this.lblPlaces.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaces.Location = new System.Drawing.Point(3, 29);
            this.lblPlaces.Name = "lblPlaces";
            this.lblPlaces.Size = new System.Drawing.Size(138, 16);
            this.lblPlaces.TabIndex = 1;
            this.lblPlaces.Text = "Number of places: ";
            // 
            // lblMainParam
            // 
            this.lblMainParam.AutoSize = true;
            this.lblMainParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainParam.Location = new System.Drawing.Point(86, 0);
            this.lblMainParam.Name = "lblMainParam";
            this.lblMainParam.Size = new System.Drawing.Size(124, 16);
            this.lblMainParam.TabIndex = 0;
            this.lblMainParam.Text = "Main parameters";
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.lbxInfo);
            this.pnlInfo.Location = new System.Drawing.Point(12, 12);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(287, 351);
            this.pnlInfo.TabIndex = 3;
            // 
            // lbxInfo
            // 
            this.lbxInfo.FormattingEnabled = true;
            this.lbxInfo.Location = new System.Drawing.Point(3, 3);
            this.lbxInfo.Name = "lbxInfo";
            this.lbxInfo.Size = new System.Drawing.Size(281, 342);
            this.lbxInfo.TabIndex = 0;
            // 
            // lblInitial
            // 
            this.lblInitial.AutoSize = true;
            this.lblInitial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitial.Location = new System.Drawing.Point(224, 375);
            this.lblInitial.Name = "lblInitial";
            this.lblInitial.Size = new System.Drawing.Size(119, 16);
            this.lblInitial.TabIndex = 4;
            this.lblInitial.Text = "Best initial route";
            // 
            // lblBestInit
            // 
            this.lblBestInit.AutoSize = true;
            this.lblBestInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBestInit.Location = new System.Drawing.Point(9, 402);
            this.lblBestInit.Name = "lblBestInit";
            this.lblBestInit.Size = new System.Drawing.Size(577, 13);
            this.lblBestInit.TabIndex = 5;
            this.lblBestInit.Text = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" +
    "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            // 
            // lblBestFound
            // 
            this.lblBestFound.AutoSize = true;
            this.lblBestFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBestFound.Location = new System.Drawing.Point(9, 468);
            this.lblBestFound.Name = "lblBestFound";
            this.lblBestFound.Size = new System.Drawing.Size(577, 13);
            this.lblBestFound.TabIndex = 7;
            this.lblBestFound.Text = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" +
    "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            // 
            // lblFound
            // 
            this.lblFound.AutoSize = true;
            this.lblFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFound.Location = new System.Drawing.Point(224, 441);
            this.lblFound.Name = "lblFound";
            this.lblFound.Size = new System.Drawing.Size(120, 16);
            this.lblFound.TabIndex = 6;
            this.lblFound.Text = "Best found route";
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(3, 3);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 65);
            this.btnFind.TabIndex = 8;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.lblStatus);
            this.pnlButtons.Controls.Add(this.btnReset);
            this.pnlButtons.Controls.Add(this.btnStop);
            this.pnlButtons.Controls.Add(this.btnResume);
            this.pnlButtons.Controls.Add(this.btnPause);
            this.pnlButtons.Controls.Add(this.btnFind);
            this.pnlButtons.Location = new System.Drawing.Point(15, 494);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(571, 69);
            this.pnlButtons.TabIndex = 9;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(408, 27);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(137, 16);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "Status: Not running";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(327, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 64);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(246, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 64);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnResume
            // 
            this.btnResume.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResume.Location = new System.Drawing.Point(84, 3);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(75, 65);
            this.btnResume.TabIndex = 10;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnPause
            // 
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(165, 3);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 65);
            this.btnPause.TabIndex = 9;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // tsp_optimization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 575);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblBestFound);
            this.Controls.Add(this.lblFound);
            this.Controls.Add(this.lblBestInit);
            this.Controls.Add(this.lblInitial);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlPheromones);
            this.Controls.Add(this.pnlAdjacentNode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "tsp_optimization";
            this.Text = "Newspaper delivery";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.tsp_optimization_FormClosing);
            this.pnlAdjacentNode.ResumeLayout(false);
            this.pnlAdjacentNode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlpha)).EndInit();
            this.pnlPheromones.ResumeLayout(false);
            this.pnlPheromones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDecrease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIncrease)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAnts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlaces)).EndInit();
            this.pnlInfo.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlAdjacentNode;
        private System.Windows.Forms.Label lblAdjacentText;
        private System.Windows.Forms.Label lblBeta;
        private System.Windows.Forms.Label lblAlpha;
        private System.Windows.Forms.Panel pnlPheromones;
        private System.Windows.Forms.Label lblPheromoneFactors;
        private System.Windows.Forms.Label lblIncrease;
        private System.Windows.Forms.Label lblDecrease;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblMainParam;
        private System.Windows.Forms.Label lblPlaces;
        private System.Windows.Forms.Label lblAnts;
        private System.Windows.Forms.Label lblIterations;
        private System.Windows.Forms.NumericUpDown numIterations;
        private System.Windows.Forms.NumericUpDown numAnts;
        private System.Windows.Forms.NumericUpDown numPlaces;
        private System.Windows.Forms.NumericUpDown numAlpha;
        private System.Windows.Forms.NumericUpDown numBeta;
        private System.Windows.Forms.NumericUpDown numDecrease;
        private System.Windows.Forms.NumericUpDown numIncrease;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.ListBox lbxInfo;
        private System.Windows.Forms.Label lblInitial;
        private System.Windows.Forms.Label lblBestInit;
        private System.Windows.Forms.Label lblBestFound;
        private System.Windows.Forms.Label lblFound;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label lblStatus;
    }
}

