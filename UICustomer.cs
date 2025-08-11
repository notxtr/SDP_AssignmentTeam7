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

                        MenuItem Customized = ConfigureToppingsForDish(mi, AllOptions);

                        cart.AddItem(new OrderItem(Customized, qty));
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

        MenuItem ConfigureToppingsForDish(MenuItem baseDish, List<ToppingOption> AllOptions)
        {
            List<ToppingOption> options = new List<ToppingOption>();
            for (int i = 0; i < AllOptions.Count; i++)
            {
                if (AllOptions[i].AllowedDishType == baseDish.DishType)
                {
                    options.Add(AllOptions[i]);
                }
            }

            if (options.Count == 0)
            {
                Console.WriteLine("\nNo available modifications for this dish.");
                return baseDish;
            }

            List<int> selectedIndices = new List<int>(); 
            MenuItem current = baseDish;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Customizing: " + current.getDescription());
                Console.WriteLine("Current price: $" + current.getPrice().ToString("0.00"));
                Console.WriteLine();

                Console.WriteLine("Choose toppings by number (toggle).");
                Console.WriteLine("0) No topping / Done");
                for (int i = 0; i < options.Count; i++)
                {
                    bool chosen = false;
                    for (int k = 0; k < selectedIndices.Count; k++)
                    {
                        if (selectedIndices[k] == i) { chosen = true; break; }
                    }
                    string mark = chosen ? "[x]" : "[ ]";
                    string delta = options[i].PriceChange >= 0
                        ? "(+$" + options[i].PriceChange.ToString("0.00") + ")"
                        : "(-$" + Math.Abs(options[i].PriceChange).ToString("0.00") + ")";
                    Console.WriteLine((i + 1) + ") " + mark + " " + options[i].Name + " " + delta);
                }

                Console.Write("\nPick one number (0 to finish): ");
                string input = Console.ReadLine();
                int pick;
                if (!int.TryParse(input, out pick)) continue;

                if (pick == 0) break;
                if (pick < 1 || pick > options.Count) continue;

                int idx = pick - 1;

                int foundAt = -1;
                for (int t = 0; t < selectedIndices.Count; t++)
                {
                    if (selectedIndices[t] == idx) { foundAt = t; break; }
                }
                if (foundAt >= 0) selectedIndices.RemoveAt(foundAt);
                else selectedIndices.Add(idx);

                current = baseDish;
                for (int t = 0; t < selectedIndices.Count; t++)
                {
                    int si = selectedIndices[t];
                    ToppingOption opt = options[si];
                    current = new ToppingItem(current, opt.Name, opt.PriceChange);
                }
            }

            return current;
        }

        // ----- Helpers -----
        private void PromptPayment(double amount)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("=== Choose Payment Method ===");
                Console.WriteLine("1) Credit Card");
                Console.WriteLine("2) PayPal");
                Console.WriteLine("3) Cash on Delivery");
                Console.WriteLine("0) Cancel");
                Console.Write("Choice: ");

                string c = (Console.ReadLine() ?? "").Trim();
                PaymentStrategy strategy = null;

                if (c == "0") { Console.WriteLine("Payment cancelled."); return; }
                else if (c == "1") strategy = new CreditCard();
                else if (c == "2") strategy = new PayPal();
                else if (c == "3") strategy = new Cash();
                else { Console.WriteLine("Invalid choice."); continue; }

                var ctx = new PaymentContext();
                ctx.SetStrategy(strategy);

                bool ok = ctx.Process(amount);
                if (ok)
                {
                    Console.WriteLine("Thank you! Payment completed.");
                    break;
                }
                else
                {
                    Console.WriteLine("Payment failed. Try again?");
                }
            }
        }


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

            // Place order
            var snapshot = cart.Clone();
            var order = new Order(snapshot, customer);

            try { r?.AddOrder(order); } catch { }
            try { customer?.AddOrder(order); } catch { }

            Console.WriteLine("[✓] Order placed!");
 
            cart.Clear();

            PromptPayment(total);
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

        List<ToppingOption> AllOptions = new List<ToppingOption>
{
    // ===== Beverage (Kopi O, Teh Tarik, Orange Juice, etc.) =====
    new ToppingOption("More Ice",        0.00, "Beverage"),
    new ToppingOption("Less Ice",        0.50, "Beverage"),
    new ToppingOption("No Ice",          0.50, "Beverage"),
    new ToppingOption("Less Sugar",      0.00, "Beverage"),
    new ToppingOption("No Sugar",        0.00, "Beverage"),
    new ToppingOption("Extra Shot",      0.80, "Beverage"),
    new ToppingOption("Oat Milk",        0.70, "Beverage"),
    new ToppingOption("Large Size",      0.60, "Beverage"),
    new ToppingOption("Warm/Hot",        0.00, "Beverage"),
    new ToppingOption("Lemon Slice",     0.20, "Beverage"),

    // ===== Main Course (Nasi Lemak, Omelette, Pancakes, etc.) =====
    new ToppingOption("Extra Sambal",    0.30, "Main Course"),
    new ToppingOption("Add Egg",         1.00, "Main Course"),
    new ToppingOption("Add Chicken Wing",2.00, "Main Course"),
    new ToppingOption("Extra Ikan Bilis",0.80, "Main Course"),
    new ToppingOption("Extra Cheese",    1.20, "Main Course"),
    new ToppingOption("Extra Vegetables",0.80, "Main Course"),
    new ToppingOption("Add Rice",        0.50, "Main Course"),
    new ToppingOption("Less Rice",      -0.30, "Main Course"),
    new ToppingOption("No Chili",        0.00, "Main Course"),
    new ToppingOption("Maple Syrup Refill",0.40,"Main Course"), // pancakes

    // ===== Side Dish (Ikan Bilis & Peanuts, Hash Browns, Buttered Toast) =====
    new ToppingOption("Extra Sauce",     0.30, "Side Dish"),
    new ToppingOption("Add Cheese",      0.80, "Side Dish"),
    new ToppingOption("Extra Portion",   0.80, "Side Dish"),
    new ToppingOption("Crispier (Well-done)",0.00,"Side Dish"),
    new ToppingOption("No Salt",         0.00, "Side Dish"),
    new ToppingOption("Extra Butter",    0.30, "Side Dish"),
    new ToppingOption("Add Peanuts",     0.50, "Side Dish"),
    new ToppingOption("Ketchup on Side", 0.10, "Side Dish"),


    // ===== Dessert (Banana Bread Slice, Blueberry Muffin) =====
    new ToppingOption("Warm It Up",      0.00, "Dessert"),
    new ToppingOption("Extra Syrup",     0.30, "Dessert"),
    new ToppingOption("Add Ice Cream",   1.00, "Dessert"),
    new ToppingOption("Whipped Cream",   0.50, "Dessert"),
    new ToppingOption("Add Berries",     0.70, "Dessert"),
    new ToppingOption("Chocolate Chips", 0.50, "Dessert"),
    new ToppingOption("Less Sweet",      0.00, "Dessert"),

};



    }
}
