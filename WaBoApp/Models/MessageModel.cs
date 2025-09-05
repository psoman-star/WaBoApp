using System.Reflection;

namespace WaApp.Models
{
    [Obfuscation(Exclude = true)]
    public class MessageModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public bool IsDisable { get; set; }
        public MessageType Type { get; set; }
        public string Content { get; set; }

        public bool IsAttachment { get; set; }
        public string Attachment { get; set; }
    }
}
