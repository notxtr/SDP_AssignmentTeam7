// See https://aka.ms/new-console-template for more information
using SDP_Assignment_Team7;

Graberroo.getInstance().initializeData();


while (true)
{
    Console.Clear();
    Console.WriteLine("=== System Menu ===");
    Console.WriteLine("1) Restaurant UI (Create & Manage Restaurant)");
    Console.WriteLine("2) Customer UI (Browse & Place Orders)");
    Console.WriteLine("0) Exit");
    Console.Write("Choose option: ");

    var choice = Console.ReadLine()?.Trim();

    if (choice == "0") break;

    switch (choice)
    {
        case "1":
            RunRestaurantUI();
            break;
        case "2":
            RunCustomerUI();
            break;
        default:
            Console.WriteLine("Invalid choice. Press ENTER to try again...");
            Console.ReadLine();
            break;
    }
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

    // ===== Appetizer (Fruit Cup, Yogurt Parfait, etc.) =====
    new ToppingOption("Extra Dip",       0.30, "Appetizer"),
    new ToppingOption("Add Nuts",        0.50, "Appetizer"),
    new ToppingOption("Extra Greens",    0.50, "Appetizer"),
    new ToppingOption("No Dressing",     0.00, "Appetizer"),
    new ToppingOption("Honey Drizzle",   0.40, "Appetizer"),
    new ToppingOption("Extra Granola",   0.60, "Appetizer"),

    // ===== Dessert (Banana Bread Slice, Blueberry Muffin) =====
    new ToppingOption("Warm It Up",      0.00, "Dessert"),
    new ToppingOption("Extra Syrup",     0.30, "Dessert"),
    new ToppingOption("Add Ice Cream",   1.00, "Dessert"),
    new ToppingOption("Whipped Cream",   0.50, "Dessert"),
    new ToppingOption("Add Berries",     0.70, "Dessert"),
    new ToppingOption("Chocolate Chips", 0.50, "Dessert"),
    new ToppingOption("Less Sweet",      0.00, "Dessert"),

    // ===== Soup (Tomato Soup, Mushroom Soup) =====
    new ToppingOption("Extra Croutons",  0.40, "Soup"),
    new ToppingOption("Add Bread Roll",  0.80, "Soup"),
    new ToppingOption("Extra Cream",     0.50, "Soup"),
    new ToppingOption("Large Bowl",      1.20, "Soup"),
    new ToppingOption("Less Salt",       0.00, "Soup"),
    new ToppingOption("Add Cheese",      0.80, "Soup"),
};

List<MenuItem> Orderables = new List<MenuItem>();

// --- Main Courses ---
Dish m1 = new Dish("Kaya Toast Set", "Kaya butter toast with soft-boiled eggs", "Main Course", 3.80);
mainCourses.add(m1); Orderables.Add(m1);

Dish m2 = new Dish("Nasi Lemak (Mini)", "Coconut rice, ikan bilis, sambal, half egg", "Main Course", 4.20);
mainCourses.add(m2); Orderables.Add(m2);

Dish m3 = new Dish("Egg & Cheese Omelette", "Three-egg omelette with cheddar", "Main Course", 4.50);
mainCourses.add(m3); Orderables.Add(m3);

Dish m4 = new Dish("Pancakes", "Fluffy pancakes with maple syrup", "Main Course", 5.20);
mainCourses.add(m4); Orderables.Add(m4);

Dish m5 = new Dish("Pancakes (Mini)", "Small stack with syrup", "Main Course", 3.40);
mainCourses.add(m5); Orderables.Add(m5);

// --- Side Dishes ---
Dish s1 = new Dish("Ikan Bilis & Peanuts", "Crunchy anchovies with peanuts", "Side Dish", 1.50);
sideDishes.add(s1); Orderables.Add(s1);

Dish s2 = new Dish("Hash Browns", "Crispy shredded potato patties", "Side Dish", 1.80);
sideDishes.add(s2); Orderables.Add(s2);

Dish s3 = new Dish("Buttered Toast", "Two slices with butter", "Side Dish", 1.20);
sideDishes.add(s3); Orderables.Add(s3);

// --- Appetizers ---
Dish a1 = new Dish("Otah Bites", "Spicy fish paste grilled in banana leaf", "Appetizer", 2.20);
appetizers.add(a1); Orderables.Add(a1);

Dish a2 = new Dish("Fruit Cup", "Seasonal mixed fruit", "Appetizer", 2.50);
appetizers.add(a2); Orderables.Add(a2);

Dish a3 = new Dish("Yogurt Parfait", "Yogurt layered with granola & berries", "Appetizer", 2.80);
appetizers.add(a3); Orderables.Add(a3);

// --- Desserts ---
Dish d1 = new Dish("Banana Bread Slice", "Moist banana loaf slice", "Dessert", 2.00);
desserts.add(d1); Orderables.Add(d1);

Dish d2 = new Dish("Blueberry Muffin", "Buttery muffin with blueberries", "Dessert", 2.20);
desserts.add(d2); Orderables.Add(d2);

// --- Beverages ---
Dish b1 = new Dish("Kopi O", "Black coffee, no sugar", "Beverage", 1.40);
beverages.add(b1); Orderables.Add(b1);

Dish b2 = new Dish("Teh Tarik", "Pulled milk tea", "Beverage", 1.80);
beverages.add(b2); Orderables.Add(b2);

Dish b3 = new Dish("Orange Juice", "Freshly squeezed OJ", "Beverage", 2.50);
beverages.add(b3); Orderables.Add(b3);
static void RunRestaurantUI()
{
    var UI = new UIRestaurant();
    var restaurant = UI.CreateRestaurant();
    Console.Clear();
    if (restaurant != null)
    {
        //UI.ManageRestaurant(restaurant);
        Console.WriteLine("Added!");
    }

// --- Soups ---
Dish sp1 = new Dish("Tomato Soup (Cup)", "Fresh tomato and basil soup", "Soup", 3.20);
soups.add(sp1); Orderables.Add(sp1);

Dish sp2 = new Dish("Mushroom Soup", "Creamy button mushroom soup", "Soup", 3.20);
soups.add(sp2); Orderables.Add(sp2);


}

MenuItem ConfigureToppingsForDish(MenuItem baseDish)
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

    List<int> selectedIndices = new List<int>(); // store indices into "options"
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
void OrderFlow()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("==== ORDER ====");
        for (int i = 0; i < Orderables.Count; i++)
        {
            Console.WriteLine((i + 1) + ") " + Orderables[i].Name + " - $" + Orderables[i].Price.ToString("0.00") + " (" + Orderables[i].DishType + ")");
        }
        Console.WriteLine("0) Exit ordering");
        Console.Write("\nSelect a dish by number: ");

        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice)) continue;
        if (choice == 0) break;
        if (choice < 1 || choice > Orderables.Count) continue;

        MenuItem baseDish = Orderables[choice - 1];
        MenuItem finalDish = ConfigureToppingsForDish(baseDish);

        Console.WriteLine();
        Console.WriteLine("You ordered: " + finalDish.getDescription());
        Console.WriteLine("Final Price: $" + finalDish.getPrice().ToString("0.00"));
        Console.WriteLine("\nPress ENTER to continue ordering...");
        Console.ReadLine();
    }
}


breakfastMenu.print("");
Console.WriteLine("Choose a filter: ");
Console.WriteLine("1) Filter By Price (Lowest - Highest)");
Console.WriteLine("2) Filter By Dish Type");
int choice = Convert.ToInt32(Console.ReadLine());
if (choice == 1)
{
    Console.Clear();
    breakfastMenu.print("budget");
} else if (choice == 2)
static void RunCustomerUI()
{
    var UI = new UICustomer();
    var Customer = Graberroo.getInstance().getAccount();
    List<Restaurant> restaurants = Graberroo.getInstance().GetRestaurants;
    UI.Start(Customer, restaurants);

}

Console.ReadKey();
breakfastMenu.print("");
Console.WriteLine("\nPress ENTER to go to ordering...");
Console.ReadLine();
OrderFlow();
