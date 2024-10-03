using PruebaTecnica.Core.DTOS.Commons;

namespace PruebaTecnica.Core.Interfaces.Repository
{
    public interface IManagersRepository
    {
        Task<ResponseDTO> CreateManager(ManagerDTO manager);
        Task<ResponseDTO> UpdateManager(ManagerDTO manager);
        Task<ResponseDTO> DeleteManager(int managerId);
        Task<ResponseDTO> GetListManager(PaginatorDTO paginator, int? managerId);
    }
}
