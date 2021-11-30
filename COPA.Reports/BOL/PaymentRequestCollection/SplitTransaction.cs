using System;
using System.Collections.Generic;
using System.Text;

namespace COPA.Debug.BOL.PaymentRequestCollection
{
    /// <summary>
    /// Represents the amount of a single split payment
    /// </summary>
    public class SplitTransaction
    {
        /// <summary>
        /// The amount to pay
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// The expected fee
        /// </summary>
        public decimal Fee { get; set; }
        /// <summary>
        /// The type of payment information to use which corresponds to which payment information list to pull from in the PaymentInformation object
        /// </summary>
        public string PaymentInformationType { get; set; }
        /// <summary>
        /// The index of the payment information to pull
        /// </summary>
        public int PaymentInformationIndex { get; set; }
    }
}
