using System;
using System.Collections.Generic;

namespace SDP_Assignment_Team7
{
    internal class FavouriteOrder : Order
    {
        private static Dictionary<Customer, List<FavouriteOrder>> favourites = new();

        public FavouriteOrder(Cart cart, Customer customer) : base(cart, customer)
        {
        }

        public static void AddToFavourite(Customer customer, Cart cart)
        {
            if (!favourites.ContainsKey(customer))
            {
                favourites[customer] = new List<FavouriteOrder>();
            }

            var favourite = new FavouriteOrder(cart.Clone(), customer);
            favourites[customer].Add(favourite);
        }

        public static bool RemoveFavourite(Customer customer, FavouriteOrder order)
        {
            if (favourites.ContainsKey(customer))
            {
                return favourites[customer].Remove(order);
            }
            return false;
        }

        public static List<FavouriteOrder> GetFavourites(Customer customer)
        {
            return favourites.ContainsKey(customer) ? favourites[customer] : new List<FavouriteOrder>();
        }
    }
}