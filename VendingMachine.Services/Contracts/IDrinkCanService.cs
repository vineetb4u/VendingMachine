using System.Collections.Generic;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public interface IDrinkCanService : IBaseService<DrinkCanDTO>
    {
        List<DrinkCanDTO> FindDrinkCans(DrinkCanFindCriteria criteria);
    }
}
