using System;
using CoffeeMachine;
using CoffeeMachine.Enumerations;
using CoffeeMachine.Model;

namespace ConsoleCoffeeMachine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var coffeeMachine = new CoffeeMachine.CoffeeMachine(new ConsoleOutputProvider());
            coffeeMachine.OnBrew += (sender, args) => Console.WriteLine("Coffee prepared");
            coffeeMachine.OnLoad += (sender, args) => Console.WriteLine("Resource loaded");
            PreparedCoffee coffee = null;
            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine();
                try {
                    CommandExecutor.Execute(input, coffeeMachine, ref coffee);
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
