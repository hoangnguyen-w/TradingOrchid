using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Aution
    {
        [Key]
        public int AutionID { get; set; }

        public string? AutionTitle { get; set; }

        public string? AutionDescription { get; set; }

        public float StartingBid { get; set; }

        public float MaxBid { get; set; }

        public DateTime DateOpened { get; set; }

        public DateTime DateClosed { get; set; }

        public int Status { get; set; }

        //Khóa ngoại
        [ForeignKey("RegisterAuction")]
        public int? BidID { get; set; }
        public virtual RegisterAuction? RegisterAuction { get; set; }
    }
}
