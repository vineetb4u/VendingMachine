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
    public class DrinkCanRepository : IDrinkCanRepository, IDisposable
    {
        private ConcurrentBag<DrinkCan> _inMemoryDb;
        private static DrinkCanRepository _instance;
        private static readonly object lockObj = new object();

        public DrinkCanRepository()
        {
            _inMemoryDb = new ConcurrentBag<DrinkCan>();
        }

        public static DrinkCanRepository Database
        {
            get
            {
                lock (lockObj)
                {
                    if (_instance == null)
                    {
                        _instance = new DrinkCanRepository();
                    }
                }

                return _instance;
            }
        }

        private IQueryable<DrinkCan> Query()
        {
            return _inMemoryDb.AsQueryable();
        }

        public void Add(DrinkCan can)
        {
            _inMemoryDb.Add(can);
        }

        public void Update(DrinkCan can)
        {

        }

        public void Delete(DrinkCan can)
        {
            var rec = Query().Where(c => c.Flavour == can.Flavour && c.IsSold == false).FirstOrDefault();
            rec.IsSold = true;
        }

        public IEnumerable<DrinkCan> FindBy(Expression<Func<DrinkCan, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DrinkCan> FindByCriteria(DrinkCanFindCriteria criteria)
        {
            var query = Query();

            if (criteria.Flavour.HasValue)
            {
                query = query.Where(c => c.Flavour == criteria.Flavour.Value);
            }


            if (criteria.IsSold.HasValue)
            {
                query = query.Where(c => c.IsSold == criteria.IsSold.Value);
            }
                
            return query.ToList();
        }

        public void Reset()
        {
            DrinkCan can;
            while (!_inMemoryDb.IsEmpty)
            {
                _inMemoryDb.TryTake(out can);
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
