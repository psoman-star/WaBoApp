using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WaApp.Utils
{
    class ChormeUtils
    {
        public static string GetChromeVersion()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                var cuurentUserChromePath = Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\App Paths\\chrome.exe", "", null)?.ToString();
                string chromePath = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\chrome.exe", "", null)?.ToString();
                if (cuurentUserChromePath != null)
                {
                    return FileVersionInfo.GetVersionInfo(cuurentUserChromePath.ToString()).FileVersion;
                }
                if (chromePath != null)
                {
                    return FileVersionInfo.GetVersionInfo(chromePath.ToString()).FileVersion;
                }
                return string.Empty;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
