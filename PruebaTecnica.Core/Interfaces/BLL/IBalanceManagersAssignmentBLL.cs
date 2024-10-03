using PruebaTecnica.Core.DTOS.Commons;
using PruebaTecnica.Core.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Interfaces.BLL
{
    public interface IBalanceManagersAssignmentBLL
    {
        Task<ResponseDTO> CreateBalanceManagersAssignment(BalanceManagersAssignmentDTO balanceManagersAssignment);
        Task<ResponseDTO> UpdateBalanceManagersAssignment(BalanceManagersAssignmentDTO balanceManagersAssignment);
        Task<ResponseDTO> DeleteBalanceManagersAssignment(int assignmentId);
        Task<ResponseDTO> GetListBalanceManagersAssignment(PaginatorDTO paginator, int? assignmentId);
        Task<ResponseDTO> AssignAllBalances();
    }
}
