using WindowsInput;
using WindowsInput.Native;
using System.Drawing;
using System.Windows.Forms;
using Tesseract;
using System;
using InputSimulator;

class Penis
{

    static void main()
    {

    InputSimulator sim = new InputSimulator();  //InputSimulator je class (podatkovni tip i think prevod, like u'd say int sim. Sim je samo ime ^^)

    int screenX = 100; // Replace with the X coordinate of the region you want to capture
    int screenY = 100; // Replace with the Y coordinate of the region you want to capture
    int screenWidth = 1920; // Replace with the width of the region
    int screenHeight = 1080; // Replace with the height of the region

    Color targetColor = Color.Green; // The color you're looking for

    while (true) // Run indefinitely, or you can define your own condition to exit the loop
    {
        using (Bitmap screenCapture = new Bitmap(screenWidth, screenHeight)) //<---This code block captures a portion of the screen defined by screenX, screenY, screenWidth, 
        using (Graphics g = Graphics.FromImage(screenCapture))               //and screenHeight. It then checks the color of a pixel in the center of the captured region
        {                                                                    // and compares it with the targetColor. If the colors match, it simulates a mouse click.
            g.CopyFromScreen(screenX, screenY, 0, 0, new Size(screenWidth, screenHeight));  // new Size defines the dimensions of the region to capture
            Color pixelColor = screenCapture.GetPixel(screenWidth / 2, screenHeight / 2); // Check the center pixel
            if (pixelColor == targetColor)
            {
                sim.Mouse.LeftButtonClick(); // Simulate a mouse click at the desired location
            }
        }
    }
}
}




/* line 14: using (Bitmap screenCapture = new Bitmap(screenWidth, screenHeight))

Bitmap is a class in C# that represents an image, essentially a 2D grid of pixels.
screenCapture is a Bitmap object that will store the captured screen region.
new Bitmap(screenWidth, screenHeight) creates a new Bitmap object with the specified width and height, which is defined by the screenWidth and screenHeight variables.

line 15: using (Graphics g = Graphics.FromImage(screenCapture))

Graphics is a class used for drawing on graphical surfaces, and Graphics.FromImage creates a Graphics object associated with the given Bitmap (in this case, screenCapture).
g is a Graphics object that you can use to draw on the screenCapture bitmap.
These lines prepare the screenCapture bitmap for screen capture and drawing. 
The Bitmap object represents the canvas on which you'll capture a portion of the screen and analyze its content.

line 17; This line captures the region defined by screenX, screenY, screenWidth, and screenHeight from the actual
screen and copies it onto the screenCapture bitmap. It essentially takes a "screenshot" of a specific region on your screen.

line 18:
*/