using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7.OrderStates
{
    internal class CancelledState : OrderState
    {

        private Order order;

        public CancelledState(Order order)
        {
            this.order = order;
        }

        private string name = "Cancelled";
        public string Name()
        {
            return name;
        }

        public void getRestaurantAction()
        {
            Console.WriteLine("Order Cancelled - No Actions needed");
            Console.ReadKey();
        }

        public void getCustomerAction()
        {
            Console.WriteLine("Order Cancelled - No Actions available");

            Console.ReadKey();
        }

        public void confirm()
        {
            Console.WriteLine("Order has been cancelled - you may not confirm now");
        }

        public void proceed()
        {
            Console.WriteLine("Order has been cancelled - you may not proceed now");
        }

        public void cancel()
        {
            Console.WriteLine("Order is already cancelled.");
        }

        public void reject()
        {
            Console.WriteLine("Order has been cancelled - you may not reject now");
        }
    }
}
