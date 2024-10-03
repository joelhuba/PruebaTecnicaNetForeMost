using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.DTOS.Responses
{
    public class BalanceManagersAssignmentResponseDTO
    {
        public int AssignmentId { get; set; }
        public decimal Balance { get; set; }
        public string Name { get; set; }
    }
}
