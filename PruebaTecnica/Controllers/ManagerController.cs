using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Core;
using PruebaTecnica.Core.DTOS.Commons;
using PruebaTecnica.Core.Interfaces.BLL;
using PruebaTecnica.Core.Interfaces.Service;
using PruebaTecnica.Helpers;
using System.Reflection;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController(IManagersBLL managersBLL,ILogService logService) : ControllerBase
    {
        private readonly IManagersBLL _managersBLL = managersBLL;
        private readonly ILogService _logService =logService;

        [HttpPost("/CreateManager")]
        public async Task<IActionResult> CreateManager(ManagerDTO managerDTO)
        => await HandleResponses.HandleResponse(()=>_managersBLL.CreateManager(managerDTO),_logService,MethodBase.GetCurrentMethod().Name);

        [HttpPut("/UpdateManager")]
        public async Task<IActionResult> UpdateManager(ManagerDTO managerDTO)
        => await HandleResponses.HandleResponse(() => _managersBLL.UpdateManager(managerDTO), _logService, MethodBase.GetCurrentMethod().Name);

        [HttpDelete("/DeleteManager")]
        public async Task<IActionResult> DeleteManager(int managerId)
        => await HandleResponses.HandleResponse(() => _managersBLL.DeleteManager(managerId), _logService, MethodBase.GetCurrentMethod().Name);

        [HttpGet("/GetListManager")]
        public async Task<IActionResult> GetListManager([FromQuery] PaginatorDTO paginator,int? managerId)
        => await HandleResponses.HandleResponse(() => _managersBLL.GetListManager(paginator,managerId), _logService, MethodBase.GetCurrentMethod().Name);
    }
}
