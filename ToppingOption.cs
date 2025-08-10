using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class ToppingOption
    {
        public string Name;
        public double PriceChange;
        public string AllowedDishType; 

        public ToppingOption(string name, double priceChange, string allowedDishType)
        {
            Name = name;
            PriceChange = priceChange;
            AllowedDishType = allowedDishType;
        }
    }

}
