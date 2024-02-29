#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; private set; }

        public string UserName { get; private set; }

        public string Email { get; private set; }

        [MaxLength(1024)]
        [Required]
        [Column(TypeName = "varbinary(1024)")]
        public byte[] PasswordHash { get; private set; }

        [MaxLength(1024)]
        [Required]
        [Column(TypeName = "varbinary(1024)")]
        public byte[] PasswordSalt { get; private set; }


        [Required]
        [Range(0.0, float.MaxValue, ErrorMessage = "Lỗi nhập, số tiền trong ví không Âm")]
        public float WalletBalance { get; private set; }

        public string Phone { get; private set; }

        public bool Status { get; private set; }

        //khóa ngoại
        [ForeignKey("Role")]
        public int RoleID { get; private set; }
        public virtual Role Role { get; private set; }


        //[JsonIgnore]
        public virtual ICollection<Order> Orders { get; private set; }  

        public virtual ICollection<RegisterAuction> RegisterAuctions { get; private set; }      

        public virtual ICollection<Transaction> Transactions { get; private set; }

        public virtual ICollection<Comment> Comments { get; private set; }


        //JWT
        [NotMapped]
        public string RefreshToken { get; set; }
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }

    }
}
