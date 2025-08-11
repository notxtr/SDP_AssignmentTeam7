using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal interface IMenuBuilder
    {
        IMenuBuilder Reset();
        IMenuBuilder Named(string name);
        IMenuBuilder AddItem(string name, string description, string dishType, double price);
        IMenuBuilder AddSubmenu(Menu submenu);


        bool RemoveAt(int index);
        IReadOnlyList<MenuComponent> Children { get; }
        Menu Build();
    }
}
