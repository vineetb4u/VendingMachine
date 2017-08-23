using System;
using VendingMachine.Data.Entities;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public static class DrinkCanMapper
    {
        public static DrinkCanDTO Map(DrinkCan source, DrinkCanDTO target = null)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (target == null)
            {
                target = new DrinkCanDTO();
            }

            target.Flavour = source.Flavour;
            target.Price = source.Price;
            target.IsSold = source.IsSold;

            return target;
        }


        public static DrinkCan Map(DrinkCanDTO source, DrinkCan target = null)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (target == null)
            {
                target = new DrinkCan();
            }

            target.Flavour = source.Flavour;
            target.Price = source.Price;
            target.IsSold = source.IsSold;

            return target;
        }

    }
}
