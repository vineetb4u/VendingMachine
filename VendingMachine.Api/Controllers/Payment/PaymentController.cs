using System.Collections.Generic;
using System.Web.Http;
using VendingMachine.Api.Common.Validation;
using VendingMachine.Models;
using VendingMachine.Services;

namespace VendingMachine.Api.Controllers
{
    [RoutePrefix("Payments/Payment")]
    public class PaymentController : BaseApiController
    {
        private readonly IPaymentService  _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }


        [HttpGet]
        [Route("")]
        [AllowNullArgument]
        public List<PaymentDTO> Get([FromUri]PaymentFindCriteria filter)
        {
            if (filter == null)
            {
                // allow null criteria and take defaults
                filter = new PaymentFindCriteria();
            }

            return _paymentService.FindPayments(filter);
        }

    }
}
