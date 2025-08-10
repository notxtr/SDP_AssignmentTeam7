using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class Chilli : Topping
    {
        public Chilli(MenuItem menuItem) : base(menuItem) { }

        public override string getDescription()
        {
            return menuItem.getDescription() + ",with Extra Chilli";
        }

        public override double getPrice()
        {
            return menuItem.getPrice() + 0.50;
        }
    }

}
