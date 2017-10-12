using Lab3.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public class Ticket
    {
        public string From { get; private set; }
        public string To { get; private set; }
        public Tuple<DateTime, DateTime> Geldigheid { get; private set; }
        public Class.IClass Class { get; private set; }
        public IDiscount Discount { get; private set; }
        public float ICEtoeslag { get; private set; }
        public bool IsReturn { get; private set; }
        public Guid Id { get; internal set; }
        public float Price { get; private set; }

        public void CalculateTicketPrice()
        {
            // Get number of tariefeenheden
            int tariefeenheden = Tariefeenheden.GetTariefeenheden(From, To);

            Price = PricingCalculator.CalculatePrice(this.Discount, this.Class, tariefeenheden);

            if (this.IsReturn)
            {
                Price *= 2;
            }
            Price += ICEtoeslag;
        }

        internal void UpdateInfo(UIInfo info)
        {
            this.From = info.From;
            this.To = info.To;
            this.Class = TicketPropertyFactory.GetCLass(info.Class);
            this.Discount = TicketPropertyFactory.GetDiscount(info.Discount);
            this.IsReturn = info.Way == UIWay.Return;
            this.Geldigheid = new Tuple<DateTime, DateTime>(DateTime.Today, DateTime.Today);
            CalculateTicketPrice();
        }
    }
}
