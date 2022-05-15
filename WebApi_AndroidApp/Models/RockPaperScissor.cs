using Microsoft.EntityFrameworkCore;
using WebApi_AndroidApp.Models;

namespace WebApi_AndroidApp.Models
{
    public class RockPaperScissor : DbContext
    {
        public RockPaperScissor(DbContextOptions<RockPaperScissor> options) : base(options)
        {

        }
        public DbSet<UserItem> User { get; set; } = null!;
        public DbSet<PlayerInvite> PlayerInvite { get; set; } = null!;
        public DbSet<WebApi_AndroidApp.Models.MessageItem> Message { get; set; } = null!;
        public DbSet<Gameitem> Game { get; set; } = null!;
        public DbSet<PlayerMoveItem> PlayerMoves { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserItem>()
                .HasKey(c => new { c.UserID });
            modelBuilder.Entity<PlayerInvite>()
                .HasKey(c => new { c.InviteFromUserID, c.InviteToUserID });
            modelBuilder.Entity<Gameitem>()
                .HasKey(c => new {c.PlayerOneID, c.PlayerTwoID});
            modelBuilder.Entity<MessageItem>()
                .HasKey(c => new {c.FromUserID, c.ToUserID});
        }
    }
}
    