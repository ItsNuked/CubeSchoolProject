using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Windows.Documents;
using System.Threading;
using Mis.c;




namespace Image
{
    class Program
    {
        static void Main(string[] args)
        {
            //Mat stevka = new Mat();
            Mat stevka = CvInvoke.Imread("D:/C#Nuked/Cube/img/6.jpg");
            
            while (true)
            {

            using (Bitmap screenCapture = new Bitmap(680, 60)) 
            {
                using (Graphics g = Graphics.FromImage(screenCapture))
                {
                    g.CopyFromScreen(746, 773, 0, 0, new Size(680, 60));                                       //Starting point for sc, changing last 2 # just moves img out of frame
                }
            
            //using (Bitmap resizedCapture = new Bitmap(screenCapture, new Size(1530, 70)))
            //Console.WriteLine("Captured Image Dimensions: " + screenCapture.Width + " x " + screenCapture.Height);
            screenCapture.Save("D:/C#Nuked/Cube/img/GameScr.jpg", ImageFormat.Png);

            
            Mat background = CvInvoke.Imread("D:/C#Nuked/Cube/img/GameScr.jpg", ImreadModes.AnyColor);                                              //Naredi nov material, aka save-a info of all colors of all pixels 
            //CvInvoke.CvtColor(new Image<Bgr, byte>(screenCapture), background, ColorConversion.Bgr2Rgb);
            //background = CvInvoke.Imread("D:/C#Nuked/Cube/img/bkgtemp.jpg");                                 //Reads specified image (stores in object)
            //using (Mat background = GameScr.CaptureScreen())

            Mat result = new Mat();
            CvInvoke.MatchTemplate(background, stevka, result, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed);   //Z matematičnimi enačbami preveri ujemljivost

            double minVsota = 0.0d;
            double maxVsota = 0.0d;
            System.Drawing.Point minLokacija = new System.Drawing.Point();
            System.Drawing.Point maxLokacija = new System.Drawing.Point();

            CvInvoke.MinMaxLoc(result, ref minVsota, ref maxVsota, ref minLokacija, ref maxLokacija);          //Išče Minimal in Maximum vsoto ter lokacijo v "result".
            CvInvoke.Threshold(result, result, 0.85, 1, Emgu.CV.CvEnum.ThresholdType.ToZero);                  //Podobnost da velja kot iskani predmet, išči 85% ujemanje, 1-krat.
            
            var matches = result.ToImage<Gray, Byte>();                                                        //Daj result v greyscale

            for (int i = 0; i < matches.Rows; i++)
            {                                                                                                  //for zanki narišeta kvadrat (slinkar zvezdice shape vaje)
                for (int j = 0; j < matches.Cols; j++)
                {
                    if (matches[i, j].Intensity > .8)
                    {
                        //System.Drawing.Point loc = new System.Drawing.Point(j, i);                             //Lokacija na sliki, kjer smo je danem trenutku (0, 0 starting point)
                        //System.Drawing.Rectangle box = new System.Drawing.Rectangle(loc, stevka.Size);         //loc = točka, stevka.Size = velikost od slike števka 

                        //CvInvoke.Rectangle(background, box, new Emgu.CV.Structure.MCvScalar(0, 255, 0), 2);    //Rectangle = oris, background = slika na katero riše, box = oblika

                        
                                                                               // Check if the number 6 is matched and print a message
                        MouseActions.MouseClick();
                        Console.WriteLine("6");
                        break;
                        //Thread.Sleep(10000);
                    }                                                                                          //McvScalar je barva, (r, g, b), debelina);
                }
            }

            //CvInvoke.Imshow("RGBstonks", background);
            //CvInvoke.Imshow("stonks", result);                                                                  //Pokaži result

            int key = CvInvoke.WaitKey(0);  // Adjust the wait time as needed (1 millisecond in this example)

                    if (key == 27)  // Break the loop if the 'Esc' key is pressed
                        break;
            }
            //CvInvoke.WaitKey(0);                                                                                //podobn k c++, ti pusti window odprt doklr ne prtisns karkol
            }
            CvInvoke.DestroyAllWindows();
        }
    }
}
