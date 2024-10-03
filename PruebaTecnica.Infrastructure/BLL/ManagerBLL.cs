using PruebaTecnica.Core;
using PruebaTecnica.Core.DTOS.Commons;
using PruebaTecnica.Core.Interfaces.BLL;
using PruebaTecnica.Core.Interfaces.Repository;
using PruebaTecnica.Core.Interfaces.Service;
using PruebaTecnica.Infrastructure.Helpers;
using System.Reflection;

namespace PruebaTecnica.Infrastructure.BLL
{
    public class ManagerBLL(IManagersRepository managersRepository, ILogService logService) : IManagersBLL
    {
        private readonly IManagersRepository _manageRepository =managersRepository;
        private readonly ILogService _logService = logService;
        public async Task<ResponseDTO> CreateManager(ManagerDTO manager)
        {
            try
            {
                return await _manageRepository.CreateManager(manager);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService,MethodBase.GetCurrentMethod().Name ,ex);
            }
        }

        public async Task<ResponseDTO> DeleteManager(int managerId)
        {
            try
            {
                return await _manageRepository.DeleteManager(managerId);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> GetListManager(PaginatorDTO paginator, int? managerId)
        {
            try
            {
                return await _manageRepository.GetListManager(paginator, managerId);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> UpdateManager(ManagerDTO manager)
        {
            try
            {
                return await _manageRepository.UpdateManager(manager);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
