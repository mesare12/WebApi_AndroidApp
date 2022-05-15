using System.ComponentModel.DataAnnotations;

namespace WebApi_AndroidApp.Models
{
    public class UserItem
    {
        [Key]
        public long? UserID { get; }
        public string? UserName { get; set; } = "";
        public string? FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;
        public string? UserEmail { get; set; } = null!;
        public string? PasswordHash { get; set; } = null!;
        public string? Token { get; set; } = null!;
        public DateTime? TokenIssued { get; set; }
        public long Wins { get; set; }
        public long Losses { get; set; }
        public long Gamesplayed { get; set; }


    }
}
