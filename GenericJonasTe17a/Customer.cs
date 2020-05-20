using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericJonasTe17a
{
    class Customer
    {

        static List<string> nameList = new List<string>() {"John", "Beth", "Steve", "Dragazor the Conqueror", "Emily", "Zeus", "Gustav", "Zweihänder", "Karen"};
        static List<string> pizzaList = new List<string>() { "Margerita", "Vesuvio", "Calzone", "Salami", "Capricciosa", "Hawaii", "Tropicana", "Fungi", "Bologna" }; //Kan ligga i en överklass eftersom att både Customer och Pizza använder.
        static Random ran = new Random();
        public string name = nameList[ran.Next(0, nameList.Count)];
        public string requestedPizza = pizzaList[ran.Next(0, pizzaList.Count)];

    }
}
