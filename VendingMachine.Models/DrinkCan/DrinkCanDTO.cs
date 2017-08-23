using VendingMachine.Models.enums;

namespace VendingMachine.Models
{
    public class DrinkCanDTO
    {
        public DrinkCanDTO()
        {
            IsSold = false;
        }

        public Flavour Flavour { get; set; }
        public decimal Price { get; set; }
        public bool IsSold { get; set; }
    }
}
