#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Aution
    {
        [Key]
        public int AutionID { get; private set; }

        public string AutionTitle { get; private set; }

        public string AutionDescription { get; private set; }

        public DateTime StartingBid { get; private set; }

        [Required]
        [Range(1000.0, float.MaxValue, ErrorMessage = "Lỗi nhập, giá phải từ 1000 VND trở lên ")]
        public float MaxBid { get; private set; }

        public DateTime DateOpened { get; private set; }

        public DateTime DateClosed { get; private set; }

        public int Status { get; private set; }

        //Khóa ngoại
        [ForeignKey("RegisterAuction")]
        public int BidID { get; private set; }
        public virtual RegisterAuction RegisterAuction { get; private set; }
    }
}
