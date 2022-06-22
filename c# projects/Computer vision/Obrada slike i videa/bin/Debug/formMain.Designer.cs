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
            this.imboxOriginal = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.imboxOriginal)).BeginInit();
            this.SuspendLayout();
            // 
            // imboxOriginal
            // 
            this.imboxOriginal.Location = new System.Drawing.Point(496, 318);
            this.imboxOriginal.Name = "imboxOriginal";
            this.imboxOriginal.Size = new System.Drawing.Size(75, 23);
            this.imboxOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imboxOriginal.TabIndex = 2;
            this.imboxOriginal.TabStop = false;
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 683);
            this.Controls.Add(this.imboxOriginal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "formMain";
            this.Text = "Obrada slike i videa";
            ((System.ComponentModel.ISupportInitialize)(this.imboxOriginal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox imboxOriginal;
    }
}

