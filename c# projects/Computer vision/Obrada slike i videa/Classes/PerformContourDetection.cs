using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obrada_slike_i_videa.Classes
{

    /*Klasa koja nam omogucava detekciju kontura na slici, video snimku ili web kameri*/
    public class PerformContourDetection
    {

        #region Attributes

        private VideoCapture capture; //promenljiva za prikaz videa ili web kamere

        #endregion

        #region Contour detection

        /*Funkcija koja detektuje konture na web kameri, kao parametri se prosledjuju promenljiva gde se cuva vreme izvrsenja
         i koeficijent na osnovu kojeg ce se detektovati konture*/
        public Mat WebCameraContourDetection(out long time, int treshold)
        {
            Mat result;

            if (this.capture == null) // ukoliko objekat nije instanciran
                this.capture = new VideoCapture(); // kreira se

            Mat frame = this.capture.QueryFrame(); // uzima se frejm

            result = ContourDetection.FindContour(out time,frame, treshold); //vrsi se detekcija kontura i prikaz 

            return result; //vraca se kreirana slika
        }

        /*Funkcija koja detektuje konture na video snimku, kao parametri se prosledjuju promenljiva gde se cuva vreme izvrsenja,
         putanja do video snimka i koeficijent na osnovu kojeg ce se detektovati konture*/
        public Mat VideoContourDetection(out long time, string sceneImage, int treshold)
        {
            Mat result;

            if (this.capture == null) //ukoliko objekat nije instancran
                this.capture = new VideoCapture(sceneImage); //ucitava se video sa zadate putanje
            
            Mat frame = this.capture.QueryFrame(); //uzima se frejm

            result = ContourDetection.FindContour(out time, frame, treshold); //vrsi se detekcija kontura i prikaz

            return result; //vraca se kreirana slika
        }

        /*Funkcija koja detektuje konture na slici, kao parametri se prosledjuju promenljiva gde se cuva vreme izvrsenja,
         putanja do slike i koeficijent na osnovu kojeg ce se detektovati konture*/
        public Mat ImageContourDetection(out long time, string sceneImage, int treshold)
        {
            Mat result;

            Image<Bgr, byte> frame = new Image<Bgr, byte>(sceneImage); // ucitava se slika sa zeljene putanje

            result = ContourDetection.FindContour(out time, frame.Mat, treshold); // vrsi se detekcija kontura i prikaz

            return result; //vraca se kreirana slika
        }

        #endregion

        #region Others functions

        /*funkcija za brisanje podataka*/
        public void Dispose()
        {
            if (this.capture != null) // ukoliko je objekat instanciran
                this.capture.Dispose(); // brise podatke
        }

        #endregion

    }
}
