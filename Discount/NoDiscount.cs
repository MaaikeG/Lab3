using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3.Discount
{
    public class NoDiscount : IDiscount
    {
        public string GetDiscountName()
        {
            return "Geen korting";
        }

        public int GetColumnIndexModifier()
        {
            return 0;
        }
    }
}
