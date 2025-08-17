using SDP_Assignment_Team7.OrderStates;
using System;
using System.Collections.Generic;

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

        private OrderState orderState;

        public Order(Cart cart, Customer customer)
        {
            this.cart = cart;
            this.customer = customer;
            this.orderState = new CreatedState(this);
        }

        public SetFavouriteCommand SetFavouriteCommand
        {
            get { return setFavouriteCommand; }
            set { setFavouriteCommand = value; }
        }

        public void SetState(OrderState state)
        {
            this.orderState = state;
        }

        public OrderState State
        {
            get { return orderState; }
        }

        public void Print()
        {
            cart.Print();
            if (appliedOffer != null)
            {
                Console.WriteLine(appliedOffer.getDescription());
                Console.WriteLine($"Total Paid: ${TotalPrice:0.00}");
            }

            Console.WriteLine($"Delivery Address: {Address}");
            Console.WriteLine($"Delivery Note: {delieveryNote}");

            Console.WriteLine($"Order State: {orderState.Name()}");

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