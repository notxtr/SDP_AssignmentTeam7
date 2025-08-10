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

        public Topping(MenuItem menuItem)
        {
            this.menuItem = menuItem;
        }

        public virtual string dishType => menuItem.dishType;
        public virtual double price => menuItem.price;

        public virtual string getDescription()
        {
            return menuItem.getDescription();
        }

        public virtual double getPrice()
        {
            return menuItem.getPrice();
        }

        public virtual void print()
        {
            Console.WriteLine($"{getDescription()} - ${getPrice():0.00}");
        }
    }

}
