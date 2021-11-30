using System;
using System.Collections.Generic;
using System.Text;

namespace COPA.Debug.BOL.PaymentRequestCollection
{
    /// <summary>
    /// Contains the values to GET a virtual cards.
    /// </summary>
    public class VirtualCreditCard : CreditCard
    {
        /// <summary>
        /// The ID used to retrieve a virtual card
        /// </summary>
        public string VCardID { get; set; }
        /// <summary>
        /// The CompanyID used to retrieve a virtual card
        /// </summary>
        public string VCardCompanyID { get; set; }

        /// <summary>
        /// Converts the VirtualCreditCard object into a Models.PaymentInformation object.
        /// </summary>
        /// <returns></returns>
        public new Models.PaymentInformation ConvertToPaymentInformation()
        {
            var pi = base.ConvertToPaymentInformation();

            pi.VCardID = VCardID;
            pi.VCardCompanyID = VCardCompanyID;

            return pi;
        }
    }
}
