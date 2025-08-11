using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class ConcreteTopping : Topping
    {
        private string label;
        private double delta;

        public ConcreteTopping(MenuItem menuItem, string label, double priceChange)
            : base(menuItem)
        {
            this.label = label;
            this.delta = priceChange;
        }

        public override string getDescription()
        {
            return menuItem.getDescription() + " + " + label;
        }

        public override double getPrice()
        {
            return menuItem.getPrice() + delta;
        }
    }
}
