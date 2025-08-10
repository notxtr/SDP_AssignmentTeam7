using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class BudgetIterator : Iterator
    {
        private List<MenuComponent> components;
        private int position = 0;

        public BudgetIterator(List<MenuComponent> components)
        {
            this.components = components;
        }

        public bool hasNext()
        {
            if (position < components.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object next()
        {
            if (position >= components.Count)
            {
                throw new InvalidOperationException("No more items.");
            }

            int cheapestIndex = position;
            for (int i = position + 1; i < components.Count; i++)
            {
                if (components[i].Price < components[cheapestIndex].Price)
                {
                    cheapestIndex = i; 
                }
            }
            (components[position], components[cheapestIndex]) =  (components[cheapestIndex], components[position]);

            return components[position++]; // now returns the next-cheapest
        }
    }
}
