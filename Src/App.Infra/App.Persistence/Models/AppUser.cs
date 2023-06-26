using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { set; get; }
        public string Lastname { set; get; }
        public string ProfilePicture { set; get; }

    } 
}
