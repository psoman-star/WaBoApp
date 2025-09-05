using ExcelDataReader;
using System.Data;
using System.IO;
using System.Text;

namespace WaApp.Utils
{
    public class ExcelUtil
    {
        public static DataTable ImportExcel(string path)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        UseColumnDataType = false,
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    return ds.Tables[0];
                }
            }
        }

    }
}
