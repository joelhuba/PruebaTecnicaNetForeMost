using PruebaTecnica.Core.DTOS;
using PruebaTecnica.Core.DTOS.Commons;
using PruebaTecnica.Core.Interfaces.BLL;
using PruebaTecnica.Core.Interfaces.Repository;
using PruebaTecnica.Core.Interfaces.Service;
using PruebaTecnica.Infrastructure.Helpers;
using System.Reflection;

namespace PruebaTecnica.Infrastructure.BLL
{
    public class BalanceManagersAssignmentBLL(IBalanceManagersAssignmentRepository balanceManagersAssignment, ILogService logService) : IBalanceManagersAssignmentBLL
    {
        private readonly IBalanceManagersAssignmentRepository _balanceManagersAssignmentRepository = balanceManagersAssignment;
        private readonly ILogService _logService = logService;
        public async Task<ResponseDTO> AssignAllBalances()
        {

            try
            {
                return await _balanceManagersAssignmentRepository.AssignAllBalances();
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> CreateBalanceManagersAssignment(BalanceManagersAssignmentDTO balanceManagersAssignment)
        {

            try
            {
                return await _balanceManagersAssignmentRepository.CreateBalanceManagersAssignment(balanceManagersAssignment);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService,MethodBase.GetCurrentMethod().Name ,ex);
            }
        }

        public async Task<ResponseDTO> DeleteBalanceManagersAssignment(int assignmentId)
        {
            try
            {
                return await _balanceManagersAssignmentRepository.DeleteBalanceManagersAssignment(assignmentId);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> GetListBalanceManagersAssignment(PaginatorDTO paginator, int? assignmentId)
        {
            try
            {
                return await _balanceManagersAssignmentRepository.GetListBalanceManagersAssignment(paginator, assignmentId);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> UpdateBalanceManagersAssignment(BalanceManagersAssignmentDTO balanceManagersAssignment)
        {
            try
            {
                return await _balanceManagersAssignmentRepository.UpdateBalanceManagersAssignment(balanceManagersAssignment);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
