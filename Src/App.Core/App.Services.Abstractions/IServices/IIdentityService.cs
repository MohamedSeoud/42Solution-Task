using App.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Abstractions.IServices
{
    public interface IIdentityService
    {
        public Task<LoginResponseDto> Login(LoginRequestDto model);
        public Task<IdentityResult> Register(RegisterRequestDto register);
    }
}
