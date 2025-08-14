using System;

namespace SDP_Assignment_Team7
{
    internal class SetFavouriteCommand : Command
    {
        private Customer customer;
        private Cart cart;
        private FavouriteOrder createdOrder;

        public SetFavouriteCommand(Customer customer, Cart cart)
        {
            this.customer = customer;
            this.cart = cart.Clone();
        }

        public void execute()
        {
            createdOrder = new FavouriteOrder(cart, customer);
            FavouriteOrder.AddToFavourite(customer, cart);
            Console.WriteLine("Order saved to favourites!");
        }

        public void undo()
        {
            if (createdOrder != null)
            {
                if (FavouriteOrder.RemoveFavourite(customer, createdOrder))
                {
                    Console.WriteLine("Favourite order removed.");
                }
                else
                {
                    Console.WriteLine("Failed to remove favourite order.");
                }
            }
        }
    }
}