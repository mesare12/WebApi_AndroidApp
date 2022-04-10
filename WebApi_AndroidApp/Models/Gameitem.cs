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

        [ForeignKey("MoveID")]
        public byte PlayerOneChoice { get; set;}
        
        [ForeignKey("MoveID")]
        public byte PlayerTwoChoice { get; set;}
        public long PlayerWinner { get; set;} 

        [ForeignKey("MessageID")]
        public long PlayerMessageID { get; set; }

        public Boolean IsActive { get; set; }
     
    }
}
