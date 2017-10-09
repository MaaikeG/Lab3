using Lab3.Class;
using Lab3.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    public static class TicketPropertyFactory
    {
        public static IDiscount GetDiscount(UIDiscount discount)
        {
            switch (discount)
            {
                case UIDiscount.FortyDiscount:
                    return new FortyDiscount();
                    break;
                case UIDiscount.TwentyDiscount:
                    return new TwentyDiscount();
                    break;
                default:
                    return new NoDiscount();
                    break;
            }
        }
        public static IClass GetCLass (UIClass _class)
        {
            if (_class == UIClass.FirstClass)
            {
                return new FirstClass();
            }
            else return new SecondClass();
        }
    }
}
