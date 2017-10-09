
using System.Collections.Generic;

namespace Lab3
{
    class Transaction
    {
        List<Ticket> tickets = new List<Ticket>();
        private float totalPrice;

        public void AddTicket()
        {
            this.tickets.Add(new Ticket());
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
            payment.HandlePayment(this.totalPrice);
        }
    }
}
