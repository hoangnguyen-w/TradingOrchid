using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }

        public float UnitPrice { get; set; }

        public int Quanlity { get; set; }

        //Khóa ngoại
        [ForeignKey("Order")]
        public int? OrderID { get; set; }
        public virtual Order? Order { get; set; }

        [ForeignKey("OrchidProduct")]
        public int? OrchidID { get; set; }
        public virtual OrchidProduct? OrchidProduct { get; set; }
    }
}
