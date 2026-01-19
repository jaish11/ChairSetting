using ChairSetting.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace ChairSetting.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Chair> Chairs { get; set; }
    }
}
