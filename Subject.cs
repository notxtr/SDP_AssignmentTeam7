using SDP_Assignment_Team7;
using System;

internal interface Subject
{
    void addCustomer(Customer customer);
    void removeCustomer(Customer customer);
    void NotifyCustomers(Offer offer);
}
