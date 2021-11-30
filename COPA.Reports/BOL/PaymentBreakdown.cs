using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COPA.Reports.BOL
{
    public class PaymentBreakdown
    {
        public int PaymentID { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Client { get; set; }
        public decimal AmountPaid { get; set; }
        public string PaymentStatus { get; set; }
        public decimal Fee { get; set; }
        public string FailureReason { get; set; }
        public int ConfirmationNumber { get; set; }
        public string ClientSystemBillID { get; set; }
        public string AutomationImagePath { get; set; }
        public string ManualImagePath { get; set; }
        public decimal AmountToBePaid { get; set; }
    }
}
