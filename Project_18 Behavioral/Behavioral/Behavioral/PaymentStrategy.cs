namespace TemplateMethod
{
    public abstract class PaymentStrategy
    {
        public void Pay(int price)
        {
            GetMoney();
            PrintMessage(price);
        }

        protected abstract void GetMoney();
        protected abstract void PrintMessage(int price);
    }
}
