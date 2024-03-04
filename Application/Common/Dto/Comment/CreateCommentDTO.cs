using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dto.Comment
{
    public class CreateCommentDTO
    {
        public string CommentMsg { get; set; }

        public int UserID { get; set; } 

        public int InformationID { get; set; }  
    }
}
