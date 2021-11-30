using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COPA.Reports.BOL
{
    public class ArangoPaymentData
    {
        /// <summary>
        /// The unique identifier for the payment.
        /// </summary>
        public int PaymentID { get; set; }
        /// <summary>
        /// Container for the website information about the payment.
        /// </summary>
        public Website Website { get; set; }
        /// <summary>
        /// The provider's invoice number for the invoice/bill.
        /// </summary>
        public string InvoiceNumber { get; set; }
        /// <summary>
        /// Container for the payment information about the payment.
        /// </summary>
        public PaymentInformation PaymentInformation { get; set; }
    }
    /// <summary>
    /// Container class for storing the website data about a payment.
    /// </summary>
    public class Website
    {
        /// <summary>
        /// The user-friendly name for the utility provider the payment is for.
        /// </summary>
        public string ProviderName { get; set; }
        /// <summary>
        /// The account number for the payment's invoice/bill.
        /// </summary>
        public string AccountNumber { get; set; }
    }
    /// <summary>
    /// Container class for storing the payment information we store about a payment.
    /// </summary>
    public class PaymentInformation
    {
        /// <summary>
        /// The first name we will add as the payer info.  Practically speaking, this is the customer name.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The last name we will add as the payer info.  Practically speaking, this is the customer name.
        /// </summary>
        public string LastName { get; set; }
    }
}
