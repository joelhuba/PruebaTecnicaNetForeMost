using PruebaTecnica.Core.DTOS.Commons;
using PruebaTecnica.Core.Interfaces.Service;

namespace PruebaTecnica.Infrastructure.Helpers
{
    public static class ExceptionHelper
    {
        // es un manejador de errores donde guarda el error en el archivo log
        public static ResponseDTO HandleException(ILogService logService, string methodName, Exception ex)
        {
            logService.message($"Se ha producido un error al ejecutar BLL: {methodName}: {ex.Message}");
            var response = new ResponseDTO
            {
                IsSuccess = false,
                Message = ex.ToString()
            };
            return response;
        }
    }
}
