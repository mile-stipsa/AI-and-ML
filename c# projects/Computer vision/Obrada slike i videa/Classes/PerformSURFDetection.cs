using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Obrada_slike_i_videa.Classes;

namespace Obrada_slike_i_videa.Classes
{

    /* Klasa koja nam omoguca detekciju objekta na slikama,  video snimcima ili web kameri*/
    public class PerformSURFDetection
    {

        #region Attributes

        private VideoCapture capture; // promenljiva za prikaz videa ili web kamere
        private Image<Bgr, byte> modelImage; // slika objekta
        private Image<Bgr, byte> sceneImage; // slika na kojoj se trazi objekat
        private Image<Gray, byte> grayModelImage; // gray slika objekta
        private Image<Gray, byte> graySceneImage; // gray slika na kojoj se trazi objekat
        private SURFFeatureDetection surf; // instanca klase koja detektuje i iscrtava gde se objekat nalazi

        #endregion

        #region Constructors

        public PerformSURFDetection(String model) // konstruktor, prosledjuje se slika objekta
        {
            this.modelImage = new Image<Bgr, byte>(model); // inicijalizacija slike objekta
            this.grayModelImage = new Image<Gray, byte>(model); // konverzija u gray model
            this.surf = new SURFFeatureDetection(); // inicijalizacija instance klase za detekciju
        }

        #endregion

        #region Detect functions

        /* detektcija objekta koriscenjem web kamere, kao parametri se prosledjuju promenljiva gde se cuva vreme izvrsenja
         koeficijent kontrasta, koeficijent osvetljenja kao i mod izvrsenja
         */
        public Mat WebCameraSurfDetection(out long time, double alpha, double beta, bool GPU)
        {
            Mat result;
            if(this.capture==null) // ukoliko nije kreirana instanca
                this.capture = new VideoCapture(); // kreira se

            Mat frame = this.capture.QueryFrame(); // uzima se frejm sa web kamere
            if (GPU) // ukoliko je mod izvrsenja na grafickoj
            {
                frame.ConvertTo(frame, Emgu.CV.CvEnum.DepthType.Default, alpha/50, beta-50); //primenjuju se filteri osvetljena i kontrasta
                this.graySceneImage = frame.ToImage<Gray, byte>(); // konverzija slike u gray
                result = this.surf.Draw(this.grayModelImage.Mat, this.graySceneImage.Mat, out time, GPU); // iscrtavanje kljucnih, uparenih tacaka i kontrure objekta
                this.graySceneImage.Dispose(); // brisanje gray slike na kojoj se trazi objekat
                frame.Dispose(); //brisanje bgr slike na kojoj se trazi objekat
            }
            else
            {
                frame.ConvertTo(frame, Emgu.CV.CvEnum.DepthType.Default, alpha / 50, beta - 50); //primenjuju se filteri osvetljenja i kontrasta
                this.sceneImage = frame.ToImage<Bgr, byte>(); // konverzija slike u bgr
                result = this.surf.Draw(this.modelImage.Mat, this.sceneImage.Mat, out time, GPU); //iscrtavanje kljucnih, uparenih tacaka i konture objekta
                this.sceneImage.Dispose(); //brisanje bgr slike na kojoj se trazi objekat
                frame.Dispose();
            }

            return result; // vraca se iscrtana slika

        }

        /* detektcija objekta na video snimku, kao parametri se prosledjuju putanja do video snimka, promenljiva gde se cuva vreme izvrsenja
         koeficijent kontrasta, koeficijent osvetljenja kao i mod izvrsenja

        Funkcija je identicna kao i prethodna, jedina razlika je da se objekat trazi na video snimku, stoga se kod kreiranja capture prosledjuje putanja video snimka
         */
        public Mat VideoSurfDetection(String sceneImage, out long time, double alpha, double beta, bool GPU)
        {
            Mat result;
            if (this.capture == null) //ukoliko capture nije instanciran
                this.capture = new VideoCapture(sceneImage); //ucitava se video snimak sa zeljene lokacije

            Mat frame = this.capture.QueryFrame(); // uzima se frejm
            if (GPU) // ukoliko je izabrani mod gpu
            {
                frame.ConvertTo(frame, Emgu.CV.CvEnum.DepthType.Default, alpha / 50, beta - 50); // konverzija na osnovu osvetljenja i kontrasta
                this.graySceneImage = frame.ToImage<Gray, byte>(); // konverzija slike na kojoj se trazi objekat u gray
                result = this.surf.Draw(this.grayModelImage.Mat, this.graySceneImage.Mat, out time, GPU); //iscrtavanje kljucnih, uparenih tacaka i konture objekta
                this.graySceneImage.Dispose(); //brisanje gray slike na kojoj se trazi objekat
                frame.Dispose(); //brisanje trenutnog frejma
            }
            else
            {
                frame.ConvertTo(frame, Emgu.CV.CvEnum.DepthType.Default, alpha / 50, beta - 50); //konverzija na osnovu osvetljenja i kontrasta
                this.sceneImage = frame.ToImage<Bgr, byte>(); // konverzija u bgr sliku 
                result = this.surf.Draw(this.modelImage.Mat, this.sceneImage.Mat, out time, GPU);//iscrtavanje kljucnih, uparenih tacaka i konture objekta
                this.sceneImage.Dispose(); // brisanje bgr slike na kojoj se trazi objekat
                frame.Dispose(); //brisanje trenutnog frejma
            }

            return result;

        }

        /* detektcija objekta na slici, kao parametri se prosledjuju putanja do slike, promenljiva gde se cuva vreme izvrsenja
         koeficijent kontrasta, koeficijent osvetljenja kao i mod izvrsenja

        Funkcija je identicna kao i prethodne dve, jedina razlika je da se objekat trazi slici, stoga se slika ucitava na osnovu zadate putanje
         */
        public Mat ImageSurfDetection(String sceneImage, out long time, double alpha, double beta, bool GPU)
        {
            Mat result;
            Mat frame;
            if (GPU) // ukoliko je izvsenje na grafickoj kartici
            {
                this.graySceneImage = new Image<Gray, byte>(sceneImage); //ucitava se gray slika na kojoj se trazi objekat
                frame = this.graySceneImage.Mat; // uzima se Mat objekat slike
                frame.ConvertTo(frame, Emgu.CV.CvEnum.DepthType.Default, alpha / 50, beta - 50); // konverzija na osnovu osvetljenja i kontrasta
                result = this.surf.Draw(this.grayModelImage.Mat, frame, out time, GPU); //iscrtavanje kljucnih, uparenih tacaka i konture objekta
                this.graySceneImage.Dispose(); // brisanje gray slike na kojoj se trazi objekat
                frame.Dispose(); //brisanje bgr slike na kojoj se trazi objekat

            }
            else
            {
                this.sceneImage = new Image<Bgr, byte>(sceneImage); // ucitava se bgr slika na kojoj se trazi objekat
                frame = this.sceneImage.Mat; // uzima se Mat objekat slike
                frame.ConvertTo(frame, Emgu.CV.CvEnum.DepthType.Default, alpha / 50, beta - 50); // konverzija na osnovu osvetljenja i kontrasta
                result = this.surf.Draw(this.modelImage.Mat, this.sceneImage.Mat, out time, GPU); //iscrtavanje kljucnih, uparenih tacaka i konture objekta
                this.sceneImage.Dispose(); // brisanje bgr slike na kojoj se objekat trazi;
                frame.Dispose();
            }

            return result;
        }

        #endregion

        #region Others functions

        /* Funkcija koja brise podatke */
        public void Dispose()
        {
            if(this.capture!=null) //ukoliko je capture instanciran
                this.capture.Dispose(); //brise se

            if (this.sceneImage != null) // ukoliko je bgr slika na kojoj se trazi objekat instancirana, odnosno ucitana
                this.sceneImage.Dispose(); // brise se

            if(this.graySceneImage!= null) // ukoliko je gray slika na kojoj se trazi objekat instancirana, odnosno ucitana
                this.graySceneImage.Dispose(); // brise se
            
            this. grayModelImage.Dispose(); // brise se gray slika objekta
            this.modelImage.Dispose(); //brise se bfr slika objekta
        }

        #endregion

    }
}
