using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Infrastructure.Helpers
{
    public static class DataTableToObjectHelper
    {
        public static List<T> ToList<T>(this DataTable dataTable) where T : new()
        {
            List<T> list = new List<T>();

            foreach (DataRow row in dataTable.Rows)
            {
                T item = new T();

                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    if (dataTable.Columns.Contains(prop.Name))
                    {
                        object value = row[prop.Name];
                        if (value != DBNull.Value)
                        {
                            prop.SetValue(item, value);
                        }
                    }
                }

                list.Add(item);
            }

            return list;
        }
    }
}
