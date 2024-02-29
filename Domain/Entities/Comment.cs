#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Comment
    {
        [Key]
        public int CommentID { get; private set; }

        public string CommentMsg { get; private set; }

        public DateTime CreateDate { get; private set; }

        public bool IsCheckBool { get; private set; }

        //khóa ngoại

        [ForeignKey("User")]
        public int UserID { get; private set; }
        public virtual User User { get; private set; }


        [ForeignKey("Information")]
        public int InformationID { get; private set; }
        public virtual Information Information { get; private set; }
    }
}
