using System.Collections.Generic;
using CoffeeMachine;
using CoffeeMachine.Model;
using CoffeeMachine.Enumerations;
using System;

namespace CoffeeMachine
{
    public class CoffeeMachine
    {
        public event EventHandler OnLoad;
        public event EventHandler OnBrew;

        private Container<CoffeeIngredient> CoffeeContainer { get; }
        private Container<WaterIngredient> WaterContainer { get; }
        private Container<MilkIngredient> MilkContainer { get; }
        private GrinderUnit Grinder { get; }
        private BrewingUnit Brewer { get; }
        private const int DEFAULT_COFFEE_CONTAINER_CAPACITY = 500;
        private const int DEFAULT_WATER_CONTAINER_CAPACITY = 3000;
        private const int DEFAULT_MILK_CONTAINER_CAPACITY = 1000;
        private readonly Dictionary<Recipes, Recipe> recipes = new Dictionary<Recipes, Recipe>() {
            { Recipes.ESPRESSO, new Recipe(1, 2, 3) },
            { Recipes.FILTERED, new Recipe(11, 22, 33) },
            { Recipes.CAPPUCINO, new Recipe(111, 222, 333) }
        };
        private IOutputProvider OutputProvider { get; }
        public void LoadCoffee(int amount)
        {
            CoffeeContainer.LoadResource(amount);
        }
        public void LoadWater(int amount)
        {
            WaterContainer.LoadResource(amount);
        }
        public void LoadMilk(int amount)
        {
            MilkContainer.LoadResource(amount);
        }
        public int CoffeeAmount
        { 
            get
            {
                return CoffeeContainer.Amount;
            }
        }
        public int WaterAmount
        {
            get
            {
                return WaterContainer.Amount;
            }
        }
        public int MilkAmount
        {
            get
            {
                return MilkContainer.Amount;
            }
        }
        public PreparedCoffee Brew(Recipes recipesEnum)
        {
            Recipe recipe = recipes[recipesEnum];
            var coffeeAmount = recipe.AmountOfCoffee;
            var waterAmount = recipe.AmountOfWater;
            var milkAmount = recipe.AmountOfMilk;

            OutputProvider.SendMessage("Hello. It's a coffee machine.");

            Grinder.GrindCoffee(CoffeeContainer);
            Brewer.BoilWater(WaterContainer);
            Brewer.BoilMilk(MilkContainer);

            CoffeeContainer.GetResource(coffeeAmount);
            WaterContainer.GetResource(waterAmount);
            MilkContainer.GetResource(milkAmount);

            OnBrew?.Invoke(this, EventArgs.Empty);

            return new PreparedCoffee(recipesEnum);
        }
        public CoffeeMachine(int coffeeCapacity, int waterCapacity, int milkCapacity, IOutputProvider outputProvider)
        {
            CoffeeContainer = new Container<CoffeeIngredient>(coffeeCapacity);
            WaterContainer = new Container<WaterIngredient>(waterCapacity);
            MilkContainer = new Container<MilkIngredient>(milkCapacity);

            Grinder = new GrinderUnit();
            Brewer = new BrewingUnit();

            OutputProvider = outputProvider;
        }

        public CoffeeMachine(IOutputProvider outputProvider) : this(
                DEFAULT_COFFEE_CONTAINER_CAPACITY,
                DEFAULT_WATER_CONTAINER_CAPACITY,
                DEFAULT_MILK_CONTAINER_CAPACITY,
                outputProvider) {}
    }

}
