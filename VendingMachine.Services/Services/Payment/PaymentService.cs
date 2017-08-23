using System;
using System.Collections.Generic;
using VendingMachine.Common.Constants;
using VendingMachine.Data.Contracts;
using VendingMachine.Data.Entities;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public void Add(PaymentDTO recDTO)
        {
            if (recDTO == null)
            {
                throw new ArgumentNullException(string.Format(ValidationConstants.SDataNotFoundWithValue, "Payment"));
            }

            Payment rec = PaymentMapper.Map(recDTO);

            _paymentRepository.Add(rec);
        }

        public List<PaymentDTO> FindPayments(PaymentFindCriteria criteria)
        {

            if (criteria == null)
            {
                throw new ArgumentNullException("criteria");
            }

            var payments = _paymentRepository.FindByCriteria(criteria);

            List<PaymentDTO> result = new List<PaymentDTO>();
            foreach (var payment in payments)
            {
                result.Add(PaymentMapper.Map(payment));
            }

            return result;
        }

        public void Reset()
        {
            _paymentRepository.Reset();
        }
       
    }
}
