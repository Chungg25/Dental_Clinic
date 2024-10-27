using Dental_Clinic.GUI;
using Dental_Clinic.GUI.Login;
using Dental_Clinic.GUI.Administrator;

namespace Dental_Clinic
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new GUI.Dental_Clinic());
        }
    }
}

