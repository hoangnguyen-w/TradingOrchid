using Application.Common.Dto;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure
{
    public class TradingOrchidContext : DbContext
    {
        public DbSet<Aution> Autions { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Information> Informations { get; set; }

        public DbSet<OrchidProduct> OrchidProducts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<RegisterAuction> RegisterAuctions { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<User> Users { get; set; }


        public TradingOrchidContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasMany(c => c.Orders)
            .WithOne(c => c.User)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
           .HasMany(c => c.Informations)
           .WithOne(c => c.User)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
            .HasMany(c => c.Comments)
            .WithOne(c => c.User)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
            .HasMany(c => c.Transactions)
            .WithOne(c => c.User)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
            .HasMany(c => c.RegisterAuctions)
            .WithOne(c => c.User)
            .OnDelete(DeleteBehavior.Restrict);

            //Hàm này để ép dữ liệu mặc định
        }
    }
}
