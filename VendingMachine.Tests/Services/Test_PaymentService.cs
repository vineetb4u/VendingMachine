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
    public class Test_PaymentService
    {
        [TestMethod]
        public void Test_PaymentService_Find()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange - configure the mock
                var criteria = new PaymentFindCriteria();
                var dbSet = TestData.DBSetPayment;

                mock.Mock<IPaymentRepository>().Setup(x => x.FindByCriteria(criteria)).Returns(dbSet);
                var service = mock.Create<PaymentService>();

                // Act
                var result = service.FindPayments(criteria);

                //Asssert
                Assert.AreEqual(dbSet.Count(), result.Count());
            }
        }

        [TestMethod]
        public void Test_PaymentService_Add()
        {

            using (var mock = AutoMock.GetLoose())
            {
                try
                {
                    // Arrange - configure the mock
                    var recDTO = new PaymentDTO() {PaymentID = 1, Amount = 1.50m, Type = PaymentType.CreditCard };
                    var service = mock.Create<PaymentService>();

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
