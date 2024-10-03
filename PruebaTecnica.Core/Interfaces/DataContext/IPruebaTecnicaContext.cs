using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Interfaces.DataContext
{
    public interface IPruebaTecnicaContext
    {
        SqlConnection GetConnection();
        SqlCommand CreateCommand();
    }
}
