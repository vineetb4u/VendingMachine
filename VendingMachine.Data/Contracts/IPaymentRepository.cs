using System;
using System.Collections.Generic;
using VendingMachine.Data.Entities;
using VendingMachine.Models;

namespace VendingMachine.Data.Contracts
{
    public interface IPaymentRepository : IRepository<Payment>, IDisposable
    {
        IEnumerable<Payment> FindByCriteria(PaymentFindCriteria criteria);
    }
}
