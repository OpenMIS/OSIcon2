/*
 * OSIcon
 * Author: Tiago Conceição
 * 
 * https://github.com/sn4k3/OSIcon
 * http://www.codeproject.com/Articles/50064/OSIcon
 */
using System;
using System.Windows.Forms;

namespace OSIcon.Explorer
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    public const string AppTitle = "OSIcon Explorer";

    public static Main MainFrm;
    [STAThread]
    static void Main()
    {
#if NETFRAMEWORK
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
#else
      // To customize application configuration such as set high DPI settings or default font,
      // see https://aka.ms/applicationconfiguration.
      ApplicationConfiguration.Initialize();
#endif

      MainFrm = new Main();
      Application.Run(MainFrm);
    }
  }
}
