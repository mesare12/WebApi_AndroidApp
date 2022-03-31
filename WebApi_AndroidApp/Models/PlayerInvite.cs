using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_AndroidApp.Models
{
    public class PlayerInvite
    {
        [ForeignKey("UserID")]
        public long InviteToUserID { get; set; }

        [ForeignKey("UserID")]
        public long InviteFromUserID { get; set; }
    }
}
