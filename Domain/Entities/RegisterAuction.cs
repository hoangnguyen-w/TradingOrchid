#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class RegisterAuction
    {
        [Key]
        public int BidID { get; private set; }

        [Required]
        [Range(1000.0, float.MaxValue, ErrorMessage = "Lỗi nhập, giá phải từ 1000 VND trở lên ")]
        public float Price { get; private set; }

        [Required]
        [Range(1000.0, float.MaxValue, ErrorMessage = "Lỗi nhập, giá phải từ 1000 VND trở lên ")]
        public float Deposit { get; private set; }

        //Khóa ngoại
        [ForeignKey("User")]
        public int UserID { get; private set; }
        public virtual User User { get; private set; }

        public virtual ICollection<Aution> Autions { get; private set; }
    }
}
