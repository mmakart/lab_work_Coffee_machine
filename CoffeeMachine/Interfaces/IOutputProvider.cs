using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public interface IOutputProvider
    {
        void SendMessage(string message);
    }
}
