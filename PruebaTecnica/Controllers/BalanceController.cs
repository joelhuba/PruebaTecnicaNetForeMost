using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Core.DTOS;
using PruebaTecnica.Core.DTOS.Commons;
using PruebaTecnica.Core.Interfaces.BLL;
using PruebaTecnica.Core.Interfaces.Service;
using PruebaTecnica.Helpers;
using System.Reflection;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceController(IBalanceBLL balanceBLL, ILogService logService) : ControllerBase
    {
        private readonly IBalanceBLL _balanceBLL = balanceBLL;
        private readonly ILogService _logService = logService;
        [HttpPost("/CreateBalance")]
        public async Task<IActionResult> CreateBalance(BalanceDTO balance)
        => await HandleResponses.HandleResponse(()=>_balanceBLL.CreateBalance(balance),_logService,MethodBase.GetCurrentMethod().Name);

        [HttpPut("/UpdateBalance")]
        public async Task<IActionResult> UpdateBalance(BalanceDTO balance)
        => await HandleResponses.HandleResponse(() => _balanceBLL.UpdateBalance(balance), _logService, MethodBase.GetCurrentMethod().Name);

        [HttpDelete("/DeleteBalance")]
        public async Task<IActionResult> DeleteBalance(int balanceId)
         => await HandleResponses.HandleResponse(() => _balanceBLL.DeleteBalance(balanceId), _logService, MethodBase.GetCurrentMethod().Name);

        [HttpGet("/GetListBalance")]
        public async Task<IActionResult> GetListBalance([FromQuery] PaginatorDTO paginator,int balanceId)
        => await HandleResponses.HandleResponse(() => _balanceBLL.GetListBalance(paginator,balanceId), _logService, MethodBase.GetCurrentMethod().Name);
    }
}
