using PruebaTecnica.Core.DTOS;
using PruebaTecnica.Core.DTOS.Commons;
using PruebaTecnica.Core.Interfaces.Repository;
using PruebaTecnica.Core.Interfaces.Service;
using PruebaTecnica.Infrastructure.Helpers;

namespace PruebaTecnica.Infrastructure.Repositories
{
    public class BalanceRepository(IExecuteStoredProcedureService executeStoredProcedureService) : IBalanceRepository
    {
        private readonly IExecuteStoredProcedureService _executeStoredProcedureService = executeStoredProcedureService;
        public async Task<ResponseDTO> CreateBalance(BalanceDTO balanceDTO)
        {
            object obj = new
            {
                balanceDTO.Balance
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("CreateBalance", obj);
        }

        public async Task<ResponseDTO> DeleteBalance(int balanceId)
        {
            object obj = new
            {
                BalanceId = balanceId
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("DeleteBalance", obj);
        }

        public async Task<ResponseDTO> GetListBalance(PaginatorDTO paginatorDTO, int? balanceId)
        {
            object obj = new
            {
                paginatorDTO.PageIndex,
                paginatorDTO.PageSize,
                BalanceId = balanceId
            };
            return await _executeStoredProcedureService.ExecuteTableStoredProcedure("GetListBalance", obj, MapToListHelper.MapToList<BalanceDTO>);
        }

        public async Task<ResponseDTO> UpdateBalance(BalanceDTO balanceDTO)
        {
            object obj = new
            {
                balanceDTO.BalanceId,
                balanceDTO.Balance
            };
            return await _executeStoredProcedureService.ExecuteStoredProcedure("UpdateBalance", obj);
        }
    }
}
