using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class Menu : MenuComponent, Aggregate
    {
        private List<MenuComponent> components;
        private string name;

        public override string Name
        {
            get { return name; }
        }

        public Menu(string name)
        {
            this.name = name;
            components = new List<MenuComponent>();
        }

        public override void add(MenuComponent mc)
        {
            components.Add(mc);
        }

        public override void remove(MenuComponent mc)
        {
            components.Remove(mc);
        }

        public override MenuComponent getChild(int index)
        {
            return components[index];
        }

        public override double Price
        {
            get { return 0; }
        }

        public override string DishType
        {
            get { return "Menu"; }
        }

        public Iterator createIterator(string filter, int Type)
        {
            if (filter == "budget")
            {
                return new BudgetIterator(components);
            }
            else if (filter == "type")
            {
                return new DishTypeIterator(components, Type);
            }
            else
            {
                return new NormalIterator(components);
            }
        }

        private int getFilterType()
        {
            Console.WriteLine("Dish Type");
            Console.WriteLine("1. Main Course");
            Console.WriteLine("2. Side Dish");
            Console.WriteLine("3. Dessert");
            Console.WriteLine("4. Beverage");
            Console.WriteLine("Enter dish type: ");
            int option = Convert.ToInt32(Console.ReadLine());
            return option;
        }



        public override void print(string filter = "No filter")
        {
            int width = 34;

            string title = $" {Name.ToUpper()} ";
            int padding = (width - title.Length) / 2;

            Console.WriteLine(new string('=', width));
            Console.WriteLine(new string('=', padding) + title + new string('=', width - padding - title.Length));
            Console.WriteLine(new string('=', width));
            Console.WriteLine();

            int Type = 0;

            if (filter == "type")
            {
                Type = getFilterType();
            }


            Iterator iter = createIterator(filter, Type);
            while (iter.hasNext())
            {
                MenuComponent menuComponent = (MenuComponent)iter.next();
                menuComponent.subPrint(filter, Type);
            }

            Console.WriteLine();
        }

        public override void subPrint(string filter, int Type)
        {
        
            int width = 34;

            string title = $" {Name.ToUpper()} ";
            int padding = (width - title.Length) / 2;
            Console.WriteLine(new string('-', padding) + title + new string('-', width - padding - title.Length));

            Iterator iter = createIterator(filter, Type);
            while (iter.hasNext())
            {
                MenuComponent menuComponent = (MenuComponent)iter.next();
                menuComponent.subPrint(filter, Type);
            }

            Console.WriteLine();
        }

    }
}
