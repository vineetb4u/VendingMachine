using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using VendingMachine.Api.Common.Validation;
using VendingMachine.Common.Constants;
using VendingMachine.Models;
using VendingMachine.Models.enums;
using VendingMachine.Services;

namespace VendingMachine.Api.Controllers
{
    [RoutePrefix("DrinkCans/DrinkCan")]
    public class DrinkCanController : BaseApiController
    {
        private readonly IDrinkCanService _drinkCanService;

        public DrinkCanController(IDrinkCanService drinkCanService) 
        {
            _drinkCanService = drinkCanService;
        }


        [HttpGet]
        [Route("")]
        [AllowNullArgument]
        public List<DrinkCanDTO> Get([FromUri]DrinkCanFindCriteria filter)
        {
            if (filter == null)
            {
                // allow null criteria and take defaults
                filter = new DrinkCanFindCriteria();
            }

            return _drinkCanService.FindDrinkCans(filter);
        }
        
    }
}
