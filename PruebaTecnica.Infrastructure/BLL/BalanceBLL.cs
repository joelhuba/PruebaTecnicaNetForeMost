using PruebaTecnica.Core.DTOS;
using PruebaTecnica.Core.DTOS.Commons;
using PruebaTecnica.Core.Interfaces.BLL;
using PruebaTecnica.Core.Interfaces.Repository;
using PruebaTecnica.Core.Interfaces.Service;
using PruebaTecnica.Infrastructure.Helpers;
using System.Reflection;

namespace PruebaTecnica.Infrastructure.BLL
{
    public class BalanceBLL(IBalanceRepository balanceRepository, ILogService logService) : IBalanceBLL
    {
        private readonly IBalanceRepository _balanceRepository = balanceRepository;
        private readonly ILogService _logService = logService;
        public async Task<ResponseDTO> CreateBalance(BalanceDTO balanceDTO)
        {
            try
            {
                return await _balanceRepository.CreateBalance(balanceDTO);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService,MethodBase.GetCurrentMethod().Name ,ex);
            }
        }

        public async Task<ResponseDTO> DeleteBalance(int balanceId)
        {
            try
            {
                return await _balanceRepository.DeleteBalance(balanceId);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> GetListBalance(PaginatorDTO paginatorDTO, int? balanceId)
        {
            try
            {
                return await _balanceRepository.GetListBalance(paginatorDTO, balanceId);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> UpdateBalance(BalanceDTO balanceDTO)
        {
            try
            {
                return await _balanceRepository.UpdateBalance(balanceDTO);
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
