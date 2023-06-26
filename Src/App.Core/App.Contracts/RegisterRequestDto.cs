using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Contracts
{
    public class RegisterRequestDto
    {
        public string FirstName { set; get; }
        public string Lastname { set; get; }
        public string ProfilePicture { set; get; }
        public string Password { set; get; }
        public string Email { set; get; }
    }
}
