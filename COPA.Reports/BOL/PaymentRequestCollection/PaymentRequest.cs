using Conservice.Payment.DataAccess.Enums;
using COPA.Models;
using System;
using System.Collections.Generic;

namespace COPA.Debug.BOL.PaymentRequestCollection
{
    /// <summary>
    /// Object represenation of the request recieved from the Packager Controller
    /// </summary>
    public class PaymentRequest
    {
        /// <summary>
        /// Represents the work object for the automation process
        /// </summary>
        public Payment MasterPayment { get; set; }
        /// <summary>
        /// Represents the amount of a single split payment
        /// </summary>
        public List<SplitTransaction> PaymentAmounts { get; set; }
        /// <summary>
        /// Lists of different types of PaymentInformation
        /// </summary>
        public PaymentInfo PaymentInformation { get; set; }
        /// <summary>
        /// Name of the automation template designated to run
        /// </summary>
        public string TemplateName { get; set; }
        /// <summary>
        /// Settings to determine some behavior in the Packager
        /// </summary>
        public PackageDirective PackagerDirective { get; set; }
    }
}
