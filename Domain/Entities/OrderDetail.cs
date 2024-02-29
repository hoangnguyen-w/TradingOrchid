#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; private set; }

        [Required]
        [Range(1000.0, float.MaxValue, ErrorMessage = "Lỗi nhập, giá phải từ 1000 VND trở lên ")]
        public float UnitPrice { get; private set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Lỗi nhập, Số lượng không được bé hơn 0")]
        public int Quanlity { get; private set; }


        //Khóa ngoại
        [ForeignKey("Order")]
        public int OrderID { get; private set; }
        public virtual Order Order { get; private set; }

        [ForeignKey("OrchidProduct")]
        public int OrchidID { get; private set; }
        public virtual OrchidProduct OrchidProduct { get; private set; }
    }
}
