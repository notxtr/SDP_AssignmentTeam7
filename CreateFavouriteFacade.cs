using System;

namespace SDP_Assignment_Team7
{
    internal class FavouriteOrderFacade
    {
        public static void PlaceOrderFromFavourite(Customer customer, FavouriteOrder favouriteOrder)
        {
            try
            {

                Cart orderCart = favouriteOrder.Cart.Clone();


                Restaurant restaurant = favouriteOrder.Restaurant;


                double subtotal = orderCart.Subtotal();
                double total = restaurant?.Offer != null
                    ? restaurant.Offer.applyOffer(subtotal)
                    : subtotal;


                var newOrder = new NormalOrder(orderCart, customer)
                {
                    Restaurant = restaurant,
                    TotalPrice = total
                };


                restaurant?.AddOrder(newOrder);
                customer?.AddOrder(newOrder);

                Console.WriteLine("\n[✓] Order placed successfully with one click!");
                Console.WriteLine($"Total: ${total:0.00}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError placing favorite order: {ex.Message}");
            }
        }
    }
}