

namespace WaApp.Models
{
    public class SendResult
    {
        public string Phone { get; set; }
        public bool IsSuccess { get; set; }
        public string Reason { get; set; }
    }

    public class JoinResult
    {
        public string GroupName { get; set; }
        public bool IsSuccess { get; set; }
        public string Reason { get; set; }
        public string Link { get; set; }
    }
}
