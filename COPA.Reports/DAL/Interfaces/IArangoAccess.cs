using COPA.Reports.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COPA.Reports.DAL.Interfaces
{
    public interface IArangoAccess
    {
        public List<ArangoPaymentData> GetPaymentMetadata(IEnumerable<int> paymentIds);
    }
}
