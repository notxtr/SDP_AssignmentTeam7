using System;

public interface Subject
{
    void addCustomer(Customer customer);
    void removeCustomer(Customer customer);
    void NotifyCustomers();
}
