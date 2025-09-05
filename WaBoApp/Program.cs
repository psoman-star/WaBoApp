using Krypton.Toolkit;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WaApp
{
    static class Program
    {
        /// <summary>
        /// 
        /// </summary>
        [STAThread]
        static void Main()
        {
            var mutexName = Environment.MachineName + "WhatBot";
            var run = new Mutex(true, mutexName, out bool runone);
            if (runone)
            {
                run.ReleaseMutex();
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += Application_ThreadException;
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                var identity = WindowsIdentity.GetCurrent();
                var principal = new WindowsPrincipal(identity);
                if (principal.IsInRole(WindowsBuiltInRole.Administrator))
                {
                    Application.Run(new FrmWelcome());
                }
                else
                {
                    string result = Environment.GetEnvironmentVariable("systemdrive");
                    if (AppDomain.CurrentDomain.BaseDirectory.Contains(result))
                    {
                        var startInfo = new ProcessStartInfo
                        {
                            FileName = Application.ExecutablePath,
                            Verb = "runas",
                        };
                        Process.Start(startInfo);
                    }
                    else
                    {
                        Application.Run(new FrmWelcome());
                    }
                }
            }
            else
            {
                MessageBox.Show("An instance is already running!");
            }
        }
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            var exStr = e.Exception.Message;
            KryptonMessageBox.Show(exStr,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());


        }


        static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************Exception****************************");
            sb.AppendLine("【Date】：" + DateTime.Now.ToString(CultureInfo.InvariantCulture));
            if (ex != null)
            {
                sb.AppendLine("【Type】：" + ex.GetType().Name);
                sb.AppendLine("【Message】：" + ex.Message);
                sb.AppendLine("【StackTrace】：" + ex.StackTrace);
                sb.AppendLine("【TargetSite】：" + ex.TargetSite);
            }
            else
            {
                sb.AppendLine("【Untreated Exception】：" + backStr);
            }
            sb.AppendLine("***************************************************************");
            return sb.ToString();
        }
}
}
