using System;
using System.Collections.Generic;
using System.Data;
using VendingMachine.Common.Constants;
using VendingMachine.Data.Contracts;
using VendingMachine.Data.Entities;
using VendingMachine.Models;

namespace VendingMachine.Services
{

    public class DrinkCanService : IDrinkCanService
    {

        private readonly IDrinkCanRepository _drinkCanRepository;

        public DrinkCanService(IDrinkCanRepository drinkCanRepository)
        {
            _drinkCanRepository = drinkCanRepository;
        }

        public void Add(DrinkCanDTO recDTO)
        {
            if (recDTO == null)
            {
                throw new ArgumentNullException(string.Format(ValidationConstants.SDataNotFoundWithValue, "DrinkCan"));
            }

            DrinkCan rec = DrinkCanMapper.Map(recDTO);

            _drinkCanRepository.Add(rec);
        }

        public List<DrinkCanDTO> FindDrinkCans(DrinkCanFindCriteria criteria)
        {
            if (criteria == null)
            {
                throw new ArgumentNullException("criteria");
            }

            var recs = _drinkCanRepository.FindByCriteria(criteria);

            List<DrinkCanDTO> result = new List<DrinkCanDTO>();
            foreach (var rec in recs)
            {
                result.Add(DrinkCanMapper.Map(rec));
            }

            return result;
        }

        public void Reset()
        {
            _drinkCanRepository.Reset();
        }

    }
}
