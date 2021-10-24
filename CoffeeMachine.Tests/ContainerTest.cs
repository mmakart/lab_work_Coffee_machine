using System;
using Xunit;
using CoffeeMachine;
using CoffeeMachine.Model;
using CoffeeMachine.Enumerations;

namespace CoffeeMachine.Tests
{
    public class ContainerTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(3000)]
        public void ContainerCapacitySet_Success(int capacity)
        {
            // arrange
            var container = new Container<CoffeeIngredient>(capacity);
            var expectedCapacity = capacity;
            // act
            var actualCapacity = container.Capacity;
            // assert
            Assert.Equal(expectedCapacity, actualCapacity);
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(3001)]
        public void ContainerInvalidCapacity_ThrowsException(int capacity)
        {
            // act, assert
            Assert.Throws<ArgumentException>(() => new Container<CoffeeIngredient>(capacity));
        }
        [Fact]
        public void LoadResourceToContainer_Success()
        {
            // arrange
            var container = new Container<CoffeeIngredient>(1000);
            // act
            container.LoadResource(100);
            // assert
            Assert.Equal(100, container.Amount);
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void LoadNegativeOrZeroResource_ThrowsException(int toLoad)
        {
            // arrange
            var container = new Container<CoffeeIngredient>(1000);
            // act, assert
            Assert.Throws<ArgumentException>(() => container.LoadResource(toLoad));
        }
        [Fact]
        public void LoadMoreThanFreeSpace_ThrowsException()
        {
            // arrange
            var container = new Container<CoffeeIngredient>(1000);
            container.LoadResource(900);
            // act, assert
            Assert.Throws<ArgumentException>(() => container.LoadResource(101));
        }
        [Theory]
        [InlineData(500, 300)]
        [InlineData(900, 100)]
        [InlineData(1000, 1000)]
        public void GetResource_Success(int toLoad, int toGet)
        {
            // arrange
            var container = new Container<CoffeeIngredient>(1000);
            var expectedRemain = toLoad - toGet;
            // act
            container.LoadResource(toLoad);
            container.GetResource(toGet);
            var actualRemain = container.Amount;
            // assert
            Assert.Equal(expectedRemain, actualRemain);
        }
        [Theory]
        [InlineData(501)]
        public void RequestedResourcesAvailable_Success(int toLoad)
        {
            // arrange
            var container = new Container<CoffeeIngredient>(1000);
            var expectedAmount = toLoad;
            // act
            container.LoadResource(toLoad);
            var actualAmount = container.Amount;
            // assert
            Assert.Equal(expectedAmount, actualAmount);
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void GetNegativeOrZeroResources_ThrowsException(int toGet)
        {
            // arrange
            var container = new Container<CoffeeIngredient>(1000);
            container.LoadResource(100);
            // act, assert
            Assert.Throws<ArgumentException>(() => container.GetResource(toGet));
        }
        [Theory]
        [InlineData(100, 101)]
        [InlineData(1, 2)]
        [InlineData(0, 1)]
        public void GetMoreThanAmount_ThrowsException(int toLoad, int toGet)
        {
            // arrange
            var container = new Container<CoffeeIngredient>(1000);
            if (toLoad > 0)
            {
                container.LoadResource(toLoad);
            }
            // act, assert
            Assert.Throws<ArgumentException>(() => container.GetResource(toGet));
        }
    }
}
