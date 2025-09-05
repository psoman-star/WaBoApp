using System.Text.RegularExpressions;

namespace WaApp.Utils
{
    public class RegexUtil
    {
        public static bool CheckPhone(string phone)
        {
            var str = Regex.Replace(phone, @"[^0-9]+", "");
             var regex = @"^[0-9]{8,14}$";
            return Regex.IsMatch(str, regex);
        }
    }
}
