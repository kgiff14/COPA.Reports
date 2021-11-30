using COPA.Reports.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COPA.Reports.BLL
{
    public interface IPaymentBreakdownLogic
    {
        public List<COPAPaymentBreakdown> GetCOPAPaymentBreakdowns();
    }
}
