using App.Domain.IUnitofWork;
using App.Services.Abstractions.IServices;
using App.Services.Abstractions.IServicesManager;
using App.Services.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persentation.ServicesManager
{
    public class FinanceServiceManager : IFinanceServiceManager
    {
        private readonly IUnitofwork _unitOfWork;
        public FinanceServiceManager(IUnitofwork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IFinanceService _financeService;

        public IFinanceService FinanceService =>
       _financeService ??= new FinanceService(_unitOfWork);
    }
}
