namespace Lab3
{
    internal class CardPayment : IPayment
    {
        private ICard cardPayment;
        
        public CardPayment(ICard _cardPayment)
        {
            this.cardPayment = _cardPayment;
        }

        public void HandlePayment(float price)
        {
            cardPayment.Connect();
            int dcid = cardPayment.BeginTransaction(price);
            cardPayment.EndTransaction(dcid);
        }
    }
}