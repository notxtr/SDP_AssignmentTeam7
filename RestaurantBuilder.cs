using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class RestaurantBuilder : IRestaurantBuilder
    {
        private Restaurant _restaurant;

        public IRestaurantBuilder Reset()
        {
            _restaurant = null!;
            return this;
        }

        public IRestaurantBuilder Named(string name)
        {
            _restaurant = new Restaurant(string.IsNullOrWhiteSpace(name) ? "Restaurant" : name);
            return this;
        }

        public IRestaurantBuilder SetMenu(Menu menu)
        {
            EnsureRestaurant();
            _restaurant.Menu = menu ?? throw new ArgumentNullException(nameof(menu));
            return this;
        }

        public Restaurant Build()
        {
            EnsureRestaurant();
            return _restaurant;
        }

        private void EnsureRestaurant()
        {
            if (_restaurant == null)
                throw new InvalidOperationException("Call Named(name) before setting parts.");
        }
    }

}

