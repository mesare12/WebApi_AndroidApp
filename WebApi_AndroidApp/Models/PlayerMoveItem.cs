using System.ComponentModel.DataAnnotations;

namespace WebApi_AndroidApp.Models
{
    public class PlayerMoveItem
    {
        [Key]
       public byte MoveID { get; set;}
       public string? MovesTitle { get; set;}

    }
}
