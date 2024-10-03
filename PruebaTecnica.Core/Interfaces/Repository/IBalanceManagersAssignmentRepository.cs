using PruebaTecnica.Core.DTOS;
using PruebaTecnica.Core.DTOS.Commons;

namespace PruebaTecnica.Core.Interfaces.Repository
{
    public interface IBalanceManagersAssignmentRepository
    {
        Task<ResponseDTO> CreateBalanceManagersAssignment(BalanceManagersAssignmentDTO balanceManagersAssignment);
        Task<ResponseDTO> UpdateBalanceManagersAssignment(BalanceManagersAssignmentDTO balanceManagersAssignment);
        Task<ResponseDTO> DeleteBalanceManagersAssignment(int assignmentId);
        Task<ResponseDTO> GetListBalanceManagersAssignment(PaginatorDTO paginator,int? assignmentId);
        Task<ResponseDTO> AssignAllBalances();
    }
}
