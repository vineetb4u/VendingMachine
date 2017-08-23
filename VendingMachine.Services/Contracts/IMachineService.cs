using System.Collections.Generic;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public interface IMachineService
    {
        void Vend(VendDTO vend);
        void Restock(List<DrinkCanDTO> stock);
    }
}
