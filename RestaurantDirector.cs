using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class RestaurantDirector
    {
        // Build using an already-prepared Menu
        public Restaurant Construct(IRestaurantBuilder r, string restaurantName, Menu menu)
        {
            return r.Reset()
                    .Named(restaurantName)
                    .SetMenu(menu)
                    .Build();
        }

        // Build using a menu builder configuration (if you prefer this style)
        public Restaurant Construct(IRestaurantBuilder r, IMenuBuilder m, string restaurantName, Action<IMenuBuilder> configureMenu)
        {
            m.Reset(); configureMenu(m);
            var menu = m.Build();

            r.Reset()
             .Named(restaurantName)
             .SetMenu(menu);

            return r.Build();
        }
    }
}
