using System;
using CoffeeMachine;
using CoffeeMachine.Enumerations;

namespace ConsoleCoffeeMachine
{
    public static class CommandExecutor
    {
        public static void Execute(string argumentString, CoffeeMachine.CoffeeMachine cm, ref PreparedCoffee coffee)
        {
            argumentString = argumentString.ToLower();
            
            string[] commandParts = argumentString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            // Console.WriteLine("[" + string.Join(", ", s_arr) + "]");


            switch (commandParts[0])
            {
                case "load":
                    if (commandParts.Length != 3)
                        throw new Exception("Wrong operation. Using: load (coffee|water|milk) <number>");
                    var toLoad = int.Parse(commandParts[2]);
                    switch (commandParts[1])
                    {
                        case "coffee":
                            cm.LoadCoffee(toLoad);
                            break;
                        case "water":
                            cm.LoadWater(toLoad);
                            break;
                        case "milk":
                            cm.LoadMilk(toLoad);
                            break;
                        default:
                            throw new Exception("I don't know this resource. No operation happened.");
                    }
                    break;
                case "brew":
                    if (commandParts.Length != 2)
                        throw new Exception("Wrong operation. Using: brew (cappucino|espresso|filtered)");
                    switch (commandParts[1])
                    {
                        case "cappucino":
                            coffee = cm.Brew(Recipes.CAPPUCINO);
                            break;
                        case "espresso":
                            coffee = cm.Brew(Recipes.ESPRESSO);
                            break;
                        case "filtered":
                            coffee = cm.Brew(Recipes.FILTERED);
                            break;
                        default:
                            throw new Exception("I don't know this recipe. No operation happened.");
                    }
                    break;
                default:
                    throw new Exception("Unknown operation. Using: ( load (coffee|water|milk) <number> | brew (cappucino|espresso|filtered) )");
            }
        }
    }
}
