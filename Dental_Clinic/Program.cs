using Dental_Clinic.GUI;
using Dental_Clinic.GUI.Login;
using Dental_Clinic.GUI.Administrator;

namespace Dental_Clinic
{
    internal static class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI.Dental_Clinic());
        }
    }
}

