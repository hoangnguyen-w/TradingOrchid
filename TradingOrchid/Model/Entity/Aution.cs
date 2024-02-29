#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradingOrchid.Model.Entity
{
    public class Aution
    {
        [Key]
        public int AutionID { get; set; }

        public string AutionTitle { get; set; }

        public string AutionDescription { get; set; }

        public DateTime StartingBid { get; set; }

        [Required]
        [Range(1000.0, float.MaxValue, ErrorMessage = "Lỗi nhập, giá phải từ 1000 VND trở lên ")]
        public float MaxBid { get; set; }

        public DateTime DateOpened { get; set; }

        public DateTime DateClosed { get; set; }

        public int Status { get; set; }

        //Khóa ngoại
        [ForeignKey("RegisterAuction")]
        public int BidID { get; set; }
        public virtual RegisterAuction RegisterAuction { get; set; }
    }
}
