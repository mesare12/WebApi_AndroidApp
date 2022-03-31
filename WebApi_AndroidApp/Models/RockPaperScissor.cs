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
        public DbSet<WebApi_AndroidApp.Models.Messageitem> Message { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerInvite>()
                .HasKey(c => new { c.InviteFromUserID, c.InviteToUserID });
        }
    }
}
    