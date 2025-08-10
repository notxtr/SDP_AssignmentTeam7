using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class Dish : MenuItem
    {

        public Dish(string name, string description, string dT, double p) : base(name, description, dT, p)
        {

        }

        public override string getDescription()
        {
            return base.Name;
        }

        public override double getPrice()
        {
            return base.Price;
        }

        public void print()
        {
            Console.WriteLine($"{getDescription()} - ${getPrice():0.00}");
        }
    }

}
