using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class PaymentContext
    {
        private PaymentStrategy Strategy;

        public void SetStrategy(PaymentStrategy strategy)
        {
            Strategy = strategy;
        }

        public bool Process(double amount)
        {
            if (Strategy == null)
            {
                System.Console.WriteLine("No payment method selected.");
                return false;
            }
            return Strategy.Pay(amount);
        }
    }
}
