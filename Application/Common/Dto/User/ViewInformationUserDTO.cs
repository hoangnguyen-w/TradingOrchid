using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dto.User
{
    public class ViewInformationUserDTO
    {
        public string UserName { get; set; }

        public string Email {  get; set; }

        public float WalletBalance { get; set; }

        public string Phone {  get; set; }

        public string RoleName { get; set; }
    }
}
