using System;

internal abstract class Order
{
    private SetFavouriteCommand setFavouriteCommand;
    private Cart cart;

    public Order(Cart cart)
    {
        this.cart = cart;
    }
}
