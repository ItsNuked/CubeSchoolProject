
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
            stevka = CvInvoke.Imread("D:/C#Nuked/Cube/img/1px6.jpg");
            Mat background = new Mat();                                              //Naredi nov material, aka save-a info of all colors of all pixels  
            background = CvInvoke.Imread("D:/C#Nuked/Cube/img/bkg.jpg");                                 //Reads specified image (stores in object)
            CvInvoke.Imshow("img", stevka);                                                            //Saves image ()
            CvInvoke.Imshow("BG", background);  
            CvInvoke.WaitKey(0); 
            CvInvoke.DestroyAllWindows();                                                                    //podobn k c++, ti pusti window odprt doklr ne prtisns karkol
        }
    }
}
