using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using TradingOrchid.Model.DTO;

namespace TradingOrchid.Model.Entity
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
            SeedRoles(modelBuilder);
            SeedUser(modelBuilder);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(new Role()
            {
                RoleID = 1,
                RoleName = "Admin"
            });

            builder.Entity<Role>().HasData(new Role()
            {
                RoleID = 2,
                RoleName = "Customer"
            });

            builder.Entity<Role>().HasData(new Role()
            {
                RoleID = 3,
                RoleName = "Manager"
            });

            builder.Entity<Role>().HasData(new Role()
            {
                RoleID = 4,
                RoleName = "Orchid Owner"
            });

            builder.Entity<Role>().HasData(new Role()
            {
                RoleID = 5,
                RoleName = "Staff"
            });
        }

        private void SeedUser(ModelBuilder builder)
        {
            List<CreateUserDTO> list = new List<CreateUserDTO>(){
                new CreateUserDTO{Email="admin@gmail.com",Password="admin", Owner = "Admin",RoleID = 1 },
                new CreateUserDTO{Email="customer@gmail.com",Password="customer", Owner = "Customer",RoleID = 2 },
                new CreateUserDTO{Email="manager@gmail.com",Password="manager", Owner = "Manager",RoleID = 3 },
                new CreateUserDTO{Email="orchidowner@gmail.com",Password="orchid", Owner = "Orchid Owner",RoleID = 4},
                new CreateUserDTO{Email="staff@gmail.com",Password="staff", Owner = "Staff",RoleID = 5  },
            };

            int i = 0;
            foreach (CreateUserDTO dto in list)
            {
                //Base64Encode(list[i].Email, out string strEncode);
                CreatePasswordHash(list[i].Password, out byte[] passwordHash, out byte[] passwordSalt);
                User user = new User()
                {
                    UserID = i + 1,
                    Email = list[i].Email,
                    UserName = list[i].Owner,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true,
                    RoleID = list[i].RoleID
                };
                builder.Entity<User>().HasData(user);
                i++;
            }
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public void Base64Encode(string textStr, out string strEncode)
        {
            var textbytes = Encoding.UTF8.GetBytes(textStr);
            strEncode = Convert.ToBase64String(textbytes);
        }
    }
}
