using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class OrderItem
    {
        public MenuItem Item { get; }
        public int Quantity { get; private set; }

        public OrderItem(MenuItem menuItem, int quantity)
        {
            Item = menuItem ?? throw new ArgumentNullException(nameof(menuItem));
            Quantity = Math.Max(1, quantity);
        }

        public double LineTotal => Item.Price * Quantity;

        public void Add(int qty) => Quantity += Math.Max(1, qty);
    }
}
