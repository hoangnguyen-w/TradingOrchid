#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; private set; }

        //khóa ngoại

        [ForeignKey("User")]
        public int UserID { get; private set; }
        public virtual User User { get; private set; }

        [ForeignKey("OrderDetail")]
        public int OrderDetailID { get; private set; }
        public virtual OrderDetail OrderDetail { get; private set; }
    }
}
