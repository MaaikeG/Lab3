using System;
using System.Collections.Generic;

namespace Lab3
{
    class Transaction
    {
        List<Ticket> tickets = new List<Ticket>();
        private float totalPrice;

        public Guid AddTicket()
        {
            var ticket = new Ticket();
            this.tickets.Add(ticket);
            return ticket.Id;
        }

        public void RemoveTicket(Ticket ticket)
        {
            this.tickets.Remove(ticket);
        }

        public void CalculatePrice()
        {
            foreach (var ticket in tickets)
            {
                ticket.calculateTicketPrice();
                this.totalPrice += ticket.price;
            }
        }
        
        public void DoPayment(UIPayment paymentType)
        {

            IPayment payment = PaymentFactory.CreatePayment(paymentType);
            // Add 50 cent if paying with credit card
            if (info.Payment == UIPayment.CreditCard)
            {
                price += 0.50f;
            }

            payment.HandlePayment(this.totalPrice);
        }
    }
}
