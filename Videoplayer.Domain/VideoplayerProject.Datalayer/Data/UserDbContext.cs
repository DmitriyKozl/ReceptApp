using Microsoft.EntityFrameworkCore;
using VideoplayerProject.Datalayer.Models;

namespace VideoplayerProject.Datalayer.Data;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Users>().ToTable("Users").HasKey(t => t.Id);
        modelBuilder.Entity<Users>().Property(u => u.Username).HasColumnName("Username");
        modelBuilder.Entity<Users>().Property(u => u.Password).HasColumnName("Password");
        base.OnModelCreating(modelBuilder);
    }
}

