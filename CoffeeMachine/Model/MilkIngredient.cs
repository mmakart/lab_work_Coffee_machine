using CoffeeMachine.Enumerations;

namespace CoffeeMachine.Model
{
    public class MilkIngredient : ContainerContent
    {
        public MilkState State { get; internal set; }
        public MilkIngredient(int amount) : base(amount) {}
    }
}
