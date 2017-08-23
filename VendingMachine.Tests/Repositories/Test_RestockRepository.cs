using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using VendingMachine.Data.Contracts;
using VendingMachine.Data.Entities;
using VendingMachine.Data.Repositories;
using VendingMachine.Models;
using VendingMachine.Models.enums;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace VendingMachine.Tests.Repositories
{
    [TestClass]
    public class Test_RestockRepository
    {
        //[TestMethod]
        //public void Test_RestockRepository_Restock()
        //{
        //    IDrinkCanRepository drinkRepo = new DrinkCanRepository();
        //    var can1 = new DrinkCan { DrinkCanID = 1, Flavour = Flavour.Apple, Price = 2.50m };
        //    drinkRepo.Add(can1);

        //    var can2 = new DrinkCan { DrinkCanID = 2, Flavour = Flavour.Banana, Price = 2.50m };
        //    drinkRepo.Add(can2);


        //    PaymentRepository paymentRepo = new PaymentRepository();
        //    var payment = new Payment { PaymentID = 1, Amount = 2.50m, Type = PaymentType.Cash };
        //    //Act
        //    paymentRepo.Add(payment);


        //    using (IRestockRepository repo = new RestockRepository(drinkRepo, paymentRepo))
        //    {

        //        var can3 = new DrinkCan { DrinkCanID = 5, Flavour = Flavour.Pear, Price = 6.50m };
        //        var can4 = new DrinkCan { DrinkCanID = 6, Flavour = Flavour.Orange, Price = 7.50m };
        //        List<DrinkCan> newStock = new List<DrinkCan>();
        //        newStock.Add(can3);
        //        newStock.Add(can4);


        //        //Act
        //        repo.Restock(newStock);


        //        var newDrinkCans = drinkRepo.FindByCriteria(new DrinkCanFindCriteria());
        //        Assert.AreEqual(2, newDrinkCans.Count());

        //        var criteria = new DrinkCanFindCriteria();
        //        criteria.DrinkCanID = can3.DrinkCanID;

        //        var pearDrink = drinkRepo.FindByCriteria(criteria);
        //        Assert.AreEqual(1, pearDrink.Count());
        //        Assert.AreEqual(can3, pearDrink.FirstOrDefault());
        //    }

        //}
    }
}
