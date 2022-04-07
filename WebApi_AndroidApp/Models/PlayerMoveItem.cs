using System.ComponentModel.DataAnnotations;

namespace WebApi_AndroidApp.Models
{
    public class PlayerMoveItem
    {
        [Key]
       public short MoveID { get; set;}
       public string? MoveTitle { get; set;}

    }
}
