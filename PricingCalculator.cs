using Lab3.Class;
using Lab3.Discount;

namespace Lab3
{
    public static class PricingCalculator
    {
        public static float CalculatePrice(IDiscount discount, IClass _class, int tariefeenheden)
        {
            // Compute the column in the table based on class and discount rate
            int tableColumn = _class.GetColumnIndex();
            tableColumn += discount.GetColumnIndexModifier();

            // and get the price
            return PricingTable.getPrice(tariefeenheden, tableColumn);
        }
    }
}
