using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TableTennis.DataAccess.CommonModel
{
    public class SqlCommandOutputParameter
    {
        public string ParameterName { get; set; }
        public SqlDbType SqlDbType { get; set; }
        public int Size { get; set; }

        public static SqlCommandOutputParameter AddOutputParameter(string parameterName, SqlDbType sqlDbType, int size = 0)
        {
            return new SqlCommandOutputParameter
            {
                ParameterName = parameterName,
                SqlDbType = sqlDbType,
                Size = size
            };
        }
    }
}
