using PruebaTecnica.Core.DTOS;
using PruebaTecnica.Core.DTOS.Commons;

namespace PruebaTecnica.Core.Interfaces.BLL
{
    public interface IBalanceBLL
    {
        Task<ResponseDTO> CreateBalance(BalanceDTO balanceDTO);
        Task<ResponseDTO> UpdateBalance(BalanceDTO balanceDTO);
        Task<ResponseDTO> DeleteBalance(int balanceId);
        Task<ResponseDTO> GetListBalance(PaginatorDTO paginatorDTO, int? balanceId);
    }
}
