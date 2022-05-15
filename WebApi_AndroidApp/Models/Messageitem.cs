
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_AndroidApp.Models
{
    public class MessageItem
    {
        [Key]
        public long? MessageID { get; set; } = null;

        [ForeignKey("UserID")]
        public long FromUserID { get; set; }
        
        [ForeignKey("UserID")]
        public long ToUserID { get; set; }
        public string? Value { get; set; } 
        public DateTime TimeSent { get; set; }
        public DateTime TimeReceived { get; set; }
    }
}
