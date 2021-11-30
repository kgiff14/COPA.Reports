using System;
using System.Collections.Generic;
using System.Text;

namespace COPA.Debug.BOL.PaymentRequestCollection
{
    /// <summary>
    /// Settings to determine some behavior in the Packager
    /// </summary>
    public class PackageDirective
    {
        /// <summary>
        /// The type of virtual card behavior for the request.
        /// </summary>
        public int VirtualCardBehaviorType { get; set; }
        /// <summary>
        /// The PaymentStatus value to force the Payment to report.
        /// </summary>
        public int? SimulatedPaymentStatusId { get; set; }
        /// <summary>
        /// Setting to apply the SimulatedPaymentStatusId partially.
        /// </summary>
        public bool ApplyPartially { get; set; }
    }
}
