using VendingMachine.Models.enums;

namespace VendingMachine.Models
{
    public class DrinkCanFindCriteria
    {

        public Flavour? Flavour { get; set; }
        public bool? IsSold { get; set; }
    }
}
