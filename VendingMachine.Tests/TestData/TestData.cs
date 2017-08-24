using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Data.Entities;
using VendingMachine.Models.enums;

namespace VendingMachine.Tests
{
    public static class TestData
    {
        public static List<DrinkCan> DBSetDrinkCan;
        public static List<Payment> DBSetPayment;

        static TestData()
        {
            DBSetDrinkCan = new List<DrinkCan>();

            DBSetDrinkCan.Add(new DrinkCan()
            {
                Flavour = Flavour.Pineapple,
                Price = 2.50m,
                IsSold = false
            });


            DBSetDrinkCan.Add(new DrinkCan()
            {
                Flavour = Flavour.Pineapple,
                Price = 2.50m,
                IsSold = false
            });


            DBSetDrinkCan.Add(new DrinkCan()
            {
                Flavour = Flavour.Pineapple,
                Price = 2.50m,
                IsSold = false
            });


            DBSetDrinkCan.Add(new DrinkCan()
            {
                Flavour = Flavour.Apple,
                Price = 1.50m,
                IsSold = false
            });

            DBSetDrinkCan.Add(new DrinkCan()
            {
                Flavour = Flavour.Apple,
                Price = 1.50m,
                IsSold = false
            });


            DBSetPayment = new List<Payment>();

            DBSetPayment.Add(new Payment()
            {
                PaymentID = 1,
                Amount = 1.50m,
                Type = PaymentType.CreditCard
            });


            DBSetPayment.Add(new Payment()
            {
                PaymentID = 1,
                Amount = 1.50m,
                Type = PaymentType.CreditCard
            });


            DBSetPayment.Add(new Payment()
            {
                PaymentID = 0,
                Amount = 2.50m,
                Type = PaymentType.Cash
            });


            DBSetPayment.Add(new Payment()
            {
                PaymentID = 0,
                Amount = 2.50m,
                Type = PaymentType.Cash
            });

            DBSetPayment.Add(new Payment()
            {
                PaymentID = 0,
                Amount = 0.50m,
                Type = PaymentType.Cash
            });


            DBSetPayment.Add(new Payment()
            {
                PaymentID = 0,
                Amount = 0.50m,
                Type = PaymentType.Cash
            });

        }
    }
}
