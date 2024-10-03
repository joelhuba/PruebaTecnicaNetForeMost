using PruebaTecnica.Core;
using PruebaTecnica.Core.DTOS.Commons;
using PruebaTecnica.Core.Interfaces.Repository;
using PruebaTecnica.Core.Interfaces.Service;
using PruebaTecnica.Infrastructure.Helpers;

namespace PruebaTecnica.Infrastructure.Repositories
{
    public class ManagersRepository(IExecuteStoredProcedureService executeStoredProcedureService) : IManagersRepository
    {
        private readonly IExecuteStoredProcedureService _executeStoredProcedureService = executeStoredProcedureService;
        public async Task<ResponseDTO> CreateManager(ManagerDTO manager)
        {
            object obj = new
            {
                manager.Name
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("CreateManager", obj);
        }

        public async Task<ResponseDTO> DeleteManager(int managerId)
        {
            object obj = new
            {
                ManagerId = managerId
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("DeleteManager", obj);
        }

        public async Task<ResponseDTO> GetListManager(PaginatorDTO paginator, int? managerId)
        {
            object obj = new
            {
                paginator.PageIndex,
                paginator.PageSize,
                ManagerId = managerId
            };
            return await _executeStoredProcedureService.ExecuteTableStoredProcedure("GetListManagers", obj, MapToListHelper.MapToList<ManagerDTO>);
        }

        public async Task<ResponseDTO> UpdateManager(ManagerDTO manager)
        {
            object obj = new
            {
               manager.ManagerId,
               manager.Name,
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("UpdateManager", obj);
        }
    }
}
