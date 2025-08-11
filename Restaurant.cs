using SDP_Assignment_Team7;
using System;

internal class Restaurant : Subject
{
    private string name;
    private List<Customer> customers;
    private Offer offer;
    private Menu menu;

    public string Name { get { return name; } set { name = value; } }
    public Offer Offer { get { return offer; } set { offer = value; } }

    public Menu Menu { get { return menu; } set { menu = value; } }

    public Restaurant(string name)
    {
        this.name = name;
        this.customers = new List<Customer>();
    }

    public void addCustomer(Customer customer)
    {
        customers.Add(customer);
    }

    public void removeCustomer(Customer customer)
    {
        customers.Remove(customer);
    }

    public void NotifyCustomers(Offer offer)
    {
        foreach (Customer customer in customers)
        {
            customer.update(this.Name, offer);
        }
    }

    public void setOffer(Offer offer)
    {
        this.offer = offer;
        NotifyCustomers(offer);
    }

    public void removeOffer()
    {
        offer = new NoOffer();
    }


    private readonly List<Order> orders = new(); // simple storage of completed carts

    public double applyOffer(double amount)
    {
        return offer.applyOffer(amount);
    }

    public void AddOrder(Order order)
    {
        if (order != null) orders.Add(order);
    }

    public IReadOnlyList<Order> Orders => orders;


}
