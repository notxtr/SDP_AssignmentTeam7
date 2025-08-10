using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class Dish: FoodItem
    {
        private string Name;
        private double Price;

        public Dish(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string getDescription()
        {
            return Name;
        }

        public double getPrice()
        {
            return Price;
        }
    }
}
