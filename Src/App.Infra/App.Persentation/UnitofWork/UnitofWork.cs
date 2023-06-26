using App.Domain.IRepositories;
using App.Domain.IUnitofWork;
using App.Persistence.Context;
using App.Persistence.Models;
using App.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persentation.UnitofWork
{
    public class UnitofWork : IUnitofwork
    {
        private readonly TaskContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UnitofWork(TaskContext context, RoleManager<ApplicationRole> roleManager,
                                UserManager<AppUser> userManager)
        {         
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

   
        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private IIdentityRepository _identityRepository;
        private IFinanceRequestRepository _financeRequestRepository;

        public IIdentityRepository IdentityRepository =>
          _identityRepository ??= new IdentityRepository(_roleManager, _userManager, _context);
        public IFinanceRequestRepository FinanceRequestRepository =>
          _financeRequestRepository ??= new FinanceRequestRepository(_context);
    }
}
