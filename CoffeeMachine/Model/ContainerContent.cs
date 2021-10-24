namespace CoffeeMachine.Model
{
    public abstract class ContainerContent
    {
        public int Amount { get; set; }
        public ContainerContent(int amount)
        {
            Amount = amount;
        }
    }
}
