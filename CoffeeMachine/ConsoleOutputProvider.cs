using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public class ConsoleOutputProvider : IOutputProvider
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
