using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dto.Information
{
    public class InformationViewDTO
    {
        public string Image {  get; set; }

        public string Comment { get; set; }

        public string Title { get; set; }

        public float Bid {  get; set; }

        public string UserName { get; set; }
    }
}
