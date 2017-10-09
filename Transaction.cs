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
            this.totalPrice = 0;
            foreach (var ticket in tickets)
            {
                ticket.calculateTicketPrice();
                this.totalPrice += ticket.price;
            }
        }
        
        public void Complete(UIPayment paymentType)
        {
            IPayment payment = PaymentFactory.CreatePayment(paymentType);
            // Add 50 cent if paying with credit card
            if (paymentType == UIPayment.CreditCard)
            {
                this.totalPrice += 0.50f;
            }

            payment.HandlePayment(this.totalPrice);
        }

        internal void UpdateTicket(Guid ticketID, UIInfo info)
        {
            Ticket ticket = this.tickets.Find(x => x.Id == ticketID);
            ticket.UpdateInfo(info);
        }
    }
}
