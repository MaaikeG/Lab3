using System;

namespace Lab3
{
    internal class PaymentFactory
    {
        internal static IPayment CreatePayment(UIPayment paymentType)
        {
            switch (paymentType)
            {
                case UIPayment.Cash:
                    return new CoinPayment();
                case UIPayment.CreditCard:
                    return new CardPayment(new CreditCard());
                case UIPayment.DebitCard:
                    return new CardPayment(new DebitCard());
                default:
                    throw new ArgumentException();
            }
        }
    }
}