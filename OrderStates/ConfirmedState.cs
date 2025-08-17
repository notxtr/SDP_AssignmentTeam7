using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7.OrderStates
{
    internal class ConfirmedState : OrderState
    {
        private Order order;


        public ConfirmedState(Order order)
        {
            this.order = order;
        }

        public void getRestaurantAction()
        {
            Console.WriteLine("Choose an action: ");
            Console.WriteLine("1. Mark as Preparing");
            Console.WriteLine("2. Return");

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
            Console.WriteLine("Choose an action: ");
            Console.WriteLine("1. Cancle Order");
            Console.WriteLine("2. Return");

            int action = Convert.ToInt32(Console.ReadLine());
            switch (action)
            {
                case 1:
                    cancel();
                    break;
                case 2:
                    break;
                default:
                    Console.WriteLine("Invalid action. Please try again.");
                    getCustomerAction();
                    break;
            }
        }


        private string name = "Confirmed";
        public string Name()
        {
            return name;
        }

        public void confirm()
        {
            Console.WriteLine("Order is already confirmed.");
        }

        public void proceed()
        {
            Console.WriteLine("Order is now being prepared.");
            order.SetState(new PreparingState(order));
        }

        public void cancel()
        {
            Console.WriteLine("Order has been cancelled.");
            order.SetState(new CancelledState(order));
        }

        public void reject()
        {
            Console.WriteLine("Order has already been confirmed - you may not reject now");
        }
    }
}
