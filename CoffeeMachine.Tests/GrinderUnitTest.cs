using Xunit;
using CoffeeMachine;
using CoffeeMachine.Enumerations;
using CoffeeMachine.Model;

namespace CoffeeMachine.Tests
{
    public class GrinderUnitTests
    {
        [Fact]
        public void GrindingCoffee_Success()
        {
            // arrange
            var grinderUnit = new GrinderUnit();
            var coffeeContainer = new Container<CoffeeIngredient>();
            coffeeContainer.LoadResource(50);
            var expectedCoffeeState = CoffeeState.GROUND;
            // act
            grinderUnit.GrindCoffee(coffeeContainer);
            var actualCoffeeState = coffeeContainer.Content.State;
            // assert
            Assert.Equal(expectedCoffeeState, actualCoffeeState);
        }
    }
}
