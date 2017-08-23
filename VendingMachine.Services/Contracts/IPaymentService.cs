using System.Collections.Generic;
using VendingMachine.Models;


namespace VendingMachine.Services
{
    public interface IPaymentService : IBaseService<PaymentDTO>
    {
        List<PaymentDTO> FindPayments(PaymentFindCriteria criteria);
    }
}
