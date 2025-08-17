using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7.OrderStates
{
    internal class CompletedState : OrderState
    {

        private Order order;

        public CompletedState(Order order)
        {
            this.order = order;
        }

        public void getRestaurantAction()
        {
            Console.WriteLine("Order Completed - No Actions needed");
            Console.ReadKey();
        }

        public void getCustomerAction()
        {
            Console.WriteLine("Order Completed - No Actions available");

            Console.ReadKey();
        }

        private string name = "Completed";
        public string Name()
        {
            return name;
        }

        public void confirm()
        {
            Console.WriteLine("Order is already completed.");
        }

        public void proceed()
        {
            Console.WriteLine("Order is already completed - you may not proceed now");
        }

        public void cancel()
        {
            Console.WriteLine("Order is already completed - you may not cancel now");
        }

        public void reject()
        {
            Console.WriteLine("Order is already completed - you may not reject now");
        }
    }
}
