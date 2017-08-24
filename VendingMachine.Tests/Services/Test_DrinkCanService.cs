using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using VendingMachine.Data.Contracts;
using VendingMachine.Models;
using VendingMachine.Models.enums;
using VendingMachine.Services;

namespace VendingMachine.Tests.Services
{
    [TestClass]
    public class Test_DrinkCanService
    {

        [TestMethod]
        public void Test_DrinkCanService_Find()
        {
            using (var mock = AutoMock.GetLoose())
            {

                // Arrange - configure the mock
                var criteria = new DrinkCanFindCriteria();
                var dbSet = TestData.DBSetDrinkCan;

                mock.Mock<IDrinkCanRepository>().Setup(x => x.FindByCriteria(criteria)).Returns(dbSet);
                var service = mock.Create<DrinkCanService>();

                // Act
                var result = service.FindDrinkCans(criteria);

                //Asssert
                Assert.AreEqual(dbSet.Count(), result.Count());
            }

        }

        [TestMethod]
        public void Test_DrinkCanService_Add()
        {
            using (var mock = AutoMock.GetLoose())
            {
                try
                {
                    // Arrange - configure the mock
                    var recDTO = new DrinkCanDTO() { Flavour = Flavour.Apple, IsSold = false, Price = 1.50m };
                    var service = mock.Create<DrinkCanService>();

                    // Act
                    service.Add(recDTO);

                    //Assert
                    Assert.IsTrue(true);
                }
                catch
                {

                    Assert.IsTrue(false);
                }


            }

        }

    }
}
