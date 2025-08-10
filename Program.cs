// See https://aka.ms/new-console-template for more information
using SDP_Assignment_Team7;

//Console.WriteLine("Hello, World!");

//Customer cust = new Customer("John");
//Restaurant rest = new Restaurant("Anything");

//rest.addCustomer(cust);

//rest.setOffer(new FixedOffer(10, "Testing"));

// ---- Breakfast items ----
Menu breakfastMenu = new Menu("Breakfast Menu");

// Submenus by Dish Type
Menu mainCourses = new Menu("Kids Meals");
Menu sideDishes = new Menu("Specials");
Menu appetizers = new Menu("Free Meals");
Menu desserts = new Menu("Dessert");
Menu beverages = new Menu("Beverage");
Menu soups = new Menu("Soup");

// --- Main Courses ---
mainCourses.add(new Dish("Kaya Toast Set", "Kaya butter toast with soft-boiled eggs", "Beverage", 3.80));
mainCourses.add(new Dish("Nasi Lemak (Mini)", "Coconut rice, ikan bilis, sambal, half egg", "Main Course", 4.20));
mainCourses.add(new Dish("Egg & Cheese Omelette", "Three-egg omelette with cheddar", "Main Course", 4.50));
mainCourses.add(new Dish("Pancakes", "Fluffy pancakes with maple syrup", "Main Course", 5.20));
mainCourses.add(new Dish("Pancakes (Mini)", "Small stack with syrup", "Main Course", 3.40));

// --- Side Dishes ---
sideDishes.add(new Dish("Ikan Bilis & Peanuts", "Crunchy anchovies with peanuts", "Side Dish", 1.50));
sideDishes.add(new Dish("Hash Browns", "Crispy shredded potato patties", "Beverage", 1.80));
sideDishes.add(new Dish("Buttered Toast", "Two slices with butter", "Side Dish", 1.20));

// --- Appetizers ---
appetizers.add(new Dish("Otah Bites", "Spicy fish paste grilled in banana leaf", "Beverage", 2.20));
appetizers.add(new Dish("Fruit Cup", "Seasonal mixed fruit", "Appetizer", 2.50));
appetizers.add(new Dish("Yogurt Parfait", "Yogurt layered with granola & berries", "Appetizer", 2.80));

// --- Desserts ---
desserts.add(new Dish("Banana Bread Slice", "Moist banana loaf slice", "Beverage", 2.00));
desserts.add(new Dish("Blueberry Muffin", "Buttery muffin with blueberries", "Dessert", 2.20));

// --- Beverages ---
beverages.add(new Dish("Kopi O", "Black coffee, no sugar", "Beverage", 1.40));
beverages.add(new Dish("Teh Tarik", "Pulled milk tea", "Beverage", 1.80));
beverages.add(new Dish("Orange Juice", "Freshly squeezed OJ", "Beverage", 2.50));

// --- Soups ---
soups.add(new Dish("Tomato Soup (Cup)", "Fresh tomato and basil soup", "Soup", 3.20));
soups.add(new Dish("Mushroom Soup", "Creamy button mushroom soup", "Beverage", 3.20));

// Nest dish-type submenus under Breakfast Menu
breakfastMenu.add(mainCourses);
breakfastMenu.add(sideDishes);
breakfastMenu.add(appetizers);
breakfastMenu.add(desserts);
breakfastMenu.add(beverages);
breakfastMenu.add(soups);

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
{
    Console.Clear();
    breakfastMenu.print("type");
}

Console.ReadKey();
breakfastMenu.print("");