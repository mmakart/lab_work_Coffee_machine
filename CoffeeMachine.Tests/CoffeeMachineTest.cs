using System;
using Xunit;
using Moq;
using CoffeeMachine.Enumerations;

namespace CoffeeMachine.Tests
{
    public class CoffeeMachineTest
    {
        [Fact]
        public void OutputsMessage_WhenStartsBrewing()
        {
            // Arrange.
            var outputProviderMock = new Mock<IOutputProvider>();
            var coffeeMachine = new CoffeeMachine(outputProviderMock.Object);
            coffeeMachine.LoadCoffee(500);
            coffeeMachine.LoadWater(500);
            coffeeMachine.LoadMilk(500);

            // Act.
            coffeeMachine.Brew(Recipes.CAPPUCINO);

            // Assert.
            outputProviderMock.Verify(o => o.SendMessage(It.IsAny<string>()), Times.Once);
        }
        [Theory]
        [InlineData(Recipes.CAPPUCINO)]
        [InlineData(Recipes.ESPRESSO)]
        [InlineData(Recipes.FILTERED)]
        public void BrewsRequestedCoffeeType(Recipes expectedCoffeeType)
        {
            // arrange
            var outputProviderMock = new Mock<IOutputProvider>();
            var coffeeMachine = new CoffeeMachine(1000, 1000, 1000, outputProviderMock.Object);
            coffeeMachine.LoadCoffee(1000);
            coffeeMachine.LoadWater(1000);
            coffeeMachine.LoadMilk(1000);
            // act
            var coffee = coffeeMachine.Brew(expectedCoffeeType);
            // assert
            Assert.Equal(expectedCoffeeType, coffee.Type);
        }
        [Fact]
        public void LoadedResourcesAvailable()
        {
            // arrange
            var mockOutputProvider = new Mock<IOutputProvider>();
            var coffeeMachine = new CoffeeMachine(mockOutputProvider.Object);
            // act
            coffeeMachine.LoadCoffee(500);
            coffeeMachine.LoadWater(500);
            coffeeMachine.LoadMilk(500);
            // assert
            bool success = coffeeMachine.CoffeeAmount == 500
                && coffeeMachine.WaterAmount == 500
                && coffeeMachine.MilkAmount == 500;
            Assert.True(success);
        }
        [Fact]
        public void BrewWithNotEnoughResources_ThrowsException()
        {
            // arrange
            var mockOutputProvider = new Mock<IOutputProvider>();
            var coffeeMachine = new CoffeeMachine(mockOutputProvider.Object);
            // act, assert
            Assert.ThrowsAny<Exception>(() => coffeeMachine.Brew(Recipes.FILTERED));
        }
    }
}
