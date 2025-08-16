using System;

namespace SDP_Assignment_Team7
{
    internal class Order
    {
        private SetFavouriteCommand setFavouriteCommand;
        private Cart cart;
        private Customer customer;
        private Restaurant restaurant;
        private string address;
        private string delieveryNote;
        private double totalPrice;
        private Offer appliedOffer;

        public Order(Cart cart, Customer customer)
        {
            this.cart = cart;
            this.customer = customer;
        }

        public SetFavouriteCommand SetFavouriteCommand
        {
            get { return setFavouriteCommand; }
            set { setFavouriteCommand = value; }
        }

        public void Print()
        {
            cart.Print();
            if (appliedOffer != null)
            {
                Console.WriteLine(appliedOffer.getDescription());
                Console.WriteLine($"Total Paid: ${TotalPrice:0.00}");
            }
        }

        public Offer AppliedOffer
        {
            get { return appliedOffer; }
            set { appliedOffer = value; }
        }

        public Cart Cart
        {
            get { return cart; }
            set { cart = value; }
        }

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public Restaurant Restaurant
        {
            get { return restaurant; }
            set { restaurant = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public double TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

    }
}