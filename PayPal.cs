using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class PayPal : PaymentStrategy
    {
        public string MethodName { get { return "PayPal"; } }

        public bool Pay(double amount)
        {
            Console.WriteLine("=== PayPal Payment ===");
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Payment failed: missing credentials.");
                return false;
            }

            Console.WriteLine("Processing $" + amount.ToString("0.00") + " via PayPal...");
            Console.WriteLine("Payment successful.");
            return true;
        }
    }
}
