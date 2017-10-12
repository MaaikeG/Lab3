using System;
using System.Windows.Forms;
using System.Linq;
using System.Text;

namespace Lab3
{
    public static class Printer
    {
        public static void PrintTicket(Ticket ticket)
        {
            string ticketText = "";
            if (ticket.IsReturn)
                ticketText += "DAGRETOUR \r\n";
            else ticketText += "ENKELTJE \r\n";
            ticketText += string.Format("Van {0} naar {1}\r\n" +
                "Klasse: {2} \r\n" +
                "Korting: {3} \r\n" + 
                "Geldig van {4} tot en met {5} \r\n"
                , ticket.From
                , ticket.To
                , ticket.Class.GetClassName()
                , ticket.Discount.GetDiscountName()
                , ticket.Geldigheid.Item1.ToShortDateString()
                , ticket.Geldigheid.Item2.ToShortDateString());
            if (ticket.ICEtoeslag > 0)
                ticketText += string.Format("ICE toeslag: €{0} \r\n", ticket.ICEtoeslag);
            ticketText += string.Format("\r\nPRIJS: €{0}", ticket.Price); 
            MessageBox.Show(ticketText);
        }
    }
}
