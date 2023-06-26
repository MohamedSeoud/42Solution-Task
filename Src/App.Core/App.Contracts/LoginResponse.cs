using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Contracts
{
    public class LoginResponse
    {
        public IList<string> Roles { get; set; }
        public string Email { get; set; }
    }
}
