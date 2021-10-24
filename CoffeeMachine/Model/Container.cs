using System;

namespace CoffeeMachine.Model
{
    public class Container<T> where T: ContainerContent
    {
        private const int MIN_CAPACITY = 1;
        private const int MAX_CAPACITY = 3000;
        private const int DEFAULT_CAPACITY = 1000;
        public T Content { get; }
        public int Amount
        {
            get
            {
                return Content.Amount;
            }
            private set
            {
                Content.Amount = value;
            }
        }
        public int Capacity { get; }

        public Container(int capacity)
        {
            if (!(MIN_CAPACITY <= capacity && capacity <= MAX_CAPACITY))
            {
                throw new ArgumentException(string.Format(
                    "You transmitted {0}. Capacity may not be less than {1} or more than {2}.",
                    capacity, MIN_CAPACITY, MAX_CAPACITY));
            }
            Capacity = capacity;
            Content = (T) Activator.CreateInstance(typeof(T), 0);
        }
        public Container() : this(DEFAULT_CAPACITY) { }
        public void LoadResource(int toLoad)
        {
            if (toLoad <= 0)
            {
                throw new ArgumentException(string.Format(
                    "You cannot put 0 or negative amount of resources. You tried to put {0}.",
                    toLoad));
            }
            if (toLoad > Capacity - Amount)
            {
                throw new ArgumentException(string.Format(
                    "Not enough free space to load such amount of resources. You tried to put {0} but free space is {1}.",
                    toLoad, Capacity - Amount));
            }
            Amount += toLoad;
        }
        public void GetResource(int toGet)
        {
            if (toGet <= 0)
            {
                throw new ArgumentException(string.Format(
                    "You cannot get 0 or negative amount of resources. You tried to get {0}.",
                    toGet));
            }
            if (toGet > Amount)
            {
                throw new ArgumentException(string.Format(
                    "Not enough resources. You tried to get {0} but amount is {1}.",
                    toGet, Amount));
            }
            Amount -= toGet;
        }
    }
}
