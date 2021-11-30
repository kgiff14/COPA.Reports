using COPA.Reports.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COPA.Reports.DAL.Interfaces
{
    public interface IPaymentAccess
    {
        public List<PaymentBreakdown> GetPaymentBreakdowns(DateTime startDate, DateTime EndDate);
    }
}
