using System;

internal abstract class Restaurant : Subject
{
    private string name;
    private List<Customer> customers;
    private string offer;

    public string Name { get { return name; } set { name = value; } }
    public string Offer { get { return offer; } set { offer = value; } }

    public Restaurant(string name, string offer)
    {
        this.name = name;
        this.offer = offer;
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

    public void NotifyCustomers()
    {
        foreach (Customer customer in customers)
        {
            customer.update(this.Name, this.Offer);
        }
    }

    public void addNewOffer()
    {
        Console.WriteLine($"Adding new offer for {this.Name}:");
        string newOffer = Console.ReadLine();
        this.Offer = newOffer;
        NotifyCustomers();
    }

    public void displayMenu()
    {
        Console.WriteLine($"Menu for {this.Name}:");
    }


}
