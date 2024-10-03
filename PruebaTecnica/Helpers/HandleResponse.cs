﻿using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Core.DTOS.Commons;
using PruebaTecnica.Core.Interfaces.Service;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Helpers
{
    public class HandleResponses
    {
        public static async Task<ActionResult> HandleResponse(Func<Task<ResponseDTO>> action, ILogService _logService, string controllerName)
        {
            try
            {
                ResponseDTO response = await action.Invoke();

                return new OkObjectResult(response);

            }
            catch (ValidationException ex)
            {
                _logService.message($"Error desde :: {controllerName} :: {ex.Message}");
                return new BadRequestObjectResult(new ResponseDTO { Message = ex.Message });
            }
            catch (Exception ex)
            {
                _logService.message($"Error desde :: {controllerName} :: {ex.Message}");
                return new StatusCodeResult(500);
            }
        }
    }
}
