using APP2EFCore.Forms;

namespace APP2EFCore;

static class Program
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
        FormLogin formLogin = new FormLogin();
        Application.Run(new Forms.FormMain(formLogin));
        //Application.Run(new FormLogin());
    }
}