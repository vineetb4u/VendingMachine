using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VendingMachine.Common.Constants;
using VendingMachine.Models;
using VendingMachine.Models.enums;
using VendingMachine.Services;


namespace VendingMachine.Api.Controllers
{
    [RoutePrefix("Machine")]
    public class MachineController : BaseApiController
    {

        private readonly IMachineService _machineService;

        public MachineController(IMachineService machineService)
        {
            _machineService = machineService;
        }

        [HttpPost]
        [Route("Vend")]
        public HttpResponseMessage Post([FromBody]VendDTO vend)
        {
            _machineService.Vend(vend);
            return Request.CreateResponse(HttpStatusCode.OK);

        }


        [HttpPost]
        [Route("Restock")]
        public HttpResponseMessage Post([FromBody]List<DrinkCanDTO> newStock)
        {

            if (newStock.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, string.Format(ValidationConstants.SRequiredProperty,"newStock"));
            }

            _machineService.Restock(newStock);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
    }
}
