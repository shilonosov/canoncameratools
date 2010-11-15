using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using EDSDKLib;
using Source;

namespace NoisyMouse
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}