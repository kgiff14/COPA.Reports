using System;
using System.Collections.Generic;
using System.Text;

namespace COPA.Debug.BOL.PaymentRequestCollection
{
    /// <summary>
    /// Containing information on how a bill runs through automation. 
    /// </summary>
    public class AutomationProfile
    {
        /// <summary>
        /// The name of the template (or map) to use
        /// </summary>
        public string TemplateName { get; set; }
        /// <summary>
        /// The endpoint to make the payment
        /// </summary>
        public string Endpoint { get; set; }
        /// <summary>
        /// The type of endpoint provided
        /// </summary>
        public string EndpointType { get; set; }
        /// <summary>
        /// The type of template provided
        /// </summary>
        public string TemplateType { get; set; }
        /// <summary>
        /// The payment method used by the template
        /// </summary>
        public string PaymentMethod { get; set; }
        /// <summary>
        /// Where the payment needs to be sent, example: "Automation" or "Manual"
        /// </summary>
        public string PaymentTarget { get; set; } = "automation";
    }
}
