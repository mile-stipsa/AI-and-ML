using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Cuda;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.XFeatures2D;

namespace Obrada_slike_i_videa.Classes
{
    /*
     Klasa koja nam omogucava pronalazak ficera, iscrtavanje svih ficera, uparenih ficera, kao i konture objekta
    */
    public class SURFFeatureDetection
    {
        /*
         Funkcija koja nam omogucava pronalazak ficera i uparivanje ficera, kao parametri se prosledjuju, slika objekta kog trazimo,
         slika na kojoj trazimo objekat, promenljiva u kojoj ce se cuvati vreme izvrsenja, promenljiva u kojoj ce se cuvati kljucne tacke
         objekta koji se trazi, promenljiva u kojoj ce se cuvati kljucne tacke slike na kojoj se trazi objekat, niz uparenih ficera,
         promenljiva gde ce se cuvati maska, promenljiva gde ce se cuvati matrica homografije, promenljiva na osnovu koje se odredju mod rada 
        */
        public void FindMatch(Mat modelImage, Mat observedImage, out long matchTime, out VectorOfKeyPoint modelKeyPoints, out VectorOfKeyPoint observedKeyPoints, VectorOfVectorOfDMatch matches, out Mat mask, out Mat homography, bool isOnGPU)
        {
            int k = 2; // broj uparenih tacaka
            double uniquenessThreshold = 0.8; //jedinstvenost ficera
            double hessianThresh = 300; //odredjuje koje ce se tacke uzimati u obzir

            Stopwatch watch; //promenljiva kojom merimo vreme izvrsenja
            homography = null; //matrica homografije

            modelKeyPoints = new VectorOfKeyPoint(); // inicijalizacija vektora kljucnih tacaka objekta koji se trazi
            observedKeyPoints = new VectorOfKeyPoint(); // inicijalizacija vektora kljucnih tacaka slike na kojoj se objekat trazi

            if (CudaInvoke.HasCuda&&isOnGPU) // ukoliko postoji CUDA podrska i ukoliko je izabran mod izvrsenja na grafickoj kartici
            {
                CudaSURF surfCuda = new CudaSURF((float)hessianThresh); // kreira se SURF detektor koji ce se izvrsavati na grafickoj kartici 
                using (GpuMat gpuModelImage = new GpuMat(modelImage)) // kreira se slika objekta na grafickoj kartici
                
                using (GpuMat gpuModelKeyPoints = surfCuda.DetectKeyPointsRaw(gpuModelImage, null)) // detektuju se kljucne tacke na slici objekta 
                using (GpuMat gpuModelDescriptors = surfCuda.ComputeDescriptorsRaw(gpuModelImage, null, gpuModelKeyPoints)) //kreiranje deskriptora
                using (CudaBFMatcher matcher = new CudaBFMatcher(DistanceType.L2)) // kreiranje mecera, kao parametar se zadaje distanca
                {
                    surfCuda.DownloadKeypoints(gpuModelKeyPoints, modelKeyPoints); //prebacuje kljucne tacke sa graficke memorije u radnu memoriju tj u promenljivu modelKeyPoints
                    watch = Stopwatch.StartNew(); // pocetak merenja vremena

                    using (GpuMat gpuObservedImage = new GpuMat(observedImage)) //kreira se slika na kojoj se trazi objekat na grafickoj kartici
                    using (GpuMat gpuObservedKeyPoints = surfCuda.DetectKeyPointsRaw(gpuObservedImage, null)) // detektuju se kljucne tacke na slici na kojoj se trazi objekat
                    using (GpuMat gpuObservedDescriptors = surfCuda.ComputeDescriptorsRaw(gpuObservedImage, null, gpuObservedKeyPoints)) //kreiranje deskriptora
                    {
                        matcher.KnnMatch(gpuObservedDescriptors, gpuModelDescriptors, matches, k); //uparivanje ficera pomocu metode KNN

                        surfCuda.DownloadKeypoints(gpuObservedKeyPoints, observedKeyPoints); // prebacivanje kljucnih tacaka u radnu memoriju

                        mask = new Mat(matches.Size, 1, DepthType.Cv8U, 1); //kreiranje maske
                        mask.SetTo(new MCvScalar(255)); // postavljanje vrednosti maske
                        Features2DToolbox.VoteForUniqueness(matches, uniquenessThreshold, mask); //filtiranje meceva na osnovu jedinstvenosti ficera, ukoliko ne ispunjava uslov, odbacuje se

                        int nonZeroCount = CvInvoke.CountNonZero(mask); //broj nenultih elemenata
                        if (nonZeroCount >= 4) // ukoliko postoje vise od 3 jedinstvena ficera
                        {
                            nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(modelKeyPoints, observedKeyPoints,
                               matches, mask, 1.5, 20); // odbacuju se ficeri kojima ne odgovara skala i rotacija
                            if (nonZeroCount >= 4) // ukoliko postoji vise od 3 jedinstvena ficera
                                homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(modelKeyPoints,
                                   observedKeyPoints, matches, mask, 2); // racuna se matrica homografije
                        }
                    }
                    watch.Stop(); // kraj merenja vremena
                }
            }
            else //ukoliko ne postoji CUDA podrska ili nije izabran GPU mod
            {
                using (UMat uModelImage = modelImage.GetUMat(AccessType.Read)) // konvertovanje slike objekta
                using (UMat uObservedImage = observedImage.GetUMat(AccessType.Read)) // konvertovanje slike na kojoj se trazi objekat
                {
                    SURF surfCPU = new SURF(hessianThresh); // kreiranje SURF detektora
                    UMat modelDescriptors = new UMat(); // inicijalizacija deskriptora slike objekta
                    surfCPU.DetectAndCompute(uModelImage, null, modelKeyPoints, modelDescriptors, false); // detekcija kljucnih tacaka i kreiranje deskriptora

                    watch = Stopwatch.StartNew(); // pocetak merenja vremena


                    UMat observedDescriptors = new UMat();  //inicijalizacija desktriptora slike na kojoj se trazi objekat
                    surfCPU.DetectAndCompute(uObservedImage, null, observedKeyPoints, observedDescriptors, false); // detekcija kljucnih tacaka i kreiranje deskriptora
                    BFMatcher matcher = new BFMatcher(DistanceType.L2); //kreiranje mecera
                    matcher.Add(modelDescriptors); // dodavanje desktriptora objekta

                    matcher.KnnMatch(observedDescriptors, matches, k, null); // uparivanje ficera pomocu metode KNN
                    mask = new Mat(matches.Size, 1, DepthType.Cv8U, 1); // kreiranje maske
                    mask.SetTo(new MCvScalar(255)); // setovanje vrednosti maske
                    Features2DToolbox.VoteForUniqueness(matches, uniquenessThreshold, mask); //pronalazak jedinstvenih meceva

                    int nonZeroCount = CvInvoke.CountNonZero(mask); //vraca broj nenultih elemenata
                    if (nonZeroCount >= 4) // ukoliko postoji vise od 3 jedinstveno uparenih ficera
                    {
                        nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(modelKeyPoints, observedKeyPoints,
                           matches, mask, 1.5, 20); // odbacuju se ficeri kojima ne odgovara skala i rotacija
                        if (nonZeroCount >= 4) // ukoliko postoji vise od 3 jedinstveno uparenih ficera
                            homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(modelKeyPoints,
                               observedKeyPoints, matches, mask, 2); // racuna se matrica homografije
                    }

                    watch.Stop(); // kraj merenja vremena
                }
            }
            matchTime = watch.ElapsedMilliseconds; // ukupno proteklo vreme izvrsenja
        }

        /*
         Funkcija koja crta pronadjene kljucne tacke, uparene kljucne tacke i konture detektovanog objekta kao parametri se prosledjuju slika objekta, 
         slika na kojoj se trazi objekat, promenljiva gde se cuva vreme izvrsenja, i mod rada
        */
        public Mat Draw(Mat modelImage, Mat observedImage, out long matchTime, bool isOnGPU)
        {
            Mat homography;
            VectorOfKeyPoint modelKeyPoints;
            VectorOfKeyPoint observedKeyPoints;
            using (VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch()) //kreiiranje vektora uparenih ficera
            {
                Mat mask;
                FindMatch(modelImage, observedImage, out matchTime, out modelKeyPoints, out observedKeyPoints, matches,
                   out mask, out homography, isOnGPU); // poziv funkcije za detekciju objekta na slici
                
                Mat result = new Mat(); // inicijalizacija konacne slike
               
                /*Iscrtavanje ficera, linija uparenih ficera kao i konture detektovanog objekta*/
               Features2DToolbox.DrawMatches(modelImage, modelKeyPoints, observedImage, observedKeyPoints, matches, result, new MCvScalar(255, 0, 255), new MCvScalar(0, 255, 255), mask);
               

                if (homography != null) // ukoliko matrica homografije nije prazna
                {
                    
                    Rectangle rect = new Rectangle(Point.Empty, modelImage.Size); //kreiranje  pravougaonika
                    PointF[] pts = new PointF[] // zadavanje tacaka
                    {
                      new PointF(rect.Left, rect.Bottom),
                      new PointF(rect.Right, rect.Bottom),
                      new PointF(rect.Right, rect.Top),
                      new PointF(rect.Left, rect.Top)
                    };
                    pts = CvInvoke.PerspectiveTransform(pts, homography); // perspektivna tranformacija tacaka

                    Point[] points = Array.ConvertAll<PointF, Point>(pts, Point.Round); // konvertovanje u cele brojeve
                    using (VectorOfPoint vp = new VectorOfPoint(points))
                    {
                        CvInvoke.Polylines(result, vp, true, new MCvScalar(255, 0, 0, 255),3); // uokviravanje objekta
                    }

                }


                return result; // vraca se konacna slika

            }
        }
    }
}
