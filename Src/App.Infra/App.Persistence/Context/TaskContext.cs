using App.Persistence.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence.Context
{
    public class TaskContext : IdentityDbContext<AppUser, ApplicationRole, string>
    {
        public TaskContext(DbContextOptions<TaskContext> options)
          : base(options)
        {
        }

        public virtual DbSet<FinanceRequest> FinanceRequests { get; set; }
    }
}
