using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal abstract class Topping : MenuItem
    {
        protected MenuItem menuItem;

        public Topping(MenuItem menuItem) : base(menuItem.Name, menuItem.Description, menuItem.DishType, menuItem.Price)
        {
            this.menuItem = menuItem;
        }

        public virtual string dishType => menuItem.DishType;
        public virtual double price => menuItem.Price;

        public override abstract string getDescription();

        public override abstract double getPrice();

        public virtual void print()
        {
            Console.WriteLine($"{getDescription()} - ${getPrice():0.00}");
        }
    }

}
