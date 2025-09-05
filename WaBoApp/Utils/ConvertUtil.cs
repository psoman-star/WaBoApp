
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace WaApp.Utils
{
    [Obfuscation(Exclude = true)]
    public class ConvertUtil
    {
        public static List<T> ConvertList<T>(DataTable dt) where T : class
        {
            var list = new List<T>();
            dt.AsEnumerable().ToList().ForEach(r =>
            {
                var model = Activator.CreateInstance<T>();
                var properties = model.GetType().GetProperties().ToList();
                properties.ForEach(p =>
                {
                    if (!string.Equals(dt.Columns[p.Name]?.ColumnName, p.Name, StringComparison.CurrentCultureIgnoreCase))
                        return;
                    var o = r[p.Name] != DBNull.Value ? Convert.ChangeType(r[p.Name], p.PropertyType) : null;
                    p.SetValue(model, o, null);
                });
                list.Add(model);
            });
            return list;
        }


    }
}
