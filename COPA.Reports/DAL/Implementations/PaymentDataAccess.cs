using Conservice.DataUtilities.Sql;
using Conservice.Logging;
using COPA.Reports.BLL.Utilities;
using COPA.Reports.BOL;
using COPA.Reports.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace COPA.Reports.DAL.Implementations
{
    public class PaymentDataAccess : IPaymentAccess
    {
        private static ILogger logger = LoggerFactory.CreateCurrentClassLogger();
        private SqlConnectionFactory factory { get; set; }

        public PaymentDataAccess(SqlAccessor sqlAccessor)
        {
            factory = sqlAccessor.ConnectionFactory;
        }

        public List<PaymentBreakdown> GetPaymentBreakdowns(DateTime startDate, DateTime EndDate)
        {
            using var command = new SqlCommand("Payment.dbo.CompletedPaymentsGet");
            {
                command.CommandType = CommandType.StoredProcedure;
            }
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@StartTime", SqlDbType.DateTime) { Value = startDate }); // Yesterday at 00
            parameters.Add(new SqlParameter("@EndTime", SqlDbType.DateTime) { Value = EndDate }); // yesterday at 11:59:59:999
            List<PaymentBreakdown> payments = SqlUtility.ReadObjects(factory, "Payment.dbo.CompletedPaymentsGet", ReadPaymentBreakdown, storedProcParams: parameters.ToArray(), commandTimeout: 90);

            return payments;
        }

        #region Reader Methods

        private PaymentBreakdown ReadPaymentBreakdown(SqlDataReader reader)
        {
            SqlDataConverter conv = new SqlDataConverter(reader);
            PaymentBreakdown info = new PaymentBreakdown
            {
                PaymentID = conv.ToInt("PaymentId"),
                PaymentDate = conv.ToDateTime("PaymentRequestDate"),
                Client = conv.ToString("ClientName"),
                AmountPaid = conv.ToDecimal("TransactionAmount"),
                PaymentStatus = conv.ToString("PaymentStatusName"),
                Fee = conv.ToDecimal("Fee"),
                FailureReason = conv.ToString("AutomationExceptionMessage"),
                ConfirmationNumber = conv.ToInt("ConfirmationNumber"),
                ClientSystemBillID = conv.ToString("InvoiceID"),
                AutomationImagePath = conv.ToString("AutomationFailureControlNumber"),
                ManualImagePath = conv.ToString("ManualFailureControlNumber"),
                AmountToBePaid = conv.ToDecimal("PaymentAmount")
            };

            return info;
        }

        #endregion
    }
}
