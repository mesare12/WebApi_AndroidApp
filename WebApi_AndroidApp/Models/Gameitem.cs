using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_AndroidApp.Models
{
    public class Gameitem
    {
        [Key]
        public long GameID { get; set; }

        [ForeignKey("UserID")]
        public long PlayerOneID { get; set; }

        [ForeignKey("UserID")]
        public long PlayerTwoID { get; set; }

        public string? PlayerOneChoice { get; set;}
        public string? PlayerTwoChoice { get; set;}
        public string? PlayerWinner { get; set;} 

        [ForeignKey("MessageID")]
        public long PlayerMessageID { get; set; }
        [ForeignKey("MoveID")]
        public short GameMoveID { get; set; }
    }
}
