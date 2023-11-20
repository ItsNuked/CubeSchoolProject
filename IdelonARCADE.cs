
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
        static void Main(string[] args, Mat img, Mat img)
        {
            Mat img = new Mat();                                                                    //Naredi nov material, aka save-a info of all colors of all pixels
            img = CvInvoke.Imread("D:/C#Nuked/Cube/IdleonCubeAC/IdleonCube AC/img/sest.jpg");       //Reads specified image (stores in object)
            CvInvoke.Imshow("img", img);                                                            //Saves image ()
            
            CvInvoke.WaitKey();                                                                     //podobn k c++, ti pusti window odprt doklr ne prtisns karkol

            Mat gaussianBlur = new Mat();
            CvInvoke.GaussianBlur(img, gaussianBlur, new System.Drawing.Size(img.Rows, img.Cols), 7.0);
            CvInvoke.Imshow("blurry img", gaussianBlur);  
        }
    }
}
