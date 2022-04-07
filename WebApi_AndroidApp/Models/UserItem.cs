using System.ComponentModel.DataAnnotations;

namespace WebApi_AndroidApp.Models
{
    public class UserItem
    {
        [Key]
        public long UserID { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserEmail { get; set; }
        public string? PasswordHash { get; set; }
        public string? Token { get; set; }
        public DateTime? TokenIssued { get; set; }
        public long Wins { get; set; }
        public long Losses { get; set; }
        public long Gamesplayed { get; set; }

    }
}
