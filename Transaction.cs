using System;
using System.Collections.Generic;

namespace Lab3
{
    class Transaction
    {
        public List<Ticket> tickets { get; set; } = new List<Ticket>();
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

        public void CalculatePrice(UIPayment paymentType)
        {
            this.totalPrice = 0;
            foreach (var ticket in tickets)
            {
                ticket.CalculateTicketPrice();
                this.totalPrice += ticket.Price;
            }
            // Add 50 cent if paying with credit card
            if (paymentType == UIPayment.CreditCard)
            {
                this.totalPrice += 0.50f;
            }
        }
        
        public void Complete(UIPayment paymentType)
        {
            IPayment payment = CreatePayment(paymentType);
            payment.HandlePayment(this.totalPrice);
        }

        internal void UpdateTicket(Guid ticketID, UIInfo info)
        {
            Ticket ticket = this.tickets.Find(x => x.Id == ticketID);
            ticket.UpdateInfo(info);
            this.CalculatePrice(info.Payment);
        }

        private IPayment CreatePayment(UIPayment paymentType)
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
