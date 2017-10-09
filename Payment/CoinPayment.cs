namespace Lab3
{
    internal class CoinPayment : IPayment
    {
        private IKEAMyntAtare2000 coinMachine = new IKEAMyntAtare2000();

        public void HandlePayment(float price)
        {
            coinMachine.starta();
            coinMachine.betala((int)System.Math.Round(price * 100));
            coinMachine.stoppa();
        }
    }
}