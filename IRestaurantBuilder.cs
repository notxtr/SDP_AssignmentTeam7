using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal interface IRestaurantBuilder
    {
        IRestaurantBuilder Reset();
        IRestaurantBuilder Named(string name);
        IRestaurantBuilder SetMenu(Menu menu);
        Restaurant Build();
    }
}
