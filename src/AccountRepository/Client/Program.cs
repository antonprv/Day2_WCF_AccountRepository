// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System;
using System.Windows.Forms;

using Client.Infrastructure;

using Unity;

namespace Client
{
  internal static class Program
  {
    /// <summary>
    /// Главная точка входа для приложения.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      using (var container = UnityContainerBuilder.Build())
      {
        Forms.MainForm mainForm =
          container.Resolve<Forms.MainForm>();

        Application.Run(mainForm);
      }
    }
  }
}
