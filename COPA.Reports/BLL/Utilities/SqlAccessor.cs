using Conservice.Application;
using Conservice.DataUtilities.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COPA.Reports.BLL.Utilities
{
    public class SqlAccessor
    {
        public readonly SqlConnectionFactory ConnectionFactory;

        public readonly ApplicationEnvironment ApplicationEnvironment;

        public SqlAccessor(EnvironmentAccessor config)
        {
            ApplicationEnvironment environment = config.Environment;
            ConnectionFactory = GetConnectionFactory(environment);
            ApplicationEnvironment = environment;
        }

        private SqlConnectionFactory GetConnectionFactory(ApplicationEnvironment environment)
        {
            SqlConnectionFactory factory = new SqlConnectionFactory(environment, new PaymentSqlServerResolver());

            return factory;
        }
    }
}
