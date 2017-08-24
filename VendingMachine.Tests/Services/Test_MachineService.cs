using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Data.Contracts;
using VendingMachine.Data.Entities;
using VendingMachine.Models;
using VendingMachine.Models.enums;
using VendingMachine.Services;

namespace VendingMachine.Tests.Services
{
    [TestClass]
    public class Test_MachineService
    {
        [TestMethod]
        public void Test_MachineService_Vend()
        {
            using (var mock = AutoMock.GetLoose())
            {
                try
                {
                    // Arrange - configure the mock
                    var paymentDTO = new PaymentDTO() { PaymentID = 1, Amount = 1.50m, Type = PaymentType.CreditCard };
                    VendDTO recDTO = new VendDTO() { payment = paymentDTO, flavour = Flavour.Apple };
                    var service = mock.Create<MachineSerivce>();

                    // Act
                    service.Vend(recDTO);

                    //Assert
                    Assert.IsTrue(true);
                }
                catch
                {

                    Assert.IsTrue(false);
                }
            }
        }


        [TestMethod]
        public void Test_MachineService_Restock()
        {
            using (var mock = AutoMock.GetLoose())
            {
                try
                {
                    // Arrange - configure the mock
                    var service = mock.Create<MachineSerivce>();
                    var newStock  = new List<DrinkCanDTO>();
                    TestData.DBSetDrinkCan.ForEach((d) => newStock.Add(DrinkCanMapper.Map(d)));
                    // Act
                    service.Restock(newStock);

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
