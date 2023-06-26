using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Contracts
{
    public class LoginRequestDto
    {  
        public string Password { set; get; }
        public string Email { set; get; }
    }
}
