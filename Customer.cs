using SDP_Assignment_Team7;
using System;

internal class Customer : Observer
{
    private string name;
    private List<Restaurant> restaurantOffers;

    public string Name { get { return name; } set { name = value; } }
    public List<Restaurant> Offers { get { return restaurantOffers; } set { restaurantOffers = value; } }

    public Customer(string name)
    {
        this.name = name;
        this.restaurantOffers = new List<Restaurant>();
    }

    public void addNotification(Restaurant stock)
    {
        restaurantOffers.Add(stock);
        stock.addCustomer(this);
    }

    public void removeNotification(Restaurant stock)
    {
        restaurantOffers.Remove(stock);
        stock.removeCustomer(this);
    }

    public void update(string restaurantName, Offer offer)
    {
        Console.WriteLine($"{this.name} is notified that {restaurantName} has a new offer: {offer.getDescription()}");
    }

    public List<Order> PreviousOrders { get; } = new();

    public void AddOrder(Order order)
    {
        if (order != null) PreviousOrders.Add(order);
    }
}
