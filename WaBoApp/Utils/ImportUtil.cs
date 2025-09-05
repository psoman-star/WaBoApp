using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WaApp.Utils
{
    public class ImportUtil
    {

        public static List<T> ImportData<T>() where T : class
        {
            var open = new OpenFileDialog();
            open.Filter = "Excel File|*.xlsx";
            if (open.ShowDialog() == DialogResult.OK)
            {
                var dt = ExcelUtil.ImportExcel(open.FileName);
                if (dt.Rows.Count > 0)
                {
                    return ConvertUtil.ConvertList<T>(dt);
                }

            }
            return default(List<T>);
        }

        public static List<string> ImportData()
        {
            var list = new List<string>();
            var open = new OpenFileDialog();
            open.Filter = "Excel File|*.xlsx";
            if (open.ShowDialog() == DialogResult.OK)
            {
                var dt = ExcelUtil.ImportExcel(open.FileName);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var phone = row.Field<string>(0);
                        list.Add(phone);
                    }
                }

            }
            return list;

        }

        public static List<string> ImportPhone()
        {
            var list = new List<string>();
            var open = new OpenFileDialog
            {
                Filter = "Text File|*.txt",
            };
            if (open.ShowDialog() == DialogResult.OK)
            {
                var lines = File.ReadAllLines(open.FileName);
                return lines.ToList();

            }
            return list;
        }

        public static void ExportFile(List<string> list)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Text File|*.txt",
                FileName = $"{Environment.TickCount}.txt",
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(dialog.FileName, list, System.Text.Encoding.UTF8);
            }
        }
    }
}
