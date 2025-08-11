using SDP_Assignment_Team7;
using System;

internal class Customer : Observer
{
    private string name;
    private List<Restaurant> offers;

    public string Name { get { return name; } set { name = value; } }
    public List<Restaurant> Offers { get { return offers; } set { offers = value; } }

    public Customer(string name)
    {
        this.name = name;
        this.offers = new List<Restaurant>();
    }

    public void addNotification(Restaurant stock)
    {
        offers.Add(stock);
        stock.addCustomer(this);
    }

    public void removeNotification(Restaurant stock)
    {
        offers.Remove(stock);
        stock.removeCustomer(this);
    }

    public void update(string restaurantName, string offer)
    {
        Console.WriteLine($"{this.name} is notified that {restaurantName} has a new offer: {offer}");
    }

    public List<Order> PreviousOrders { get; } = new();

    public void AddOrder(Order order)
    {
        if (order != null) PreviousOrders.Add(order);
    }
}
