using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SDP_Assignment_Team7
{
    internal abstract class MenuItem: MenuComponent
    {
        private string name;
        private string description;
        private string dishType;
        private double price;

        public MenuItem(string name, string description, string dishType, double price)
        {
            this.name = name;
            this.description = description;
            this.dishType = dishType;
            this.price = price;
        }

        public override string Name { get { return name; } }
        public override string Description { get { return description; } }
        public override double Price { get { return price; } }

        public override string DishType { get { return dishType; } }

        public override void print(string filter)
        {
            Console.WriteLine($"{name} - ${price}");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine("");

        }

        public override void subPrint(string filter, int Type)
        {
                Console.WriteLine($"{name} - ${price}");
                Console.WriteLine($"Description: {description}");
                Console.WriteLine("");

        }

        public abstract string getDescription();

        public abstract double getPrice();

}
}
