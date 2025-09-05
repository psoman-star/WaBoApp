using System.Reflection;

namespace WaApp.Models
{
    [Obfuscation(Exclude = true)]
    public class PhoneModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    [Obfuscation(Exclude = true)]
    public class PhoneCheck
    {
        public string PhoneNumber { get; set; }
    }
}
