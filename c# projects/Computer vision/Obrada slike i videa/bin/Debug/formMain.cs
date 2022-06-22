using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Obrada_slike_i_videa.Classes;

namespace Obrada_slike_i_videa
{
    public partial class formMain : Form
    {

        VideoCapture capture;
        Image<Gray, byte> model = new Image<Gray, byte>("E:\\MAS\\I semestar\\Inteligentni sistemi\\Domaci zadaci\\Obrada slike i videa\\Obrada slike i videa\\coca.png");
        SurfFeatureDetection srf;
        public formMain()
        {
            InitializeComponent();
            srf = new SurfFeatureDetection();

            run();
        }

        private void run()
        {
            try
            {
                capture = new VideoCapture();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            Application.Idle += ProcessFrame;
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            Mat frame = capture.QueryFrame();
            Image<Gray, byte> img = frame.ToImage<Gray, byte>();
            long time;

            imboxOriginal.Image = srf.Draw(model.Mat, img.Mat, out time);
        }
    }
}
