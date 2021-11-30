using ArangoWrapper.Collection;
using Conservice.Logging;
using COPA.Debug.BOL.PaymentRequestCollection;
using COPA.Reports.BLL.Utilities;
using COPA.Reports.BOL;
using COPA.Reports.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COPA.Reports.DAL.Implementations
{
    public class ArangoDataAccess : IArangoAccess
    {
        private static ILogger logger = LoggerFactory.CreateCurrentClassLogger();
        private CollectionConnector Connector { get; set; }
        private CollectionConnector PaymentRequestConnector { get; set; }

        public ArangoDataAccess(ArangoAccessor arangoAccessor)
        {
            Connector = arangoAccessor.Connector;
            PaymentRequestConnector = arangoAccessor.PaymentRequestConnector;
        }

        public List<ArangoPaymentData> GetPaymentMetadata(IEnumerable<int> paymentIds)
        {
            IEnumerable<string> stringPaymentIds = paymentIds.ToList().ConvertAll<string>(x => x.ToString());
            List<ArangoPaymentData> payments = Connector.GetDocumentsByKeys<ArangoPaymentData>(stringPaymentIds);

            return payments;
        }

        public PaymentRequest GetPaymentRulesByClientBillID(int clientBillID) =>
            PaymentRequestConnector.GetItemFromCollection<PaymentRequest>(clientBillID.ToString());
    }
}
