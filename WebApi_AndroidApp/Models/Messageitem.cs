
using System.ComponentModel.DataAnnotations;

namespace WebApi_AndroidApp.Models
{
    public class Messageitem
    {
        [Key]
        public long MessageID { get; set; }
        public long FromUserID { get; set; }
        public long ToUserID { get; set; }
        public string? Value { get; set; }
        public DateTime TimeSent { get; set; }
        public DateTime TimeRecieved { get; set; }
    }
}
