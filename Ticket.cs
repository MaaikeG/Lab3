using Lab3.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    class Ticket
    {
        private string From;
        private string To;
        internal readonly float price;
        private Tuple<DateTime, DateTime> geldigheid;
        private Class.IClass travelClass;
        private IDiscount discount;
        private float ICEtoeslag;
        private bool isReturn;

        public Guid Id { get; internal set; }

        public void calculateTicketPrice()
        {
            // Get number of tariefeenheden
            int tariefeenheden = Tariefeenheden.getTariefeenheden(From, To);

            // Compute the column in the table based on choices
            int tableColumn = travelClass.GetColumnIndex();

            // Then, on the discount
            tableColumn += discount.GetColumnIndexModifier();

            // Get price
            float price = PricingTable.getPrice(tariefeenheden, tableColumn);
            if (this.isReturn)
            {
                price *= 2;
            }
            price += ICEtoeslag;
        }

        internal void UpdateInfo(UIInfo info)
        {
            this.From = info.From;
            this.To = info.To;

            if (info.Class == UIClass.FirstClass)
            {
                this.travelClass = new Class.FirstClass();
            }
            else this.travelClass = new Class.SecondClass();

            switch (info.Discount) { 
                case UIDiscount.FortyDiscount:
                    this.discount = new FortyDiscount();
                    break;
                case UIDiscount.TwentyDiscount:
                    this.discount = new TwentyDiscount();
                    break;
                default:
                    this.discount = new NoDiscount();
                    break;
            }
            this.isReturn = info.Way == UIWay.Return;
        }
    }
}
