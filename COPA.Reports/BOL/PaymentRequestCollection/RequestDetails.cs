using System;
using System.Collections.Generic;
using System.Text;

namespace COPA.Debug.BOL.PaymentRequestCollection
{
    /// <summary>
    /// Additional details from the Request
    /// </summary>
    public class RequestDetails
    {
        /// <summary>
        /// An ID used for tracking metrics for the ClientBill
        /// </summary>
        public string CorrelationID { get; set; }
        /// <summary>
        /// The ID of the ClientBill record that may have already been inserted.
        /// </summary>
        public int ClientBillID { get; set; }
        /// <summary>
        /// The source of the request
        /// </summary>
        public string RequestSource { get; set; }
        /// <summary>
        /// An operational domain to further specify Request Source, if needed
        /// </summary>
        public string OperationalDomain { get; set; }
        /// <summary>
        /// The name of the Customer
        /// </summary>
        public string Customer { get; set; }
        /// <summary>
        /// The client-defined ID of the Customer
        /// </summary>
        public int? CustomerID { get; set; }
        /// <summary>
        /// The dictionary of login values, with their keys and values which are in top->down, left->right order
        /// </summary>
        public Dictionary<string, string> LoginValues { get; set; }
    }
}
