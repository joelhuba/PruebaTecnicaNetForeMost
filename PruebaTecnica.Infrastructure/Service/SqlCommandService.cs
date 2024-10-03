using PruebaTecnica.Core.Interfaces.Service;
using System.Data.SqlClient;
using System.Reflection;

namespace PruebaTecnica.Infrastructure.Service
{
    public class SqlCommandService : ISqlCommandService
    {
        public void AddParameters<T>(SqlCommand command, T parameters)
        {
            if (parameters != null)
            {
                PropertyInfo[] properties = parameters.GetType().GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    string parameterName = $"@{property.Name}";
                    object? value = property.GetValue(parameters);

                    command.Parameters.AddWithValue(parameterName, value ?? DBNull.Value);
                }
            }
        }
    }
}
