﻿using App.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.IRepositories
{
    public interface IIdentityRepository
    {
        Task<LoginResponse> Login(LoginRequestDto model);
        Task<IdentityResult> Register(RegisterRequestDto register);
    }
}
