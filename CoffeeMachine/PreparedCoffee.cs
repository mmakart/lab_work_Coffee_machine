using CoffeeMachine.Enumerations;

namespace CoffeeMachine
{
    public class PreparedCoffee
    {
        public Recipes Type { get; }
        public PreparedCoffee(Recipes type)
        {
            Type = type;
        }
    }
}
