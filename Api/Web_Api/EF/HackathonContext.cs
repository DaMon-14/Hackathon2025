using Microsoft.EntityFrameworkCore;
using Web_Api.EF.DBO;

namespace Web_Api.EF
{
    public class HackathonContext : DbContext
    {
        public HackathonContext(DbContextOptions<HackathonContext> options) : base(options)
        {
        }

        public DbSet<UserDBO> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDBO>().HasKey(u => u.Id);

            modelBuilder.Entity<UserDBO>().HasData(new UserDBO
            {
                Id = 1,
                Username = "admin",
                PasswordHash = "admin"
            });
        }
    }
}
