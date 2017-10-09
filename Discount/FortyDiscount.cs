using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3.Discount
{
    public class FortyDiscount : IDiscount
    {
        public string GetDiscountName()
        {
            return "40% korting";
        }

        public int GetColumnIndexModifier()
        {
            return 2;
        }
    }
}
