using CoffeeMachine.Model;
using CoffeeMachine.Enumerations;

namespace CoffeeMachine.Model
{
    public class BrewingUnit
    {
        public void BoilWater(Container<WaterIngredient> waterContainer)
        {
            ((WaterIngredient) waterContainer.Content).State = WaterState.HOT;
        }
        public void BoilMilk(Container<MilkIngredient> milkContainer)
        {
            ((MilkIngredient) milkContainer.Content).State = MilkState.HOT;
        }
    }
}
