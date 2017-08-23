using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using VendingMachine.Data.Contracts;
using VendingMachine.Data.Entities;
using VendingMachine.Models;

namespace VendingMachine.Data.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private ConcurrentBag<Payment> _inMemoryDb;
        private static PaymentRepository _instance;
        private static readonly object lockObj = new object();

        public PaymentRepository()
        {
            _inMemoryDb = new ConcurrentBag<Payment>();
        }

        public static PaymentRepository Database
        {
            get
            {
                lock (lockObj)
                {
                    if (_instance == null)
                    {
                        _instance = new PaymentRepository();
                    }
                }

                return _instance;
            }
        }

        private IQueryable<Payment> Query()
        {
            return _inMemoryDb.AsQueryable();
        }

        public void Add(Payment pay)
        {
            _inMemoryDb.Add(pay);
        }

        public void Update(Payment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Payment pay)
        {
            _inMemoryDb.TryTake(out pay);
        }

        public IEnumerable<Payment> FindByCriteria(PaymentFindCriteria criteria)
        {
            var query = Query();

            if (criteria.PaymentID.HasValue)
                query = query.Where(c => c.PaymentID == criteria.PaymentID);


            if (criteria.Type.HasValue)
                query = query.Where(c => c.Type == criteria.Type.Value);

            return query.ToList();
        }

        public IEnumerable<Payment> FindBy(Expression<Func<Payment, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            Payment pay;
            while (!_inMemoryDb.IsEmpty)
            {
                _inMemoryDb.TryTake(out pay);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
        }
    }
}
