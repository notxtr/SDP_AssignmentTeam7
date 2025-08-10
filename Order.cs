using System;

namespace SDP_Assignment_Team7
{
    internal abstract class Order
    {
        private SetFavouriteCommand setFavouriteCommand;
        private Cart cart;

        public Order(Cart cart)
        {
            this.cart = cart;
        }
    }
}