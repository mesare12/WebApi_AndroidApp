using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_AndroidApp.Models
{
    public class Gameitem
    {
        [ForeignKey("UserID")]
        public long PlayerOneChoice { get; set; }

        [ForeignKey("UserID")]
        public long PlayerTwoChoice { get; set; }
    }
}
