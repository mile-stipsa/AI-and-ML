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
using Obrada_slike_i_videa.Classes;

namespace Obrada_slike_i_videa
{
    public partial class formMain : Form
    {

        #region Attributes

        private String modelImage; //putanja do slike objekta koji se trazi
        private String sceneImage; // putanja do slike na kojoj se trazi objekat
        private PerformSURFDetection detect; // instanca klase za detekciju objekta
        private PerformContourDetection contour; // instanca klase za detekciju kontura

        #endregion

        #region Form Constructors

        public formMain()
        {
            InitializeComponent();
        }

        #endregion

        #region Form functions

        #region Form events

        private void formMain_FormClosing(object sender, FormClosingEventArgs e) // prilikom zatvaranja forme
        {
            this.DetachContourFunctions(); // uklanjanje funkcija i brisanje promenljivih za detekciju kontura
            this.DetachSURFFunctions(); // uklanjanje funkcija i brisanje promenljivih za detekciju objekta
        }

        #endregion

        #region ValueChanged

        private void trbBrightness_ValueChanged(object sender, EventArgs e) // prilikom promene vrednosti osvetljenja
        {
            this.lblBrightnessValue.Text = this.trbBrightness.Value.ToString(); // azurira vrednost osvetljenja u labeli
        }

        private void trbContrast_ValueChanged(object sender, EventArgs e) //prilikom promene vrednosti kontrasta
        {
            this.lblContrastValue.Text = this.trbContrast.Value.ToString(); // azurira vrednost kontrasta u labeli
        }

        private void trbContour_ValueChanged(object sender, EventArgs e) //prilikom promene vrednosti parametra na osnovu koga se detektuju konture
        {
            this.lblContourValue.Text = this.trbContour.Value.ToString(); // azurira se vrednost parametra u labeli
        }

        private void rbtImage_CheckedChanged(object sender, EventArgs e) // na osnovu cekiranog dugmeta bira se sta se ucitava
        {
            if (this.rbtImage.Checked) // ukoliko je izabrana slika
            {
                this.ofdScene.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"; //postavlja se filter za selekciju slika
                this.ofdScene.Title = "Select image scene file..."; // postavlja se naslov openFileDialog-\a
                this.btnSceneImage.Enabled = true; // omogucava se odabir  slike na kojoj se trazi objekat
                return;
            }

            if (this.rbtVideo.Checked) // ukoliko je izabran video snimak
            {
                //postavlja se filter za selekciju video snimka
                this.ofdScene.Filter = "All Videos Files | *.dat; *.wmv; *.3g2; *.3gp; *.3gp2; *.3gpp; *.amv; *.asf; *.avi; *.bin; *.cue; *.divx; *.dv; *.flv; *.gxf; *.iso; *.m1v; *.m2v; *.m2t; *.m2ts; *.m4v; " +
                  " *.mkv; *.mov; *.mp2; *.mp2v; *.mp4; *.mp4v; *.mpa; *.mpe; *.mpeg; *.mpeg1; *.mpeg2; *.mpeg4; *.mpg; *.mpv2; *.mts; *.nsv; *.nuv; *.ogg; *.ogm; *.ogv; *.ogx; *.ps; *.rec; *.rm; *.rmvb; *.tod; *.ts; *.tts; *.vob; *.vro; *.webm";
                this.ofdScene.Title = "Select video scene file..."; // postavlja se naslov openFileDialog-a
                this.btnSceneImage.Enabled = true; // omogucava se odabir video snimka na kom ce se traziti objekat
                return;
            }

            if (this.rbtWeb.Checked) // ukoliko je izabrana web kamera
            {
                this.btnSceneImage.Enabled = false; // onemogucava se dugme za odabir slika ili video gde ce se traziti objekat
                return;
            }

        }

        #endregion

        #region Buttons

        private void btnStop_Click(object sender, EventArgs e) // klikom na dugme Stop
        {
            this.DetachSURFFunctions(); // uklanjanje funkcija i brisanje promenljivih za detekciju objekta
            this.DetachContourFunctions(); // uklanjanje funkcija i brisanje promenljivih za detekciju kontura
        }

        private void btnModelImage_Click(object sender, EventArgs e) // klikom na dugme model image
        {
            if (this.ofdModel.ShowDialog() == DialogResult.OK) // otvara se prozor za odabir slike objekta koji se detektuje i prati
            {
                this.modelImage = this.ofdModel.FileName; // cuva se putanja do slike
                this.txtModelImage.Text = this.modelImage; // azurira se textBox
            }

        }

        private void btnSceneImage_Click(object sender, EventArgs e) // klikom na dugme scene image
        {
            if (this.ofdScene.ShowDialog() == DialogResult.OK) // otvara se prozor za odabir slike/videa gde ce se traziti objekta
            {
                this.sceneImage = this.ofdScene.FileName; // cuva se putanja do izabrane slike/videa
                this.txtSceneImage.Text = this.sceneImage; // azurira se textBox

                if (rbtVideo.Checked) // ukoliko se uzima video za obradu
                {
                    Application.Idle -= ProcessImageFrame; // uklanjaju se dogadjaji za obradu slike
                    Application.Idle -= ProcessImageFrameContour;
                }
            }
        }

        private void btnDetection_Click(object sender, EventArgs e) // klikom na dugme za detekciju objekta
        {
            this.DetachContourFunctions(); // uklanjanje funkcija i brisanje promenljivih za detekciju kontura

            if (this.CheckParameters()) // ukoliko su svi parametri uneseni
            {
                if (this.rbtWeb.Checked) // ukoliko je odabrana web kamera
                {
                    this.WebCameraDetection(); // detekcija se vrsi koriscenjem web kamere
                    return;
                }

                if (this.rbtImage.Checked) // ukoliko je odabrana slika
                {
                    this.ImageDetection(); // detekcija se vrsi na slici
                    return;
                }

                if (this.rbtVideo.Checked) //ukoliko je odabran vide snimak
                {
                    this.VideoDetection(); //detekcija se vrsi na video snimku
                    return;
                }
            }
            else // ukoliko parametri nisu dobro uneseni
                MessageBox.Show("Please enter all parameters!", "Parameters exceptions"); //prikazuje se poruka
        }

        private void btnContourFilter_Click(object sender, EventArgs e)
        {
            this.DetachSURFFunctions(); // uklanjanje funkcija i brisanje promenljivih za detekciju objekta
            if (this.CheckParametersContour()) // ukoliko su parametri dobro uneseni
            {
                if (this.rbtWeb.Checked) // ukoliko je izabrana web kamera
                {
                    this.WebCameraContour(); // detekcija kontura se vrsi na web kameri
                    return;
                }

                if (this.rbtImage.Checked) // ukoliko je izabrana slika
                {
                    this.ImageContour(); // detekcija kontura se vrsi na slici
                    return;
                }

                if (this.rbtVideo.Checked) // ukoliko je izabran video snimak
                {
                    this.VideoContour(); // detekcija kontura se vrsi na video snimku
                    return;
                }
            }
            else // ukoliko parametri nisu dobro uneseni
                MessageBox.Show("Please enter all parameters!", "Parameters exceptions"); // prikazuje se poruka
        }

        #endregion

        #endregion

        #region SURF detect functions

        #region Detect functions

        private void CreateDetector() // kreira se detektor objekta na slici
        {
            this.DetachSURFFunctions(); // uklanjanje funkcija i brisanje promenljivih za detekciju objekta
            try
            {
                this.detect = new PerformSURFDetection(this.modelImage); // kreira se detektor 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void WebCameraDetection() // funkcija koja kreira i postavlja dogadjaj za detekciju preko web kamere
        {
            this.CreateDetector(); //kreiranje detektora
            Application.Idle += this.ProcessWebFrame; // dodavanje dogadjaja za web kameru
            Application.Idle -= this.ProcessVideoFrame; // uklanjanje dogadjaja video snimak
            Application.Idle -= this.ProcessImageFrame; // uklanjanje dogadjaja za sliku
        }

        private void VideoDetection() // funkcija koja kreira i postavlja dogadjaj za detekciju preko video snimka
        {
            this.CreateDetector(); //kreiranje detektora
            Application.Idle -= this.ProcessWebFrame; //uklanjanje dogadjaja za web kameru
            Application.Idle += this.ProcessVideoFrame; // dodavanje dogadjaja za video snimak
            Application.Idle -= this.ProcessImageFrame; // uklanjanje dogadjaja za sliku
        }

        private void ImageDetection() // funkcija koja kreira i postavlja dogadjaj za detekciju preko slike
        {
            this.CreateDetector(); //kreiranje detektora
            Application.Idle -= this.ProcessWebFrame; //uklanjanje dogadjaja za web kameru
            Application.Idle -= this.ProcessVideoFrame; // uklanjanje dogadjaja za video snimak
            Application.Idle += this.ProcessImageFrame; // dodavanje dogadjaja za sliku
        }

        private void ProcessWebFrame(object sender, EventArgs e) //dogadjaj za web kameru
        {
            long time;
            this.imgResult.Image = this.detect.WebCameraSurfDetection(out time, (double)this.trbContrast.Value, (double)this.trbBrightness.Value, this.cbxGPU.Checked); //detekcija objekta i smestanje rezultata u imageBox
            this.timeLabel.Text = time.ToString() + "miliseconds"; // prikaz vremena izvrsenja
        }

        private void ProcessVideoFrame(object sender, EventArgs e) // dogadjaj za video snimak
        {
            long time;
            this.imgResult.Image = this.detect.VideoSurfDetection(this.sceneImage, out time, (double)this.trbContrast.Value, (double)this.trbBrightness.Value, this.cbxGPU.Checked); //detekcija objekta i smestanje rezultata u imageBox
            this.timeLabel.Text = time.ToString() + "miliseconds"; //prikaz vremena izvrsenja
        }
        
        private void  ProcessImageFrame(object sender, EventArgs e) //dogadjaj za sliku
        {
            long time;
            this.imgResult.Image = this.detect.ImageSurfDetection(this.sceneImage, out time, (double)this.trbContrast.Value, (double)this.trbBrightness.Value, this.cbxGPU.Checked); //detekcija objekta i smestanje rezultata u imageBox
            this.timeLabel.Text = time.ToString() + "miliseconds"; //prikaz vremena izvrsenja
        }

        #endregion

        #region Others functions

        private bool CheckParameters() //funkcija koja proverava da li su svi parametri dobro uneti
        {
            if ((this.sceneImage != null && this.modelImage != null) || (this.modelImage != null && this.rbtWeb.Checked))
            {
                return true;
            }
            else
            {
                return false;
                
            }
        }

        private void DetachSURFFunctions() // funkcija koja uklanja dogadjaje i brise podatke
        {
            Application.Idle -= this.ProcessWebFrame; //uklanja dogadjaj za web kameru
            Application.Idle -= this.ProcessVideoFrame; // uklanja dogadjaj za video snimak
            Application.Idle -= this.ProcessImageFrame; // uklanja dogadjaj za sliku

            if (this.detect != null) // ukoliko je objekat inicijalizovan
                this.detect.Dispose(); //brise podatke
        }

        #endregion

        #endregion

        #region Contour detect functions

        #region Contour functions
        private void CreateContour() // kreira se filter kontura na slici
        {
            this.DetachContourFunctions(); // uklanjanje funkcija i brisanje promenljivih za detekciju kontura
            try
            {
                this.contour = new PerformContourDetection(); // kreiranje objekta za detekciju kontura
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void WebCameraContour() // funkcija koja kreira i postavlja dogadjaj za detekciju preko web kamere
        {
            this.CreateContour(); // kreiranje detektora
            Application.Idle += this.ProcessWebFrameContour; //dodavanje dogadjaja za web kameru
            Application.Idle -= this.ProcessVideoFrameContour; // uklanjanje dogadjaja za video snimak
            Application.Idle -= this.ProcessImageFrameContour; // uklanjanje dogadja za sliku
        }

        private void VideoContour()// funkcija koja kreira i postavlja dogadjaj za detekciju preko video snimka
        {
            this.CreateContour(); // kreiranje detektora
            Application.Idle -= this.ProcessWebFrameContour; //uklanjanje dogadjaja za web kameru
            Application.Idle += this.ProcessVideoFrameContour; // dodavanje dogadjaja za video snimak
            Application.Idle -= this.ProcessImageFrameContour; // uklanjanje dogadjaja za sliku
        }

        private void ImageContour() // funkcija koja kreira i postavlja dogadjaj za detekciju preko slike
        {
            this.CreateContour(); // kreiranje detektora
            Application.Idle -= this.ProcessWebFrameContour; // uklanjanje dogadjaja za web kameru
            Application.Idle -= this.ProcessVideoFrameContour; // uklanjanje dogadjaja za video snimak
            Application.Idle += this.ProcessImageFrameContour; // dodavanje dogadjaja za sliku
        }

        private void ProcessWebFrameContour(object sender, EventArgs e) //dogadjaj za web kameru
        {
            long time;
            this.imgResult.Image = this.contour.WebCameraContourDetection(out time, this.trbContour.Value); //detekcija kontura i smestanje rezultata u imageBox
            this.timeLabel.Text = time.ToString() + "miliseconds"; // prikaz vremena izvrsenja
        }

        private void ProcessVideoFrameContour(object sender, EventArgs e) //dogadjaj za video snimak
        {
            long time;
            this.imgResult.Image = this.contour.VideoContourDetection(out time,this.sceneImage, this.trbContour.Value); //detekcija kontura i smestanje rezultata u imageBox
            this.timeLabel.Text = time.ToString() + "miliseconds"; // prikaz vremena izvrsenja
        }

        private void ProcessImageFrameContour(object sender, EventArgs e) //dogadjaj za sliku
        {
            long time;
            this.imgResult.Image = this.contour.ImageContourDetection(out time, this.sceneImage, this.trbContour.Value); //detekcija kontura i smestanje rezultata u imageBox
            this.timeLabel.Text = time.ToString() + "miliseconds"; // prikaz vremena izvrsenja
        }

        #endregion

        #region Others fuctions

        private bool CheckParametersContour() //funkcija koja proverava da li su svi parametri dobro uneti
        {
            if ((this.sceneImage != null) || (this.rbtWeb.Checked))
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        private void DetachContourFunctions() // funkcija koja uklanja dogadjaje i brise podatk
        {
            Application.Idle -= this.ProcessWebFrameContour; //uklanja  dogadjaj za web kameru
            Application.Idle -= this.ProcessVideoFrameContour; //uklanja  dogadjaj za video snimak
            Application.Idle -= this.ProcessImageFrameContour; //uklanja  dogadjaj za sliku

            if (this.contour != null) //ukoliko je objekat inicijalizovan
                this.contour.Dispose(); // brise podatke
        }

        #endregion

        #endregion

    }
}
