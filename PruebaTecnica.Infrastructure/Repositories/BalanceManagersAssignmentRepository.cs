using PruebaTecnica.Core.DTOS;
using PruebaTecnica.Core.DTOS.Commons;
using PruebaTecnica.Core.DTOS.Responses;
using PruebaTecnica.Core.Interfaces.DataContext;
using PruebaTecnica.Core.Interfaces.Repository;
using PruebaTecnica.Core.Interfaces.Service;
using PruebaTecnica.Infrastructure.Helpers;
using System.Data;
using System.Data.SqlClient;

namespace PruebaTecnica.Infrastructure.Repositories
{
    public class BalanceManagersAssignmentRepository(IExecuteStoredProcedureService executeStoredProcedureService,IPruebaTecnicaContext context,ILogService logService) : IBalanceManagersAssignmentRepository
    {
        private readonly IExecuteStoredProcedureService _executeStoredProcedure = executeStoredProcedureService;
        private readonly IPruebaTecnicaContext _context = context;
        private readonly ILogService _logService = logService;
        public async Task<ResponseDTO> AssignAllBalances()
        {
            ResponseDTO response = new ResponseDTO();
            response.IsSuccess = false;
            try
            {
                using SqlCommand command = _context.CreateCommand();
                command.CommandText = "AssignBalanceToManager";
                command.CommandType = CommandType.StoredProcedure;

                DataSet dataSet = new DataSet();

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    await Task.Run(() => adapter.Fill(dataSet));
                }

                var tableStatus = dataSet.Tables[0];
                var statusList = tableStatus.ToList<StatusResponse>();
                var status = statusList.First();

                var secondTable = dataSet.Tables[1];
                var Iterations = secondTable.AsEnumerable()
                    .Select(row => row.Field<int>("Iterations"))
                    .ToList();

                var thirdTable = dataSet.Tables[2];
                var assignForManager = thirdTable.ToList<ManagerAssignmentDTO>();

                var lastTable = dataSet.Tables[3];
                var listManagerAndAssignment = lastTable.ToList<BalanceAssignmentDTO>();

                response.IsSuccess = status.IsSuccess;
                response.Message = status.Message;

                object obj = new
                {
                    Iterations,
                    assignForManager,
                    listManagerAndAssignment
                };
                response.Data = obj;

            }
            catch (Exception ex)
            {
                _logService.message($"Se ha producido un error al ejecutar el SP AssignBalanceToManager: {ex.Message}");
            }
            return response;
        }

        public async Task<ResponseDTO> CreateBalanceManagersAssignment(BalanceManagersAssignmentDTO balanceManagersAssignment)
        {
            object obj = new
            {
                balanceManagersAssignment.BalanceId,
                balanceManagersAssignment.ManagerId
            };
            return await _executeStoredProcedure.ExecuteStoredProcedure("CreateBalanceManagersAssignment", obj);
        }

        public async Task<ResponseDTO> DeleteBalanceManagersAssignment(int assignmentId)
        {
            object obj = new
            {
                AssignmentId = assignmentId
            };
            return await _executeStoredProcedure.ExecuteStoredProcedure("DeleteBalanceManagersAssignment", obj);
        }

        public async Task<ResponseDTO> GetListBalanceManagersAssignment(PaginatorDTO paginator, int? assignmentId)
        {
            object obj = new
            {
                paginator.PageIndex,
                paginator.PageSize,
                AssignmentId = assignmentId
            };
            return await _executeStoredProcedure.ExecuteTableStoredProcedure("GetListBalanceManagersAssignment", obj, MapToListHelper.MapToList<BalanceManagersAssignmentResponseDTO>);
        }

        public async Task<ResponseDTO> UpdateBalanceManagersAssignment(BalanceManagersAssignmentDTO balanceManagersAssignment)
        {
            object obj = new
            {
                balanceManagersAssignment.AssignmentId,
                balanceManagersAssignment.BalanceId,
                balanceManagersAssignment.ManagerId
            };
            return await _executeStoredProcedure.ExecuteStoredProcedure("UpdateBalanceManagersAssignment", obj);
        }
    }
}
