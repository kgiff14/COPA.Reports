using ArangoWrapper;
using ArangoWrapper.Collection;
using Conservice.Application;
using Conservice.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace COPA.Reports.BLL.Utilities
{
    public class ArangoAccessor
    {
        public readonly CollectionConnector Connector;
        public readonly CollectionConnector PaymentRequestConnector;

        public readonly ApplicationEnvironment ApplicationEnvironment;

        public ArangoAccessor(EnvironmentAccessor config)
        {
            ApplicationEnvironment environment = config.Environment;
            Connector = GetConfiguredConnector(environment);
            PaymentRequestConnector = GetConfiguredPaymentRequestConnector(environment);
            ApplicationEnvironment = environment;
        }

        private CollectionConnector GetConfiguredConnector(ApplicationEnvironment environment)
        {
            RemoteCredentialsStore store = new RemoteCredentialsStore();
            NetworkCredential networkCred = store.GetNetworkCredential("PaymentsArangoUser");
            string host = environment == ApplicationEnvironment.Production ? "usp-dock.conservice.com" : "usd-dock.conservice.com";
            UrlInfo info = new UrlInfo
            {
                Host = host,
                Collection = "PaymentData",
                Database = "Payment",
                Port = 443
            };

            return new CollectionConnector(networkCred, info);
        }

        private CollectionConnector GetConfiguredPaymentRequestConnector(ApplicationEnvironment environment)
        {
            RemoteCredentialsStore store = new RemoteCredentialsStore();
            NetworkCredential networkCred = store.GetNetworkCredential("PaymentsArangoUser");
            string host = environment == ApplicationEnvironment.Production ? "usp-dock.conservice.com" : "usd-dock.conservice.com";
            UrlInfo info = new UrlInfo
            {
                Host = host,
                Collection = "PaymentRequestCollection",
                Database = "Payment",
                Port = 443
            };

            return new CollectionConnector(networkCred, info);
        }
    }
}
