﻿using App.Contracts;
using App.Domain.IRepositories;
using App.Persistence.Context;
using App.Persistence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly TaskContext _context;
        public IdentityRepository(RoleManager<ApplicationRole> roleManager,
                                UserManager<AppUser> userManager,
                                TaskContext context
                               )
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

        public async Task<LoginResponse> Login(LoginRequestDto model)
        {
            var user = await _context.Users
                .Where(u => u.Email.Equals(model.Email))
                .FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
            {
                return null;
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            return new LoginResponse
            {
                Email = user.Email,
                Roles = userRoles,
            };
        }

        public async Task<IdentityResult> Register(RegisterRequestDto register)
        {
            try
            {
                var user = new AppUser
                {
                    Email = register.Email,
                    FirstName = register.FirstName,
                    Lastname = register.Lastname,
                    ProfilePicture = register.ProfilePicture,
                    UserName = register.Email
                };
                var result = await _userManager.CreateAsync(user, register.Password);

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
