using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class MenuBuilder : IMenuBuilder
    {
        private Menu _menu;

        public IMenuBuilder Reset()
        {
            _menu = null!;
            return this;
        }

        public IMenuBuilder Named(string name)
        {
            _menu = new Menu(string.IsNullOrWhiteSpace(name) ? "Menu" : name);
            return this;
        }

        public IMenuBuilder AddItem(string name, string description, string dishType, double price)
        {
            EnsureMenu();
            // Use your concrete leaf (you already used Dish elsewhere)
            var item = new Dish(name, description ?? "", dishType ?? "Main Course", price);
            _menu.add(item);
            return this;
        }

        public IMenuBuilder AddSubmenu(Menu submenu)
        {
            EnsureMenu();
            if (submenu == null) throw new ArgumentNullException(nameof(submenu));
            _menu.add(submenu);
            return this;
        }

        public bool RemoveAt(int index)
        {
            EnsureMenu();
            var children = SnapshotChildren(_menu);
            if (index < 0 || index >= children.Count) return false;
            _menu.remove(children[index]);
            return true;
        }

        public IReadOnlyList<MenuComponent> Children
            => _menu == null ? Array.Empty<MenuComponent>() : SnapshotChildren(_menu);

        public Menu Build()
        {
            EnsureMenu();
            return _menu;
        }

        private static List<MenuComponent> SnapshotChildren(Menu m)
        {
            var list = new List<MenuComponent>();
            int i = 0;
            while (true)
            {
                try
                {
                    list.Add(m.getChild(i++));
                }
                catch
                {
                    break;
                }
            }
            return list;
        }

        private void EnsureMenu()
        {
            if (_menu == null)
                throw new InvalidOperationException("Call Named(name) before adding parts.");
        }
    }
}


