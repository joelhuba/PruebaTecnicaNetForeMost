using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.DTOS.Responses
{
    public class StatusResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
