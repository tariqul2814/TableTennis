using System;
using System.Collections.Generic;
using System.Text;

namespace TableTennis.DataAccess.CommonModel
{
    public class SqlCommandParameter
    {
        public string ParameterName { get; set; }
        public object ParameterValue { get; set; }

        public static SqlCommandParameter AddParameter(string parameterName, object parameterValue)
        {
            return new SqlCommandParameter
            {
                ParameterName = parameterName,
                ParameterValue = parameterValue
            };
        }

        public static SqlCommandParameter AddOutputParameter(string parameterName, object parameterValue)
        {
            return new SqlCommandParameter
            {
                ParameterName = parameterName,
                ParameterValue = parameterValue
            };
        }
    }
}
