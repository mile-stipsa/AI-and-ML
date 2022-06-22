using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace Obrada_slike_i_videa.Classes
{

    /*Staticka klasa koja detektuje i iscrtava konture*/
    public static class ContourDetection
    {
        /*Staticka funkcija koja detektuje, iscrtava konture, i vraca tako iscrtanu sliku
          kao parametri se prosledjuje promenljiva gde ce se cuvati vreme izvrsenja, slika
          na kojoj se traze konture, kao i koeficijent na osnovu koga ce se detektovati konture
        */
        public static Mat FindContour(out long time, Mat sceneImage, int treshold)
        {
            Stopwatch watch; // promenljiva pomocu koje cemo meriti vreme
            watch = Stopwatch.StartNew(); // inicijalizovanje promenljive i pocetak merenja vremena
            Image<Bgr, byte> imgInput = sceneImage.ToImage<Bgr,byte>(); // konvertovanje slike u Bgr format
            Image<Gray, byte> imgOutput = imgInput.Convert<Gray, byte>(); //konvertovanje slike u Gray format

            imgOutput = imgOutput.ThresholdBinary(new Gray(treshold), new Gray(255)); // menja vrednosti piksela, ukoliko je piksel>treshold piksel postaje 0, inace 255

            Image<Gray, byte> imgOut = new Image<Gray, byte>(imgInput.Width, imgInput.Height, new Gray(255)); //kreira odredisnu sliku

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint(); // inicijalizacija vektora kontura

            Mat hierarchy = new Mat(); //inicijalizacija hijerarhije
            CvInvoke.FindContours(imgOutput, contours, hierarchy, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple); //nalazenje kontura, vraca kao listu
            CvInvoke.DrawContours(imgOut, contours, -1, new MCvScalar(0, 0, 255)); // crtanje kontura u imgOut slici

            watch.Stop(); // kraj merenja vremena

            time = watch.ElapsedMilliseconds; //cuvanje proteklog vremena

            //brisanje podataka
            imgInput.Dispose();
            imgOutput.Dispose();
            contours.Dispose();
            hierarchy.Dispose();

            return imgOut.Mat; //vracanje slike
        }
    }
}
