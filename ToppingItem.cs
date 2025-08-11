using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class ToppingItem : Topping
    {
        private string toppingName;
        private double toppingPrice;

        public ToppingItem(MenuItem menuItem, string toppingName, double toppingPrice)
            : base(menuItem)
        {
            this.toppingName = toppingName;
            this.toppingPrice = toppingPrice;
        }

        public override string getDescription()
        {
            return $"{menuItem.getDescription()} + {toppingName}";
        }

        public override double getPrice()
        {
            return menuItem.getPrice() + toppingPrice;
        }
    }

}
