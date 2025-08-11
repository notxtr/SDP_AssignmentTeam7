using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class UICustomer
    {
        private Customer customer;
        private Cart cart = new();

        public void Start(Customer customer, List<Restaurant> restaurants)
        {
            this.customer = customer ?? throw new ArgumentNullException(nameof(customer));
            if (restaurants == null) restaurants = new List<Restaurant>();

            while (true)
            {
                Console.Clear();
                Header($"Welcome, {customer.Name}");
                Console.WriteLine("1) Browse restaurants");
                Console.WriteLine("2) View past orders");
                Console.WriteLine("0) Logout");
                Console.Write("\nChoice: ");

                var choice = Console.ReadLine()?.Trim();
                if (choice == "0") return;
                if (choice == "1") BrowseRestaurants(restaurants);
                else if (choice == "2") ShowPastOrders();
                else Pause("Invalid choice. Press ENTER to continue...");
            }
        }

        private void BrowseRestaurants(List<Restaurant> restaurants)
        {
            while (true)
            {
                Console.Clear();
                Header("Restaurants (enter number, B to go back)");
                if (restaurants.Count == 0)
                {
                    Pause("No restaurants available. Press ENTER to go back...");
                    return;
                }

                for (int i = 0; i < restaurants.Count; i++)
                    Console.WriteLine($"{i + 1}) {restaurants[i].Name}");

                Console.Write("\nSelect: ");
                var input = Console.ReadLine()?.Trim();
                if (string.Equals(input, "b", StringComparison.OrdinalIgnoreCase)) return;

                if (int.TryParse(input, out int idx) && idx >= 1 && idx <= restaurants.Count)
                {
                    BrowseMenuAndAdd(restaurants[idx - 1]);
                }
                else
                {
                    Pause("Invalid selection. Press ENTER to try again...");
                }
            }
        }

        // ========= New: browse menu, add to cart by PATH, checkout here =========
        private void BrowseMenuAndAdd(Restaurant r)
        {
            if (r.Menu == null)
            {
                Pause("This restaurant has no menu yet. Press ENTER to go back...");
                return;
            }

            string currentFilter = "normal";

            while (true)
            {
                Console.Clear();
                Header($"{r.Name} — Browse & Add (B=Back, C=Cart, K=Checkout, F=filter)");
                Console.WriteLine($"Current filter: {currentFilter.ToUpper()}");
                Console.WriteLine();


                PrintMenuTreeWithPaths(r.Menu);

                Console.WriteLine();
                Console.Write("Enter item PATH (e.g., 4,1,3) or command (B/C/K/F): ");
                var input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input)) continue;
                if (string.Equals(input, "b", StringComparison.OrdinalIgnoreCase))
                { 
                    cart.Clear();
                    return;
                };

                if (string.Equals(input, "c", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    Header("Cart");
                    cart.Print();
                    Pause("Press ENTER to return…");
                    continue;
                }

                if (string.Equals(input, "k", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    Checkout(r);
                    Pause("Press ENTER to return…");
                    continue;
                }

                if (string.Equals(input, "f", StringComparison.OrdinalIgnoreCase))
                {
                    currentFilter = ChooseFilter(); 

                    Console.Clear();
                    Header($"{r.Name} — VIEW ({currentFilter.ToUpper()})");
                    try
                    {

                        r.Menu.print(currentFilter);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error printing menu: {ex.Message}");
                    }
                    Pause("Press ENTER to return…");
                    Console.Clear();
                    continue;
                }

                if (string.Equals(input, "m", StringComparison.OrdinalIgnoreCase))
                {

                }


                var indices = ParsePath(input);
                if (indices == null)
                {
                    Pause("Invalid path format. Use e.g. 4,1,3");
                    continue;
                }

                try
                {
                    var target = ResolvePath(r.Menu, indices);
                    if (target is MenuItem mi)
                    {
                        Console.Write($"Qty for \"{mi.Name}\": ");
                        if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0) qty = 1;

                        cart.AddItem(new OrderItem(mi, qty));
                        Console.WriteLine($"[+] Added {mi.Name} x{qty} to cart.");
                        Console.Write("Press ENTER to continue...");
                        Console.ReadLine();
                    }
                    else
                    {
                        Pause("Path resolves to a submenu. Enter a full path to a dish (leaf).");
                    }
                }
                catch (Exception ex)
                {
                    Pause($"Could not resolve path: {ex.Message}");
                }
            }
        }

        // ----- Helpers -----


        private void PrintMenuTreeWithPaths(Menu root)
        {
            PrintNode(root, new List<int>(), 0);
        }

        private void ShowPastOrders()
        {
            Console.Clear();
            Header("Past Orders");

            var orders = (customer.GetType().GetProperty("PreviousOrders") != null)
                ? customer.PreviousOrders
                : null;

            if (orders == null || orders.Count == 0)
            {
                Console.WriteLine("(No past orders found.)");
                Pause("Press ENTER to return…");
                return;
            }

            for (int i = 0; i < orders.Count; i++)
            {
                Console.WriteLine($"Order #{i + 1}:");
                try
                {
                    orders[i].Print();
                }
                catch
                {
                    Console.WriteLine("  (Unable to print cart details)");
                }
                Console.WriteLine();
            }

            Pause("End of list. Press ENTER to return…");
        }

        private static string ChooseFilter()
        {
            while (true)
            {
                Console.Clear();
                Header("Choose Filter");
                Console.WriteLine("1) Normal");
                Console.WriteLine("2) Price (Lowest - Highest)");
                Console.WriteLine("3) Dish Type");
                Console.WriteLine("4) Categories");
                Console.WriteLine("B) Back");
                Console.Write("\nChoice: ");
                var c = Console.ReadLine()?.Trim().ToLower();

                if (c == "b") return "normal";
                if (c == "1") return "normal";
                if (c == "2") return "budget";
                if (c == "3") return "type";
                if (c == "4") return "category";

                Console.WriteLine("Invalid choice. Press ENTER to try again…");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void PrintNode(MenuComponent node, List<int> path, int depth)
        {
            string indent = new string(' ', depth * 2);

            if (node is Menu m)
            {
                if (depth == 0)
                {
                    Console.WriteLine($"{m.Name}:");
                }

                var children = SnapshotChildren(m);
                for (int i = 0; i < children.Count; i++)
                {
                    var child = children[i];
                    var childPath = new List<int>(path) { i + 1 };
                    var pathTag = "[" + string.Join(",", childPath) + "]";

                    if (child is Menu submenu)
                    {
                        Console.WriteLine($"{indent}{pathTag} [Menu] {submenu.Name}");
                        PrintNode(submenu, childPath, depth + 1);
                    }
                    else if (child is MenuItem mi)
                    {
                        Console.WriteLine($"{indent}{pathTag} {mi.Name} - {mi.DishType} ${mi.Price:0.00}");
                    }
                }
            }
        }

        private static List<MenuComponent> SnapshotChildren(Menu m)
        {
            var list = new List<MenuComponent>();
            int i = 0;
            while (true)
            {
                try { list.Add(m.getChild(i++)); }
                catch { break; }
            }
            return list;
        }

        private static List<int>? ParsePath(string input)
        {
            var parts = input.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return null;
            var res = new List<int>();
            foreach (var p in parts)
            {
                if (!int.TryParse(p, out int n) || n <= 0) return null;
                res.Add(n);
            }
            return res;
        }

        private static MenuComponent ResolvePath(Menu root, List<int> indices)
        {
            MenuComponent current = root;
            foreach (var oneBased in indices)
            {
                int idx = oneBased - 1;
                current = current.getChild(idx);
            }
            return current;
        }

        private void Checkout(Restaurant r)
        {
            if (cart.IsEmpty) { Console.WriteLine("(Cart is empty)"); return; }

            Console.WriteLine("=== Checkout ===");
            cart.Print();

            double subtotal = cart.Subtotal();
            double total = r?.Offer != null ? r.Offer.applyOffer(subtotal) : subtotal;
            if (total < 0) total = 0;

            Console.WriteLine($"Offer: {(r?.Offer != null ? r.Offer.getDescription() : "(none)")}");
            Console.WriteLine($"Total after offer: ${total:0.00}");
            Console.Write("Confirm order? (y/n): ");
            var yn = (Console.ReadLine() ?? "").Trim().ToLower();
            if (yn != "y") { Console.WriteLine("Cancelled."); return; }


            var snapshot = cart.Clone();
            var order = new Order(snapshot, customer);

            try { r?.AddOrder(order); } catch { /* ignore if not implemented */ }
            try { customer?.AddOrder(order); } catch { /* ignore if not implemented */ }

            Console.WriteLine("[✓] Order placed!");
            cart.Clear();
        }

        private static void Header(string title)
        {
            var t = $" {title} ";
            int w = Math.Max(60, t.Length + 4); // 60 min width, else longer if title is big
            var pad = Math.Max(0, (w - t.Length) / 2);

            Console.WriteLine(new string('=', w));
            Console.WriteLine(new string('=', pad) + t + new string('=', Math.Max(0, w - pad - t.Length)));
            Console.WriteLine(new string('=', w));
            Console.WriteLine();
        }

        private static void Pause(string msg)
        {
            Console.WriteLine();
            Console.WriteLine(msg);
            Console.ReadLine();
        }





    }
}
