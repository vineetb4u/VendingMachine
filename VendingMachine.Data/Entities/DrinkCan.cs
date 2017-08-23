using VendingMachine.Models;
using VendingMachine.Models.enums;

namespace VendingMachine.Data.Entities
{
    public class DrinkCan
    {
        public Flavour Flavour { get; set; }
        public decimal Price { get; set; }
        public bool IsSold { get; set; }
    }
}
