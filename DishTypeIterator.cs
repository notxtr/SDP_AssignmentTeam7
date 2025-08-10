using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class DishTypeIterator : Iterator
    {
        private List<MenuComponent> components;
        private int position = 0;
        private int dishType = 0;


        public DishTypeIterator(List<MenuComponent> components, int DishType)
        {
            this.components = components;
            dishType = DishType;
        }


        private string? ChoiceToDishType(int choice)
        {
            switch (choice)
            {
                case 1: return "Main Course";
                case 2: return "Side Dish";
                case 3: return "Dessert";
                case 4: return "Beverage";
                default: return null; // null => no filter
            }
        }

        private bool MatchesFilter(MenuComponent c)
        {
            // Always include menus
            if (c is Menu)
                return true;

            // Otherwise, only match MenuItem that fits the type
            if (c is MenuItem item)
            {
                var type = ChoiceToDishType(dishType);
                if (type is null)
                    return true; // no filter
                return string.Equals(item.DishType, type, StringComparison.OrdinalIgnoreCase);
            }

            // Unknown component type
            return false;
        }

        public bool hasNext()
        {
            while (position < components.Count)
            {
                if (MatchesFilter(components[position]))
                    return true;
                position++; // skip non-matching entries
            }
            return false;
        }

        public object next()
        {
            if (!hasNext())
                throw new InvalidOperationException("No more matching items.");
            return components[position++]; // returns next matching MenuItem
        }
    }
}
