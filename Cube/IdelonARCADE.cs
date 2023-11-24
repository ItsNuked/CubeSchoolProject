
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;



namespace Image
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat stevka = new Mat();
            stevka = CvInvoke.Imread("D:/C#Nuked/Cube/img/6.jpg");
            Mat background = new Mat();                                              //Naredi nov material, aka save-a info of all colors of all pixels  
            background = CvInvoke.Imread("D:/C#Nuked/Cube/img/bkgtemp.jpg");                                 //Reads specified image (stores in object)
            //CvInvoke.Imshow("img", stevka);                                                                //Saves image ()
            //CvInvoke.Imshow("BG", background);  
            

            Mat result = new Mat();
            CvInvoke.MatchTemplate(background, stevka, result, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed);   //Z matematičnimi enačbami preveri umeljivost

            double minVsota = 0.0d;
            double maxVsota = 0.0d;
            System.Drawing.Point minLokacija = new System.Drawing.Point();
            System.Drawing.Point maxLokacija = new System.Drawing.Point();

            CvInvoke.MinMaxLoc(result, ref minVsota, ref maxVsota, ref minLokacija, ref maxLokacija);          //Išče Minimal in Maximum vsoto ter lokacijo v "result".
            CvInvoke.Threshold(result, result, 0.85, 1, Emgu.CV.CvEnum.ThresholdType.ToZero);                                                      //Podobnost da velja kot iskani predmet, išči 85% ujemanje, 1-krat.
            
            var matches = result.ToImage<Gray, Byte>();

            for (int i = 0; i < matches.Rows; i++)
            {
                for (int j = 0; j < matches.Cols; j++)
                {
                    if (matches[i, j].Intensity > .8)
                    {
                        System.Drawing.Point loc = new System.Drawing.Point(i, j);
                        System.Drawing.Rectangle box = new System.Drawing.Rectangle(loc, stevka.Size);

                        CvInvoke.Rectangle(background, box, new Emgu.CV.Structure.MCvScalar(0, 255, 0), 2);
                    }
                }
            }

            CvInvoke.Imshow("RGBstonks", background);
            CvInvoke.Imshow("stonks", result);                                                                  //Pokaži result
            CvInvoke.WaitKey(0);                                                                                //podobn k c++, ti pusti window odprt doklr ne prtisns karkol
            CvInvoke.DestroyAllWindows();    
        }
    }
}
