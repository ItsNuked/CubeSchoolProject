using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
/*namespace yes
{
    class program
    {
        static void mian(string[]args)
        {
            Mat img = new Mat();

            img = CvInvoke.Imread("./img/.jpg");
            CvInvoke.Imshow("ARCADE, img");
            
            CvInvoke.WaitKey();
        }
    }
}
*/
partial class Program
{

    [DllImport("user32.dll")]
    private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, UIntPtr dwExtraInfo);

    private const int MOUSEEVENTF_LEFTDOWN = 0x02;
    private const int MOUSEEVENTF_LEFTUP = 0x04;

    static void Main()
    {
        Console.WriteLine("Press F1 to simulate a mouse click if the number '6' is present on the game screen.");
        Console.WriteLine("Press Esc to exit.");

        HookManager.KeyDown += (sender, e) =>
        {
            if (e.KeyCode == Keys.F1)
            {
                // Check if the number '6' is present on the game screen (your logic here)
                if (IsNumberSixPresentOnGameScreen())
                {
                    Console.WriteLine("Simulating mouse click at the current cursor position.");
                    SimulateMouseClick();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Environment.Exit(0);
            }
        };

        Application.Run();
    }

    static bool IsNumberSixPresentOnGameScreen()
    {
       
        
        // Implement your logic to check if the number '6' is present on the game screen
        // This could involve screen capture, image recognition, etc.
        return true; // Replace this with your actual implementation1
    }

    static void SimulateMouseClick()
    {
        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
    }
}

// Keyboard hook manager to listen for key events globally
public static class HookManager
{
    public static event EventHandler<KeyEventArgs> KeyDown;

    private static LowLevelKeyboardProc _proc = HookCallback;
    private static IntPtr _hookID = IntPtr.Zero;

    static HookManager()
    {
        _hookID = SetHook(_proc);
    }

    private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

    private static IntPtr SetHook(LowLevelKeyboardProc proc)
    {
        using (ProcessModule module = Process.GetCurrentProcess().MainModule)
        {
            return SetWindowsHookEx(13, proc, GetModuleHandle(module.ModuleName), 0);
        }
    }

    private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
        {
            int vkCode = Marshal.ReadInt32(lParam);
            KeyDown?.Invoke(null, new KeyEventArgs((Keys)vkCode));
        }

        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);

    private const int WM_KEYDOWN = 0x0100;
}
