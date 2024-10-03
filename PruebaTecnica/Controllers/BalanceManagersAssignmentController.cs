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
    public class BalanceManagersAssignmentController(IBalanceManagersAssignmentBLL balanceManagersAssignment,ILogService logService) : ControllerBase
    {
        private readonly IBalanceManagersAssignmentBLL _balanceManagersAssignmentBLL = balanceManagersAssignment;
        private readonly ILogService _logService = logService;

        [HttpPost("/CreateBalanceManagersAssignment")]
        public async Task<IActionResult> CreateBalanceManagersAssignment(BalanceManagersAssignmentDTO balanceManagersAssignmentDTO) 
        => await HandleResponses.HandleResponse(()=>_balanceManagersAssignmentBLL.CreateBalanceManagersAssignment(balanceManagersAssignmentDTO),_logService,MethodBase.GetCurrentMethod().Name);

        [HttpPut("/UpdateBalanceManagersAssignment")]
        public async Task<IActionResult> UpdateBalanceManagersAssignment(BalanceManagersAssignmentDTO balanceManagersAssignmentDTO)
        => await HandleResponses.HandleResponse(() => _balanceManagersAssignmentBLL.UpdateBalanceManagersAssignment(balanceManagersAssignmentDTO), _logService, MethodBase.GetCurrentMethod().Name);

        [HttpDelete("/DeleteBalanceManagersAssignment")]
        public async Task<IActionResult> DeleteBalanceManagersAssignment(int AssignmentId)
        => await HandleResponses.HandleResponse(() => _balanceManagersAssignmentBLL.DeleteBalanceManagersAssignment(AssignmentId), _logService, MethodBase.GetCurrentMethod().Name);

        [HttpGet("/GetListBalanceManagersAssignment")]
        public async Task<IActionResult> GetListBalanceManagersAssignment([FromQuery]PaginatorDTO paginator,int? AssignmentId)
        => await HandleResponses.HandleResponse(() => _balanceManagersAssignmentBLL.GetListBalanceManagersAssignment(paginator,AssignmentId), _logService, MethodBase.GetCurrentMethod().Name);
        [HttpGet("/AssignAllBalances")]
        public async Task<IActionResult> AssignAllBalances() => await HandleResponses.HandleResponse(() => _balanceManagersAssignmentBLL.AssignAllBalances(), _logService, MethodBase.GetCurrentMethod().Name);
    }
}
