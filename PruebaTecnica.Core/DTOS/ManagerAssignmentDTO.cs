using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.DTOS
{
    public class ManagerAssignmentDTO
    {
        public int ManagerId { get; set; }
        public string Name { get; set; }
        public int AssignedBalances { get; set; }
    }
}
