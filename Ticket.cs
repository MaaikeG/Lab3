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
        private Tuple<DateTime, DateTime> geldigheid;
        private Class.IClass _class;
        private IDiscount discount;
        private float ICEtoeslag;
        private bool isReturn;

        public Guid Id { get; internal set; }
        public float price { get; private set; }

        public void calculateTicketPrice()
        {
            // Get number of tariefeenheden
            int tariefeenheden = Tariefeenheden.getTariefeenheden(From, To);

            price = PricingCalculator.CalculatePrice(this.discount, this._class, tariefeenheden);

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
            this._class = TicketPropertyFactory.GetCLass(info.Class);
            this.discount = TicketPropertyFactory.GetDiscount(info.Discount);
            this.isReturn = info.Way == UIWay.Return;
        }
    }
}
