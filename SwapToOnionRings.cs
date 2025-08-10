using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class SwapToOnionRings: Topping
    {
        public SwapToOnionRings(MenuItem menuItem) : base(menuItem) { }

        public override string getDescription()
        {
            return menuItem.getDescription().Replace("Fries", "Onion Rings");
        }

        public override double getPrice()
        {
            return menuItem.getPrice() + 1.00;
        }
    }
}
