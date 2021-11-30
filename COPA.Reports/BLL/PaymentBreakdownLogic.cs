using Conservice.Logging;
using COPA.Reports.BOL;
using COPA.Reports.DAL.Interfaces;
using COPA.Reports.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COPA.Reports.BLL
{
    public class PaymentBreakdownLogic : IPaymentBreakdownLogic
    {
        private static ILogger logger = LoggerFactory.CreateCurrentClassLogger();
        private readonly IPaymentAccess paymentAccess;
        private readonly IArangoAccess arangoAccess;
        private readonly IConfiguration configuration;

        public PaymentBreakdownLogic(IPaymentAccess paymentAccess, IArangoAccess arangoAccess, IConfiguration configuration)
        {
            this.paymentAccess = paymentAccess;
            this.arangoAccess = arangoAccess;
            this.configuration = configuration;
        }

        public List<COPAPaymentBreakdown> GetCOPAPaymentBreakdowns()
        {
            try
            {
                List<PaymentBreakdown> payments = paymentAccess.GetPaymentBreakdowns(DateTime.Now.AddDays(-1), DateTime.Now).OrderBy(x => x.PaymentID).ToList();
                List<int> paymentIds = payments.Select(x => x.PaymentID).ToList();
                List<ArangoPaymentData> arangoPayments = arangoAccess.GetPaymentMetadata(paymentIds);
                List<COPAPaymentBreakdown> paymentBreakdowns = GenerateBreakdownReport(payments, arangoPayments);

                return paymentBreakdowns;
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, null, "Payment Report Generator encountered an error while compiling the results.", null, e);
                return null;
            }
        }

        private List<COPAPaymentBreakdown> GenerateBreakdownReport(List<PaymentBreakdown> payments, List<ArangoPaymentData> arangoPayments)
        {
            List<COPAPaymentBreakdown> COPAPayments = new List<COPAPaymentBreakdown>();

            Dictionary<int, ArangoPaymentData> paymentDictionary = ConvertToDictionary(arangoPayments);

            foreach (var payment in payments)
            {
                if (paymentDictionary.TryGetValue(payment.PaymentID, out ArangoPaymentData data))
                {
                    COPAPaymentBreakdown breakdown = ConvertToCOPABreakdown(payment, data);
                    COPAPayments.Add(breakdown);
                }
                else
                {
                    logger.Log(LogLevel.Error, $@"Payment in report was not found in payment metadata with PaymentID: {payment.PaymentID}");
                }
            }

            return COPAPayments;
        }

        private COPAPaymentBreakdown ConvertToCOPABreakdown(PaymentBreakdown payment, ArangoPaymentData arangoPaymentData)
        {
            if(payment is null  || arangoPaymentData is null)
            {
                return null;
            }

            COPAPaymentBreakdown breakdown = new COPAPaymentBreakdown()
            {
                AccountNumber = arangoPaymentData.Website.AccountNumber,
                PaymentID = arangoPaymentData.PaymentID,
                PaymentDate = payment.PaymentDate,
                Client = payment.Client,
                AmountPaid = payment.AmountPaid,
                PaymentStatus = payment.PaymentStatus,
                Fee = payment.Fee,
                FailureReason = payment.FailureReason,
                ConfirmationNumber = payment.ConfirmationNumber,
                ClientSystemBillID = payment.ClientSystemBillID,
                AutomationImagePath = payment.AutomationImagePath,
                ManualImagePath = payment.ManualImagePath,
                AmountToBePaid = payment.AmountToBePaid,
                ProviderName = arangoPaymentData.Website.ProviderName,
                InvoiceNumber = arangoPaymentData.InvoiceNumber
            };

            return breakdown;
        }

        private Dictionary<int, ArangoPaymentData> ConvertToDictionary(List<ArangoPaymentData> arangoData)
        {
            Dictionary<int, ArangoPaymentData> dictionary = new Dictionary<int, ArangoPaymentData>();

            foreach (var data in arangoData)
            {
                if (dictionary.TryGetValue(data.PaymentID, out ArangoPaymentData payment))
                {
                    logger.Log(LogLevel.Error, $@"Duplicate record found in PaymentMetadata for PaymentID {data.PaymentID}");
                    continue;
                }
                else
                {
                    dictionary.Add(data.PaymentID, data);
                }
            }

            return dictionary;
        }
    }
}
