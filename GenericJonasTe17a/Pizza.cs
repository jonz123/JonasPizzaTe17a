using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericJonasTe17a
{
    class Pizza
    {

        static List<string> pizzaList = new List<string>() {"Margerita", "Vesuvio", "Calzone", "Salami", "Capricciosa", "Hawaii", "Tropicana", "Fungi", "Bologna" };
        static Random ran = new Random();
        public string pizzaType = pizzaList[ran.Next(0, pizzaList.Count)];

    }
}
