using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7.OrderStates
{
    internal class CreatedState : OrderState
    {

        Order order;

        public CreatedState(Order order)
        {
            this.order = order;
        }

        private string name = "Created";
        public string Name()
        {
            return name;
        }

        public void getRestaurantAction()
        {
            Console.WriteLine("Choose an action: ");
            Console.WriteLine("1. Confirm Order");
            Console.WriteLine("2. Reject Order");
            Console.WriteLine("3. Return");

            int action = Convert.ToInt32(Console.ReadLine());
            switch (action)
            {
                case 1:
                    confirm();
                    break;
                case 2:
                    reject();
                    break;
                case 3:
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

        public void confirm()
        {
            Console.WriteLine("Order confirmed.");
            order.SetState(new ConfirmedState(order));
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
            Console.WriteLine("Order has been rejected.");
            order.SetState(new RejectedState(order));
        }
    }
}
