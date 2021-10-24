using Xunit;
using CoffeeMachine;
using CoffeeMachine.Enumerations;
using CoffeeMachine.Model;

namespace CoffeeMachine.Tests
{
    public class BrewingUnitTest
    {
        [Fact]
        public void BoilingWater_Success()
        {
            // arrange
            var brewingUnit = new BrewingUnit();
            var waterContainer = new Container<WaterIngredient>();
            waterContainer.LoadResource(50);
            var expectedWaterState = WaterState.HOT;
            // act
            brewingUnit.BoilWater(waterContainer);
            var actualWaterState = waterContainer.Content.State;
            // assert
            Assert.Equal(expectedWaterState, actualWaterState);
        }
        [Fact]
        public void BoilingMilk_Success()
        {
            // arrange
            var brewingUnit = new BrewingUnit();
            var milkContainer = new Container<MilkIngredient>();
            milkContainer.LoadResource(50);
            var expectedMilkState = MilkState.HOT;
            // act
            brewingUnit.BoilMilk(milkContainer);
            var actualMilkState = milkContainer.Content.State;
            // assert
            Assert.Equal(expectedMilkState, actualMilkState);
        }
    }
}
