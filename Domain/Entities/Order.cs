#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderID { get; private set; }

        public string OrderName { get; private set; }

        public DateTime OrderDate { get; private set; }

        public int Status { get; private set; }

        [Required]
        [Range(1000.0, float.MaxValue, ErrorMessage = "Lỗi nhập, giá phải từ 1000 VND trở lên ")]
        public float Total { get; private set; }

        //Khóa ngoại    
        [ForeignKey("User")]
        public int UserID { get; private set; }
        public virtual User User { get; private set; } 

        [ForeignKey("Aution")]
        public int AutionID { get; private set; }
        public virtual Aution Aution { get; private set; }
    }
}
