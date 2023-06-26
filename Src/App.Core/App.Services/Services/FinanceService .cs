using App.Contracts;
using App.Domain.IUnitofWork;
using App.Services.Abstractions;
using App.Services.Abstractions.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Services
{
    public class FinanceService : IFinanceService
    {
        private readonly IUnitofwork _unitOfWork;
        public FinanceService(IUnitofwork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedEntity<FinanceRequestDto>> GetFilteredFinanceRequest(PagationFilter filter)
        {
            return await _unitOfWork.FinanceRequestRepository.GetFilterFinanceRequestDtoData(filter);
        }
    }
}
