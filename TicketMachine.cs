using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    class TicketMachine
    {
        private Transaction transaction;
        // we keep track of the current ticket ID. This is necessary because
        // the backend supports multiple tickets within a transaction, so it needs the ticketID
        // to know which ticket we want to edit. The frontend doesn't support multiple tickets.
        private Guid ticketID;

        internal void DoTransaction(UIInfo info)
        {
            StartTransaction();
            transaction.UpdateTicket(ticketID, info);
            transaction.Complete(info.Payment);
            Reset();
        }

        private void StartTransaction()
        {
            this.transaction = new Transaction();
            ticketID = transaction.AddTicket();
        }

        private void Reset()
        {
            this.transaction = null;
        }
    }
}
