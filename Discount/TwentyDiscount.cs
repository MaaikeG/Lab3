using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3.Discount
{
    public class TwentyDiscount : IDiscount
    {
        public string GetDiscountName()
        {
            return "20% korting";
        }

        public int GetColumnIndexModifier()
        {
            return 1;
        }
    }
}
