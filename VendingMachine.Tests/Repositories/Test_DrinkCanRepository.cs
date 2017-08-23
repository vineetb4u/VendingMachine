using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using VendingMachine.Data.Contracts;
using VendingMachine.Data.Entities;
using VendingMachine.Data.Repositories;
using VendingMachine.Models;
using VendingMachine.Models.enums;

namespace VendingMachine.Tests.Repositories
{
    [TestClass]
    public class Test_DrinkCanRepository
    {
        [TestMethod]
        public void Test_DrinkCanRepository_Add()
        {

            using (IDrinkCanRepository repo = new DrinkCanRepository())
            {
                //Arrange
                var can = new DrinkCan { Flavour = Flavour.Apple, Price = 2.50m };

                //Act
                repo.Add(can);

                var criteria = new DrinkCanFindCriteria();
                var count = repo.FindByCriteria(criteria).Count();

                //Assert
                Assert.AreEqual(1, count);

            }

        }

        [TestMethod]
        public void Test_DrinkCanRepository_Find()
        {

            using (IDrinkCanRepository repo = new DrinkCanRepository())
            {
                //Arrange
                var can1 = new DrinkCan { Flavour = Flavour.Apple, Price = 2.50m };
                repo.Add(can1);

                var can2 = new DrinkCan { Flavour = Flavour.Banana, Price = 2.50m };
                repo.Add(can2);

                //Act
                var criteria = new DrinkCanFindCriteria();
                criteria.Flavour = Flavour.Banana;

                var result = repo.FindByCriteria(criteria).FirstOrDefault();

                //Assert
                Assert.AreEqual(can2, result);

            }

        }

        [TestMethod]
        public void Test_DrinkCanRepository_Delete()
        {

            using (IDrinkCanRepository repo = new DrinkCanRepository())
            {
                //Arrange
                var can1 = new DrinkCan { Flavour = Flavour.Apple, Price = 2.50m, IsSold = false };
                repo.Add(can1);

                //Act
                var criteria = new DrinkCanFindCriteria();
                criteria.Flavour = Flavour.Apple;


                var result = repo.FindByCriteria(criteria).FirstOrDefault();
                repo.Delete(result);

                result = repo.FindByCriteria(criteria).FirstOrDefault();
                //initCount.
                Assert.AreEqual(true, result.IsSold);

            }

        }


        [TestMethod]
        public void Test_DrinkCanRepository_Reset()
        {

            using (IDrinkCanRepository repo = new DrinkCanRepository())
            {
                //Arrange
                var can1 = new DrinkCan { Flavour = Flavour.Apple, Price = 2.50m, IsSold = false };
                repo.Add(can1);

                var can2 = new DrinkCan { Flavour = Flavour.Banana, Price = 2.50m, IsSold = false };
                repo.Add(can2);

                //Act
                repo.Reset();

                var criteria = new DrinkCanFindCriteria();
                var result = repo.FindByCriteria(criteria);

                //Assert
                Assert.AreEqual(0, result.Count());

            }

        }
    }
}
