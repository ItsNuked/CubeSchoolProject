
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
            Mat img = new Mat();        //Naredi nov material, aka save-a info of all colors of all pixels

            img = CvInvoke.Imread("./img/sest.jpg");       //Reads specified image (stores in object)
            CvInvoke.Imshow("img", img);                   //Saves image ()
            
            CvInvoke.WaitKey();
        }
    }
}
