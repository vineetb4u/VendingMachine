using VendingMachine.Models.enums;
namespace VendingMachine.Models
{
    public class PaymentDTO
    {
        public int PaymentID { get; set; }
        public PaymentType Type { get; set; }
        public decimal Amount { get; set; }

    }
}
