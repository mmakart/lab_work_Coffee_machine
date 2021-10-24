using CoffeeMachine.Model;
using CoffeeMachine.Enumerations;

namespace CoffeeMachine.Model
{
    public class GrinderUnit
    {
        public void GrindCoffee(Container<CoffeeIngredient> coffeeContainer)
        {
            ((CoffeeIngredient) coffeeContainer.Content).State = CoffeeState.GROUND;
        }
    }
}
