using Microsoft.Extensions.Configuration;
using PruebaTecnica.Core.Interfaces.DataContext;
using PruebaTecnica.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Infrastructure.DataContext
{
    public class PruebaTecnicaContext(ILogService logService, IConfiguration configuration) : IDisposable, IPruebaTecnicaContext
    {
        private readonly ILogService _logService = logService;
        private readonly IConfiguration _configuration = configuration;
        private SqlConnection? connection;
        public SqlConnection GetConnection()
        {
            try
            {
                if (connection == null || connection.State == ConnectionState.Closed)
                {
                    string defaultConnection = _configuration.GetConnectionString("DefaultConnection") ?? "";
                    connection = new SqlConnection(defaultConnection);
                    connection.Open();
                }
                return connection;
            }
            catch (Exception ex)
            {
                _logService.message($"Error :: {ex}");
                throw;
            }
        }

        public SqlCommand CreateCommand()
        {
            try
            {
                var command = new SqlCommand();
                command.Connection = GetConnection();
                command.CommandType = CommandType.Text;
                return command;
            }
            catch (Exception ex)
            {
                _logService.message($"Error :: {ex}");
                throw;
            }
        }
        public void Dispose()
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
