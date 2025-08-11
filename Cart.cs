using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class Cart
    {
        private readonly List<OrderItem> _items = new();

        public IReadOnlyList<OrderItem> Items => _items;

        public void AddItem(OrderItem oi)
        {
            if (oi == null) return;
            // merge if same MenuItem reference
            var existing = _items.FirstOrDefault(x => ReferenceEquals(x.Item, oi.Item));
            if (existing != null) existing.Add(oi.Quantity);
            else _items.Add(oi);
        }

        public double Subtotal()
        {
            double sum = 0;
            for (int i = 0; i < _items.Count; i++)
            {
                var unit = _items[i].Item.getPrice();         // <-- decorator-aware
                sum += unit * _items[i].Quantity;
            }
            return sum;
        }


        public Cart Clone()
        {
            var copy = new Cart();
            foreach (var it in Items) 
                copy.AddItem(new OrderItem(it.Item, it.Quantity));
            return copy;
        }


        public void Print()
        {
            if (_items.Count == 0) { Console.WriteLine("(Cart is empty)"); return; }
            for (int i = 0; i < _items.Count; i++)
            {
                var it = _items[i];
                var unit = it.Item.getPrice();              
                var line = unit * it.Quantity;
                Console.WriteLine($"{i + 1}. {it.Item.getDescription()} x{it.Quantity}  @ ${unit:0.00}  = ${line:0.00}");
            }
            Console.WriteLine($"Subtotal: ${Subtotal():0.00}");
        }


        public bool IsEmpty => _items.Count == 0;
        public void Clear() => _items.Clear();
    }
}
