using App.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Abstractions.IServices
{
    public interface IFinanceService
    {
        public Task<PagedEntity<FinanceRequestDto>> GetFilteredFinanceRequest(PagationFilter filter);
    }
}
