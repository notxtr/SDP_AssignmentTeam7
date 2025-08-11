using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class CreditCard : PaymentStrategy
    {
        public string MethodName { get { return "Credit Card"; } }

        public bool Pay(double amount)
        {
            Console.WriteLine("=== Credit Card Payment ===");
            Console.Write("Cardholder Name: ");
            string name = Console.ReadLine();
            Console.Write("Card Number (16 digits): ");
            string number = Console.ReadLine();
            Console.Write("Expiry (MM/YY): ");
            string expiry = Console.ReadLine();
            Console.Write("CVV (3 digits): ");
            string cvv = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(number) ||
                string.IsNullOrWhiteSpace(expiry) || string.IsNullOrWhiteSpace(cvv))
            {
                Console.WriteLine("Payment failed: invalid details.");
                return false;
            }

            Console.WriteLine("Processing $" + amount.ToString("0.00") + "...");
            Console.WriteLine("Payment successful.");
            return true;
        }
    }
}
