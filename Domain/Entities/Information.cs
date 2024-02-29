#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Information
    {
        [Key]
        public int InformationID { get; private set; }

        [Required]
        public string InformationTitle { get; private set; }

        public string Image { get; private set; }

        public int Status { get; private set; }

        public DateTime InformationCreateDate { get; private set; }

        //Khóa ngoại
        [ForeignKey("Aution")]
        public int AutionID { get; private set; }
        public virtual Aution Aution { get; private set; }


        [ForeignKey("OrchidProduct")]
        public int OrchidID { get; private set; }
        public virtual OrchidProduct OrchidProduct { get; private set; }


        public virtual ICollection<Comment> Comments { get; private set; }
    }
}
