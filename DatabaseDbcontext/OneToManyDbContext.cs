using Microsoft.EntityFrameworkCore;
using OneToMany.Entity.Model;
using OneToMany.Entity;

namespace OneToMany.DatabaseDbcontext
{
    public class OneToManyDbContext :DbContext
    {
        public OneToManyDbContext(DbContextOptions<OneToManyDbContext> options) : base(options) {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);
        }


    }
}
