using System.ComponentModel.DataAnnotations;
using VendingMachine.Models.enums;

namespace VendingMachine.Models
{
    public class VendDTO
    {
        [Required]
        public PaymentDTO payment { get; set; }

        [Required]
        [Range(1, 10)]
        public Flavour flavour { get; set; }
    }
}
