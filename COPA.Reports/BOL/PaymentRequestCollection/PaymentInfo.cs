using System;
using System.Collections.Generic;
using System.Text;

namespace COPA.Debug.BOL.PaymentRequestCollection
{
    /// <summary>
    /// Lists of different types of PaymentInformation
    /// </summary>
    public class PaymentInfo
    {
        /// <summary>
        /// The list of provided virtual cards
        /// </summary>
        public List<VirtualCreditCard> VirtualCards { get; set; }
        /// <summary>
        /// The list of provided credit cards
        /// </summary>
        public List<CreditCard> CreditCards { get; set; }
    }
}
