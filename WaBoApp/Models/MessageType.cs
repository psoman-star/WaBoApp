using System.Reflection;

namespace WaApp.Models
{
    [Obfuscation(Exclude = true)]
    public enum MessageType
    {
        Import = 0,
        Contact,
        Group
    }
}
