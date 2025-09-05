using Krypton.Toolkit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WaApp.Models;

namespace WaApp.Utils
{
    public class LanguageUtils
    {
        private static List<LanguageItem> list = new List<LanguageItem>();
        public static string Lang { get; set; } = "en";

        static LanguageUtils()
        {
            GetList(Lang);
        }
        private static void GetList(string key)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"language\\{key}.txt");
            if (File.Exists(path))
            {
                var content = File.ReadAllText(path);
                list = JsonConvert.DeserializeObject<List<LanguageItem>>(content);
            }
        }
        public static void ChangeLanguage(string lang)
        {
            Lang = lang;
            GetList(lang);
        }

        public static string GetName(string name)
        {
            return list.FirstOrDefault(item => item.Name == name)?.Text;
        }
        public static void SetLanguage(Form form)
        {
            if (list.Count == 0)
            {
                return;
            }
            form.Text = list.FirstOrDefault(item => item.Name == form.Name)?.Text;
            SetControlText(form, list);

        }

        public static void SetLanguage(UserControl form)
        {
            if (list.Count == 0)
            {
                return;
            }
            form.Text = list.FirstOrDefault(item => item.Name == form.Name)?.Text;
            SetControlText(form, list);

        }

        private static void SetControlText(Form form, List<LanguageItem> list)
        {
            foreach (Control item in form.Controls)
            {
                if (item is KryptonLabel || item is KryptonButton || item is CheckBox)
                {
                    var text = list.FirstOrDefault(m => m.Name == item.Name)?.Text;
                    if (!string.IsNullOrEmpty(text))
                    {
                        item.Text = text;
                    }
                }
                if (item is KryptonDataGridView dgv)
                {
                    SetGrid(dgv, list);
                }
                SetSubControlText(item, list);

            }
        }


        private static void SetControlText(UserControl form, List<LanguageItem> list)
        {
            foreach (Control item in form.Controls)
            {
                if (item is KryptonLabel || item is KryptonButton || item is CheckBox)
                {
                    var text = list.FirstOrDefault(m => m.Name == item.Name)?.Text;
                    if (!string.IsNullOrEmpty(text))
                    {
                        item.Text = text;
                    }
                }
                if (item is KryptonDataGridView dgv)
                {
                    SetGrid(dgv, list);
                }
                SetSubControlText(item, list);

            }
        }

        private static void SetSubControlText(Control subControl, List<LanguageItem> list)
        {
            foreach (Control item in subControl.Controls)
            {
                if (item is KryptonLabel || item is KryptonButton || item is CheckBox)
                {
                    var text = list.FirstOrDefault(m => m.Name == item.Name)?.Text;
                    if (!string.IsNullOrEmpty(text))
                    {
                        item.Text = text;
                    }
                }
                else if (item is KryptonDataGridView dgv)
                {
                    SetGrid(dgv, list);
                }
                else
                {
                    if (item.Controls.Count > 0)
                    {
                        SetSubControlText(item, list);
                    }
                }

            }
        }

        private static void SetGrid(KryptonDataGridView dgv, List<LanguageItem> list)
        {
            var colList = list.Where(m => m.IsColumn);
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                var disName = colList.FirstOrDefault(c => c.Name == column.Name)?.Text;
                if (!string.IsNullOrEmpty(disName))
                {
                    column.HeaderText = disName;
                }

            }
        }


    }
}
