using System;
using VendingMachine.Data.Entities;
using VendingMachine.Models;

namespace VendingMachine.Services
{
    public static class PaymentMapper
    {

        public static PaymentDTO Map(Payment source, PaymentDTO target = null)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (target == null)
            {
                target = new PaymentDTO();
            }

            target.PaymentID = source.PaymentID;
            target.Type = source.Type;
            target.Amount = source.Amount;

            return target;
        }


        public static Payment Map(PaymentDTO source, Payment target = null)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (target == null)
            {
                target = new Payment();
            }

            target.PaymentID = source.PaymentID;
            target.Type = source.Type;
            target.Amount = source.Amount;

            return target;
        }

    }
}
