using CoffeeMachine.Enumerations;

namespace CoffeeMachine.Model
{
    public class CoffeeIngredient : ContainerContent
    {
        public CoffeeState State { get; internal set; }
        public CoffeeIngredient(int amount) : base(amount) {}
    }
}
