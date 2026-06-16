using Microsoft.EntityFrameworkCore;
using TableMapping.Entity;
using TableMapping.Entity.Model;

namespace TableMapping.DatabaseContext
{
    public class TableMappingDbContext:DbContext
    {
        public TableMappingDbContext(DbContextOptions<TableMappingDbContext>options) :base(options){ }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Account)
                .WithOne(a => a.User)
                .HasForeignKey<Account>(a => a.UserId);
        }
    }
}
