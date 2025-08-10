using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class Dish : MenuItem
    {
        public string dishType { get; private set; }
        public double price { get; private set; }

        public Dish(string dT, double p)
        {
            dishType = dT;
            price = p;
        }

        public string getDescription()
        {
            return dishType;
        }

        public double getPrice()
        {
            return price;
        }

        public void print()
        {
            Console.WriteLine($"{getDescription()} - ${getPrice():0.00}");
        }
    }

}
