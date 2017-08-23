using System;
using System.Collections.Generic;
using VendingMachine.Data.Entities;
using VendingMachine.Models;

namespace VendingMachine.Data.Contracts
{
    public interface IDrinkCanRepository : IRepository<DrinkCan>, IDisposable
    {
        IEnumerable<DrinkCan> FindByCriteria(DrinkCanFindCriteria criteria);
    }
}
