using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class NormalIterator : Iterator
    {
        private List<MenuComponent> components;
        private int position = 0;

        public NormalIterator(List<MenuComponent> component)
        {
            this.components = component;
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

            return components[position++];
        }
    }
}
