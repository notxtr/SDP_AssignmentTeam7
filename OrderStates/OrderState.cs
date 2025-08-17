using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7.OrderStates
{
    internal interface OrderState
    {

        public void getRestaurantAction();
        public void getCustomerAction();

        public string Name();
        public void confirm();

        public void proceed();

        public void cancel();

        public void reject();
    }
}
