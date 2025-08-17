using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7.OrderStates
{
    internal class RejectedState : OrderState
    {

        private Order order;


        public RejectedState(Order order)
        {
            this.order = order;
        }

        private string name = "Rejected";
        public string Name()
        {
            return name;
        }

        public void getRestaurantAction()
        {
            Console.WriteLine("Order Rejected - No Actions needed");
            Console.ReadKey();
        }

        public void getCustomerAction()
        {
            Console.WriteLine("Order Rejected - No Actions available");

            Console.ReadKey();
        }

        public void confirm()
        {
            Console.WriteLine("Order has been rejected - you may not confirm now");
        }

        public void proceed()
        {
            Console.WriteLine("Order has been rejected - you may not proceed now");
        }

        public void cancel()
        {
            Console.WriteLine("Order has been rejected - you may not cancel now");
        }

        public void reject()
        {
            Console.WriteLine("Order is already rejected.");
        }
    }
}
