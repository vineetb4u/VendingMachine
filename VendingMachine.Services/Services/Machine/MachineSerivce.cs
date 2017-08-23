using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Data.Contracts;
using VendingMachine.Data.Entities;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public class MachineSerivce : IMachineService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IDrinkCanRepository _drinkCanRepository;

        public MachineSerivce(IPaymentRepository paymentRepository, IDrinkCanRepository drinkCanRepository)
        {
            _paymentRepository = paymentRepository;
            _drinkCanRepository = drinkCanRepository;
        }

        public void Restock(List<DrinkCanDTO> stock)
        {
            if (stock == null)
            {
                throw new ArgumentNullException("stock");
            }

            _drinkCanRepository.Reset();
            _paymentRepository.Reset();

            DrinkCan rec;

            foreach (var drinkCan in stock)
            {
                rec = DrinkCanMapper.Map(drinkCan);
                _drinkCanRepository.Add(rec);
            }
        }

        public void Vend(VendDTO vend)
        {

            if (vend == null)
            {
                throw new ArgumentNullException("vend");
            }

            if (vend.payment == null)
            {
                throw new ArgumentNullException("payment");
            }

            if (vend.flavour == 0)
            {
                throw new ArgumentException("flavour");
            }

            //if we have db then we should perfrm all actions in this function under transaction
            Payment payment = PaymentMapper.Map(vend.payment);
            _paymentRepository.Add(payment);

            var criteria = new DrinkCanFindCriteria();
            criteria.Flavour = vend.flavour;

            DrinkCan can = _drinkCanRepository.FindByCriteria(criteria).FirstOrDefault();
            _drinkCanRepository.Delete(can);
        }
    }
}
