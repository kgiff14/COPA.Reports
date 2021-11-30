using Conservice.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COPA.Reports.BLL.Utilities
{
    public class EnvironmentAccessor
    {
        public readonly ApplicationEnvironment Environment;

        public EnvironmentAccessor()
        {
            Environment = GetEnvironment();
        }
        
        private ApplicationEnvironment GetEnvironment()
        {
            string environment = String.Empty;

            try
            {
                environment = System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            }
            catch
            {
                environment = "Development";
            }

            ApplicationEnvironment appEnvironment = environment.ToApplicationEnvironment();

            return appEnvironment;
        }
    }
}
