using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    class Ticket
    {
        internal readonly float price;
        private Tuple<DateTime, DateTime> geldigheid;
        private short klasse;
        private float ICEtoeslag;

        public Guid id { get; private set; }

        public void calculateTicketPrice()
        {
            throw new NotImplementedException();
        }
    }
}
