using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace WaApp.Utils
{
    [Obfuscation(Exclude = true)]
    public class FileUtils
    {
        private static string basePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WhatsData");
        public static void Save<T>(List<T> list, string name="msg.txt")
        {
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
            var path = Path.Combine(basePath, name);
            if (list.Count > 0)
            {
                var str = JsonConvert.SerializeObject(list);
                File.WriteAllText(path, str, Encoding.UTF8);
            }
            else
            {
                File.WriteAllText(path, String.Empty, Encoding.UTF8);
            }

        }
        public static void Save<T>(T model, string name = "msg.txt")
        {
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
            var path = Path.Combine(basePath, name);
            if (model != null)
            {
                var list = new List<T>();
                if (File.Exists(path))
                {
                    var str = File.ReadAllText(path, Encoding.UTF8);
                    list = JsonConvert.DeserializeObject<List<T>>(str);
                }
                list = list ?? new List<T>();
                list.Add(model);
                Save(list, path);
            }
        }

 
        public static List<T> GetAll<T>(string name = "msg.txt")
        {
            try
            {
                var path = Path.Combine(basePath, name);
                if (File.Exists(path))
                {
                    var str = File.ReadAllText(path, Encoding.UTF8);
                    return JsonConvert.DeserializeObject<List<T>>(str) ?? new List<T>();
                }
            }
            catch (Exception ex)
            {
            }
            return new List<T>();

        }

        public static void OpenFile(string path)
        {
            Process.Start(path);
        }
    }
}
