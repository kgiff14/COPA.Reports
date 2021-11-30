using COPA.Reports.BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COPA.Reports.Controllers
{
    public class BreakdownController : Controller
    {
        private readonly IPaymentBreakdownLogic paymentBreakdownLogic;

        public BreakdownController(IPaymentBreakdownLogic paymentBreakdownLogic)
        {
            this.paymentBreakdownLogic = paymentBreakdownLogic;
        }

        [HttpGet]
        public IActionResult Index() =>
            View(paymentBreakdownLogic);

        [HttpGet]
        public IActionResult GetNewBreakdownTimespan(int start, int end) =>
            PartialView("_BreakdownTable", paymentBreakdownLogic);
    }
}
