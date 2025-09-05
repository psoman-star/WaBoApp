using System;
using System.IO;
using System.Text;

namespace What.Api
{
    public static class Logger
    {
        public static Action<string> Log { get; set; } = DefaultLogger;
        private static void DefaultLogger(string message)
        {
#if DEBUG
            var path = "Logs.txt";
#else
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "whatsappLog.txt");
#endif
            var msg = $"{DateTime.Now}:{message}{Environment.NewLine}";
            File.AppendAllText(path, msg, Encoding.UTF8);
        }
    }
}
