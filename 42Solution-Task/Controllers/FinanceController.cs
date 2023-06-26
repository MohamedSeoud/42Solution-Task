using App.Contracts;
using App.Services.Abstractions.IServicesManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _42Solution_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceController : ControllerBase
    {
        private readonly IFinanceServiceManager _service;
        public FinanceController(IFinanceServiceManager service)
        {
            _service = service;
        }

        [HttpGet(nameof(GetFilteredFinanceRequest))]
        [Produces("application/json", Type = typeof(PagedEntity<FinanceRequestDto>))]
  //      [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetFilteredFinanceRequest(PagationFilter filter)
            => Ok(await _service.FinanceService.GetFilteredFinanceRequest(filter));
    }
}
