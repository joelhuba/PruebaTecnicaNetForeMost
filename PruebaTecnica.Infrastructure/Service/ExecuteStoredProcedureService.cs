using PruebaTecnica.Core.DTOS.Commons;
using PruebaTecnica.Core.Interfaces.DataContext;
using PruebaTecnica.Core.Interfaces.Service;
using PruebaTecnica.Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Infrastructure.Service
{
    public class ExecuteStoredProcedureService(IPruebaTecnicaContext dataContext, ILogService logService, ISqlCommandService sqlCommandService) : IExecuteStoredProcedureService
    {
        private readonly IPruebaTecnicaContext _context = dataContext;
        private readonly ILogService _logService = logService;
        private readonly ISqlCommandService _sqlCommandService = sqlCommandService;

        private void HandleException(Exception ex, string storedProcedureName, ResponseDTO response)
        {
            _logService.message($"Se ha producido un error al ejecutar el SP {storedProcedureName}: {ex.Message}");
            response.Message += ex.ToString();
        }
        public async Task<ResponseDTO> ExecuteStoredProcedure(string storedProcedureName, object parameters)
        {
            ResponseDTO response = new ResponseDTO();
            response.IsSuccess = false;
            try
            {
                using SqlCommand command = _context.CreateCommand();
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;
                _sqlCommandService.AddParameters(command, parameters);
                using SqlDataReader reader = await command.ExecuteReaderAsync();
                await reader.ReadAsync();
                response.Message = reader.GetString(reader.GetOrdinal("Message"));
                response.IsSuccess = reader.GetBoolean(reader.GetOrdinal("IsSuccess"));
            }
            catch (Exception ex)
            {
                _logService.message($"Se ha producido un error al ejecutar el SP {storedProcedureName}: {ex.Message}");
            }
            return response;
        }
        public async Task<ResponseDTO> ExecuteTableStoredProcedure<TResult>(string storedProcedureName, object? parameters, Func<SqlDataReader, List<TResult>> mapFunction)
        {
            var response = new ResponseDTO
            {
                IsSuccess = false
            };

            try
            {
                using var command = _context.CreateCommand();
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    _sqlCommandService.AddParameters(command, parameters);
                }

                using var reader = await command.ExecuteReaderAsync();
                    reader.Close();
                    using var readerAgain = await command.ExecuteReaderAsync();
                    var resultList = mapFunction(readerAgain);
                    int totalRecords = 0;

                    if (await readerAgain.NextResultAsync() && await readerAgain.ReadAsync())
                    {
                        totalRecords = readerAgain.GetInt32(readerAgain.GetOrdinal("TotalRecords"));
                    }

                    response.Data = new { Results = resultList, TotalRecords = totalRecords };
                    response.Message = "Operación Exitosa";
            }
            catch (Exception ex)
            {
                HandleException(ex, storedProcedureName, response);
            }

            return response;
        }
    }
}
