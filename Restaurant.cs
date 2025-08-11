using SDP_Assignment_Team7;
using System;

internal abstract class Restaurant : Subject
{
    private string name;
    private List<Customer> customers;
    private Offer offer;

    public string Name { get { return name; } set { name = value; } }
    public Offer Offer { get { return offer; } set { offer = value; } }

    public Restaurant(string name , Offer offer)
    {
        this.name = name;
        this.customers = new List<Customer>();
        this.offer = offer;
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
            customer.update(this.Name, offer.getDescription());
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




}
