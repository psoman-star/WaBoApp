using System;
using System.Drawing;
using System.Windows.Forms;

namespace WaApp.Utils
{
    public class FormUtils
    {
        public static int GetAutoHeight(int width,int sourceheight)
        {
            var dpi = GetDpi();
            if (dpi >= 192)
            {
                return sourceheight;
            }
            // return sourceheight * Screen.PrimaryScreen.Bounds.Height / 1080;
            return (sourceheight * Screen.PrimaryScreen.Bounds.Width) / 1920 * (width / sourceheight);

        }

        public static int GetAutoWidth(int sourcewidth)
        {
            var dpi = GetDpi();
            if (dpi >= 192)
            {
                return sourcewidth;
            }
            return sourcewidth * Screen.PrimaryScreen.Bounds.Width / 1920;

        }

        private static int GetDpi()
        {
            var dpiX = 96;
            using (var graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                dpiX = (int)graphics.DpiX;
            }
            return dpiX;
        }
    }
}
