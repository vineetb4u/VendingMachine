using VendingMachine.Models.enums;

namespace VendingMachine.Data.Entities
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public PaymentType Type { get; set; }
        public decimal Amount { get; set; }
    }
}
