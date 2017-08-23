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
    public class Test_PaymentRepository
    {
        [TestMethod]
        public void Test_PaymentRepository_Add()
        {

            using (IPaymentRepository repo = new PaymentRepository())
            {
                //Arrange
                var payment = new Payment { PaymentID =1, Amount = 2.50m, Type = PaymentType.Cash };

                //Act
                repo.Add(payment);

                var criteria = new PaymentFindCriteria();
                var count = repo.FindByCriteria(criteria).Count();

                //Assert
                Assert.AreEqual(1, count);

            }

        }

        [TestMethod]
        public void Test_PaymentRepository_Find()
        {

            using (IPaymentRepository repo = new PaymentRepository())
            {
                //Arrange
                var payment1 = new Payment { PaymentID = 1, Amount = 3.50m, Type = PaymentType.Cash };
                repo.Add(payment1);

                var payment2 = new Payment { PaymentID = 1, Amount = 1.50m, Type = PaymentType.CreditCard };
                repo.Add(payment2);

                //Act
                var criteria = new PaymentFindCriteria();
                criteria.Type = PaymentType.CreditCard;

                var result = repo.FindByCriteria(criteria).FirstOrDefault();

                //Assert
                Assert.AreEqual(payment2, result);

            }

        }

        [TestMethod]
        public void Test_PaymentRepository_Delete()
        {

            using (IPaymentRepository repo = new PaymentRepository())
            {
                //Arrange
                var payment1 = new Payment { PaymentID = 1, Amount = 3.50m, Type = PaymentType.Cash };
                repo.Add(payment1);


                //Act
                var criteria = new PaymentFindCriteria();
                criteria.PaymentID = payment1.PaymentID;

                var result = repo.FindByCriteria(criteria).FirstOrDefault();
                repo.Delete(result);

                var updatedList = repo.FindByCriteria(criteria);
                
                //Assert
                Assert.AreEqual(0, updatedList.Count());

            }

        }


        [TestMethod]
        public void Test_DrinkCanRepository_Reset()
        {

            using (IPaymentRepository repo = new PaymentRepository())
            {
                //Arrange
                var payment1 = new Payment { PaymentID = 1, Amount = 3.50m, Type = PaymentType.Cash };
                repo.Add(payment1);

                var payment2 = new Payment { PaymentID = 1, Amount = 1.50m, Type = PaymentType.CreditCard };
                repo.Add(payment2);

                //Act
                repo.Reset();

                var criteria = new PaymentFindCriteria();

                var result = repo.FindByCriteria(criteria).FirstOrDefault();
                repo.Delete(result);

                var updatedList = repo.FindByCriteria(criteria);
               
                //Assert
                Assert.AreEqual(0, updatedList.Count());

            }

        }
    }
}
