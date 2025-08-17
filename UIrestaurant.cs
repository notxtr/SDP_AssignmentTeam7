using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    /// <summary>
    /// UI Facade for restaurant onboarding.
    /// Orchestrates Restaurant + Menu building via console, keeping the console clean.
    /// </summary>
    internal sealed class UIRestaurant
    {
        public void LoginAndManageRestaurant()
        {
            var restaurants = Graberroo.getInstance().GetRestaurants;
            if (restaurants.Count == 0)
            {
                Pause("No restaurants exist yet. Create one first.");
                return;
            }

            try
            {
                while (true)
                {
                    Console.Clear();
                    Header("Select Your Restaurant (L=logout)");

                    // Display all restaurants with numbers
                    for (int i = 0; i < restaurants.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}) {restaurants[i].Name}");
                    }

                    var input = ReadOrLogout("\nEnter restaurant number (0 to cancel): ").Trim();
                    if (input == "0") return;

                    if (int.TryParse(input, out int index) && index > 0 && index <= restaurants.Count)
                    {
                        // Found valid restaurant - enter management
                        ManageRestaurant(restaurants[index - 1]);
                    }
                    else
                    {
                        Pause("Invalid selection. Please try again.");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                
            }
        }
        public Restaurant? CreateRestaurant()
        {
            try
            {
                Console.Clear();
                Header("Create Restaurant  (L = logout)");

                var name = ReadOrLogout("Enter restaurant name: ");
                if (string.IsNullOrWhiteSpace(name)) name = "Restaurant";

                // Build one menu interactively
                var menu = BuildMenuInteractively();
                if (menu == null) return null; // user logged out inside menu flow

                // Assemble via pure builder
                var rb = new RestaurantBuilder();
                var restaurant = rb.Reset()
                                    .Named(name)
                                    .SetMenu(menu)
                                    .Build();

                // Preview & confirm
                Console.Clear();
                Header("Preview  (L = logout)");
                Console.WriteLine($"Restaurant: {restaurant.Name}\n");
                try { restaurant.Menu.print("normal"); }
                catch { Console.WriteLine("(Implement Menu.print to preview)"); }

                var ans = ReadOrLogout("\nSave this restaurant? (y/n, L=logout): ").Trim().ToLower();
                if (ans != "y")
                {
                    Pause("Cancelled. Returning…");
                    return null;
                }

                Pause("Saved.");
                Graberroo.getInstance().GetRestaurants.Add(restaurant);
                ManageRestaurant(restaurant);
                return restaurant;
            }
            catch (OperationCanceledException)
            {
                // any prompt where user typed L bubbles up here
                return null;
            }
        }

        public Menu? BuildMenuInteractively(string? seedName = null)
        {
            try
            {
                var mb = new MenuBuilder();
                if (!string.IsNullOrWhiteSpace(seedName))
                {
                    mb.Named(seedName);
                }
                else
                {
                    Console.Clear();
                    var n = ReadOrLogout("Enter menu name (L = logout): ");
                    mb.Named(string.IsNullOrWhiteSpace(n) ? "Menu" : n);
                }

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"--- Editing \"{mb.Build().Name}\" ---  (L = logout)");
                    Console.WriteLine("1) Add item");
                    Console.WriteLine("2) Add submenu");
                    Console.WriteLine("3) Show current entries");
                    Console.WriteLine("4) Remove entry");
                    Console.WriteLine("0) Done");
                    var choice = ReadOrLogout("Choice: ").Trim();

                    if (choice == "0") break;

                    switch (choice)
                    {
                        case "1":
                            Console.Clear();
                            AddItem(mb);
                            break;

                        case "2":
                            Console.Clear();
                            AddSubmenu(mb);
                            break;

                        case "3":
                            Console.Clear();
                            PrintChildren(mb);
                            Pause();
                            break;

                        case "4":
                            Console.Clear();
                            RemoveEntry(mb);
                            Pause();
                            break;

                        default:
                            Pause("Invalid choice.");
                            break;
                    }
                }

                return mb.Build();
            }
            catch (OperationCanceledException)
            {
                return null; // bubble logout up to caller
            }
        }

        public void ManageRestaurant(Restaurant restaurant)
        {
            try
            {
                while (true)
                {
                    Console.Clear();
                    Header($"Managing {restaurant.Name} (L = logout)");
                    Console.WriteLine($"Current Offer: {(restaurant.Offer != null ? restaurant.Offer.getDescription() : "None")}");
                    Console.WriteLine("1) Edit Menu");
                    Console.WriteLine("2) Create/Update Offer");
                    Console.WriteLine("3) Remove Current Offer");
                    Console.WriteLine("4) View Orders");
                    Console.WriteLine("0) Back");

                    var choice = ReadOrLogout("Choice: ").Trim();
                    if (choice == "0") break;

                    switch (choice)
                    {
                        case "1":
                            var newMenu = BuildMenuInteractively();
                            if (newMenu != null)
                            {
                                restaurant.Menu = newMenu;
                                Pause("Menu updated successfully!");
                            }
                            break;

                        case "2":
                            CreateOrUpdateOffer(restaurant);
                            break;

                        case "3":
                            restaurant.removeOffer();
                            Pause("Offer removed. Customers will no longer see this promotion.");
                            break;

                        case "4":
                            ViewOrders(restaurant);
                            break;

                        default:
                            Pause("Invalid choice.");
                            break;
                    }
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
        }

        public void ViewOrders(Restaurant restaurant)
        {
            try
            {
                while (true)
                {
                    Console.Clear();
                    Header($"Orders for {restaurant.Name} (L = logout)");

                    // assume restaurant.Orders is List<Order>
                    var orders = restaurant.Orders;
                    if (orders == null || orders.Count == 0)
                    {
                        Console.WriteLine("(No orders yet.)");
                        Pause();
                        return;
                    }

                    // brief summary list
                    for (int i = 0; i < orders.Count; i++)
                    {
                        var o = orders[i];

                        Console.WriteLine(
                            $"{i + 1}) ${o.TotalPrice:0.00}");
                    }
                    Console.WriteLine("0) Back");

                    var input = ReadOrLogout("\nSelect an order to view (0 to back): ").Trim();
                    if (input == "0") return;

                    if (!int.TryParse(input, out int idx) || idx < 1 || idx > orders.Count)
                    {
                        Pause("Invalid selection.");
                        continue;
                    }

                    var order = orders[idx - 1];

                    Console.Clear();
                    Header($"Order #{idx} (L = logout)");
                    try
                    {
                        order.Print();
                    }
                    catch
                    {
                        Console.WriteLine("(order.Print() not implemented)");
                    }

                    // show restaurant-side next action from state
                    try
                    {
                        order.State.getRestaurantAction(); // as requested
                    }
                    catch
                    {
                        Console.WriteLine("\n(next action unavailable)");
                    }

                    Pause();
                }
            }
            catch (OperationCanceledException)
            {
                // bubble logout
                throw;
            }
        }

        private void CreateOrUpdateOffer(Restaurant restaurant)
        {
            Console.Clear();
            Header($"Create/Update Offer for {restaurant.Name}");

            Console.WriteLine("Select Offer Type:");
            Console.WriteLine("1) Percentage Discount");
            Console.WriteLine("2) Fixed Discount");
            Console.WriteLine("0) Cancel");

            var choice = ReadOrLogout("Choice: ").Trim();
            if (choice == "0") return;

            try
            {
                Offer newOffer = null;
                string description = ReadOrLogout("Enter offer description: ");

                switch (choice)
                {
                    case "1":
                        double percent = double.Parse(ReadOrLogout("Enter discount fraction (e.g. 10%): "));
                        newOffer = new PercentageOffer(percent, description);
                        break;

                    case "2":
                        double amount = double.Parse(ReadOrLogout("Enter discount amount (e.g. $5): "));
                        newOffer = new FixedOffer(amount, description);
                        break;

                    default:
                        Pause("Invalid choice.");
                        return;
                }

                restaurant.setOffer(newOffer);
                Pause($"Offer set successfully! All subscribers will be notified.");
            }
            catch (FormatException)
            {
                Pause("Invalid number format. Please enter a valid number.");
            }
        }

        // ---------- helpers ----------

        private static void AddItem(IMenuBuilder mb)
        {
            var name = ReadOrLogout(" Item name (L = logout): ");
            var desc = ReadOrLogout(" Description (L = logout): ");

            var dishType = PromptDishType(); // supports L
            var priceStr = ReadOrLogout(" Price (L = logout): ");
            if (!double.TryParse(priceStr, out var price)) price = 0.0;

            mb.AddItem(name, desc, dishType, price);
            Pause($"[+] Added: {name} ({dishType}) ${price:0.00}");
        }

        private void AddSubmenu(IMenuBuilder mb)
        {
            var name = ReadOrLogout(" Submenu name (L = logout): ");
            var submenu = BuildMenuInteractively(string.IsNullOrWhiteSpace(name) ? "Submenu" : name);
            if (submenu == null) throw new OperationCanceledException();
            mb.AddSubmenu(submenu);
            Pause(" [+] Submenu added.");
        }

        private static void RemoveEntry(IMenuBuilder mb)
        {
            var children = mb.Children;
            if (children.Count == 0)
            {
                Console.WriteLine("(No entries to remove.)");
                return;
            }

            PrintChildren(mb);
            var input = ReadOrLogout("Enter number to remove (0 to cancel, L = logout): ");
            if (!int.TryParse(input, out var n) || n < 0 || n > children.Count)
            {
                Console.WriteLine("Invalid input.");
                return;
            }
            if (n == 0) return;

            var label = children[n - 1] is Menu m ? $"[Menu] {m.Name}" :
                        children[n - 1] is MenuItem mi ? $"{mi.Name} - {mi.DishType} ${mi.Price:0.00}" :
                        "(Unknown)";
            var yn = ReadOrLogout($"Remove \"{label}\"? (y/n, L=logout): ").Trim().ToLower();
            if (yn == "y")
            {
                if (mb.RemoveAt(n - 1)) Console.WriteLine("[-] Removed.");
                else Console.WriteLine("(Remove failed.)");
            }
            else
            {
                Console.WriteLine("Cancelled.");
            }
        }

        private static void PrintChildren(IMenuBuilder mb)
        {
            var children = mb.Children;
            Console.WriteLine("Current entries:");
            if (children.Count == 0)
            {
                Console.WriteLine("  (empty)");
                return;
            }
            for (int i = 0; i < children.Count; i++)
            {
                var c = children[i];
                if (c is Menu submenu)
                    Console.WriteLine($" {i + 1}. [Menu] {submenu.Name}");
                else if (c is MenuItem mi)
                    Console.WriteLine($" {i + 1}. {mi.Name} - {mi.DishType} ${mi.Price:0.00}");
                else
                    Console.WriteLine($" {i + 1}. (Unknown)");
            }
        }

        private static string PromptDishType()
        {
            string[] types = { "Main Course", "Side Dish", "Dessert", "Beverage" };
            Console.WriteLine(" Select Dish Type (L = logout):");
            for (int i = 0; i < types.Length; i++)
                Console.WriteLine($"  {i + 1}) {types[i]}");

            var s = ReadOrLogout(" Enter number: ");
            if (int.TryParse(s, out var n) && n >= 1 && n <= types.Length)
                return types[n - 1];

            Console.WriteLine(" Invalid choice, defaulting to 'Main Course'.");
            return "Main Course";
        }

        private static void Header(string title)
        {
            const int w = 44;
            var t = $" {title} ";
            var pad = Math.Max(0, (w - t.Length) / 2);
            Console.WriteLine(new string('=', w));
            Console.WriteLine(new string('=', pad) + t + new string('=', w - pad - t.Length));
            Console.WriteLine(new string('=', w));
            Console.WriteLine();
        }

        private static void Pause(string msg = "Press ENTER to continue… (or L to logout)")
        {
            Console.WriteLine();
            Console.WriteLine(msg);
            var s = Console.ReadLine();
            if (string.Equals(s, "l", StringComparison.OrdinalIgnoreCase))
                throw new OperationCanceledException();
        }

        private static string ReadOrLogout(string prompt)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            if (string.Equals(input, "l", StringComparison.OrdinalIgnoreCase))
                throw new OperationCanceledException();
            return input ?? "";
        }
    }
}

