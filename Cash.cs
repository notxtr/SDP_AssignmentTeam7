using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class Cash: PaymentStrategy
    {
        public string MethodName { get { return "Cash On Delivery"; } }

        public bool Pay(double amount)
        {
            Console.WriteLine("=== Cash On Delivery ===");
            Console.WriteLine("Amount due: $" + amount.ToString("0.00") + " to be paid to the rider.");
            Console.Write("Confirm (y/n): ");
            string yn = (Console.ReadLine() ?? "").Trim().ToLower();
            if (yn != "y")
            {
                Console.WriteLine("Payment not confirmed.");
                return false;
            }
            Console.WriteLine("Cash on delivery selected. Please prepare exact amount, no change will be given.");
            return true;
        }
    }
}
