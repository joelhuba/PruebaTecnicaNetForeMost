using PruebaTecnica.Core.DTOS.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Interfaces.BLL
{
    public interface IManagersBLL
    {
        Task<ResponseDTO> CreateManager(ManagerDTO manager);
        Task<ResponseDTO> UpdateManager(ManagerDTO manager);
        Task<ResponseDTO> DeleteManager(int managerId);
        Task<ResponseDTO> GetListManager(PaginatorDTO paginator, int? managerId);
    }
}
