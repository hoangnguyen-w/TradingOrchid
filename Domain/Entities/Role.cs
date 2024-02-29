#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Role
    {
        [Key]
        public int RoleID { get; private set; }

        [Required]
        public string RoleName { get; private set; }

        public virtual ICollection<User> Users { get; private set; }

    }
}
