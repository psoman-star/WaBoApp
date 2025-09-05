using System.Reflection;

namespace WaApp.Models
{
    [Obfuscation(Exclude = true)]
    public class DelaySetting
    {
        public int MsgDelayMin { get; set; } = 5;
        public int MsgDelayMax { get; set; } = 10;
        public int MsgSendMin { get; set; } = 10;
        public int MsgSendMax { get; set; } = 20;
        public int MsgNums { get; set; } = 10;

        public int DelayMin { get; set; } = 5;
        public int DelayMax { get; set; } = 10;
    }
}
