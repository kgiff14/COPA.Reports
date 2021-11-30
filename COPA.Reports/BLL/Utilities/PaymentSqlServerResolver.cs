using Conservice.Application;
using Conservice.DataUtilities.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COPA.Reports.BLL.Utilities
{
    public class PaymentSqlServerResolver : ISqlServerResolver
    {
        public string GetSqlServerAddress(ApplicationEnvironment environment, string database = "master")
        {
            switch (environment)
            {
                case ApplicationEnvironment.Production:
                    return "192.168.4.172";
                case ApplicationEnvironment.Development:
                    return "192.168.5.154";
                case ApplicationEnvironment.Test:
                    return "192.168.4.191";
                default:
                    return "No connection to Payment";
            }
        }
        public string GetSqlServerAddress(string environment, string database = "master") => 
            GetSqlServerAddress(environment.ToApplicationEnvironment(), database);
    }
}
