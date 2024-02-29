#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class OrchidProduct
    {
        [Key]
        public int OrchidID { get; private set; }

        [Required]
        public string OrchidName { get; private set; }

        public string Characteristics { get; private set; }

        [Required]
        [Range(1000.0, float.MaxValue, ErrorMessage = "Lỗi nhập, giá phải từ 1000 VND trở lên ")]
        public float UnitPrice { get; private set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Lỗi nhập, Số lượng không được Âm")]
        public int Quantity { get; private set; }

        public int Status { get; private set; }

        //Khóa ngoại

    }
}
