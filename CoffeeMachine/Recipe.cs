namespace CoffeeMachine
{
    public class Recipe
    {
        public int AmountOfCoffee { get; }
        public int AmountOfWater { get; }
        public int AmountOfMilk { get; }

        public Recipe(int coffee, int water, int milk)
        {
            AmountOfCoffee = coffee;
            AmountOfWater = water;
            AmountOfMilk = milk;
        }
    }
}
