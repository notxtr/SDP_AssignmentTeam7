using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7.OrderStates
{
    internal class PreparingState : OrderState
    {
        private Order order;

        public PreparingState(Order order)
        {
            this.order = order;
        }

        private string name = "Preparing...";
        public string Name()
        {
            return name;
        }


        public void getRestaurantAction()
        {
            Console.WriteLine("Choose an action: ");
            Console.WriteLine("1. Mark as Completed");
            Console.WriteLine("3. Return");

            int action = Convert.ToInt32(Console.ReadLine());
            switch (action)
            {
                case 1:
                    proceed();
                    break;
                case 2:
                    break;
                default:
                    Console.WriteLine("Invalid action. Please try again.");
                    getRestaurantAction();
                    break;
            }
        }

        public void getCustomerAction()
        {
            Console.WriteLine("Awaiting Completion - No Actions available");
            Console.ReadKey();
        }


        public void confirm()
        {
            Console.WriteLine("Order is already confirmed.");
        }

        public void proceed()
        {
            Console.WriteLine("Order is ready.");
            order.SetState(new CompletedState(order));
        }

        public void cancel()
        {
            Console.WriteLine("Order is already being prepared - you may not cancel now");
        }

        public void reject()
        {
            Console.WriteLine("Order has already been confirmed - you may not reject now");
        }
    }

}
