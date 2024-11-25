
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace XXMountainBrigadeNew.Models
{
    public class MBDbContext : DbContext
    {
        public MBDbContext(DbContextOptions<MBDbContext> options)
       : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var dpk = modelBuilder.Entity<DataProtectionKey>();
            dpk.HasKey(x => x.Id);
        }

        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Usertbl> UsersTbl { get; set; }
    }
}
