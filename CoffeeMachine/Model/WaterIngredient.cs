using CoffeeMachine.Enumerations;

namespace CoffeeMachine.Model
{
    public class WaterIngredient : ContainerContent
    {
        public WaterState State { get; internal set; }
        public WaterIngredient(int amount) : base(amount) {}
    }
}
