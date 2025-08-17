using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment_Team7
{
    internal class Graberroo
    {
        private static Graberroo unique;
        private List<Restaurant> restaurants;
        private List<Customer> customers;

        private Graberroo()
        {
            restaurants = new List<Restaurant>();
            customers = new List<Customer>();
        }

        public static Graberroo getInstance()
        {
            if (unique != null)
            {
                return unique;
            } else
            {
                unique = new Graberroo();
                return unique;
            }
        }

        public List<Restaurant> GetRestaurants
        {
            get { return  restaurants; }
            set { restaurants = value; }
        }

        public List<Customer> GetCustomers
        {
            get { return customers; }
            set { customers = value; }
        }

        public List<Restaurant> initializeData()
        {
            Menu breakfastMenu = new Menu("Breakfast Menu");

            // Themed submenus (can mix dish types; only leaf Dish.DishType must be one of the 4)
            Menu kidsMeals = new Menu("Kids Meals");
            Menu specials = new Menu("Specials");
            Menu freeMeals = new Menu("Free Meals");
            Menu sweetTooth = new Menu("Dessert Corner");
            Menu drinksBar = new Menu("Drinks Bar");
            Menu warmBites = new Menu("Warm Bites");

            // --- Kids Meals (mixed types) ---
            kidsMeals.add(new Dish("Kaya Toast Set (Kids)", "Half-portion toast + egg", "Main Course", 3.20));
            kidsMeals.add(new Dish("Mini Pancakes", "Small stack with syrup", "Dessert", 3.40));
            kidsMeals.add(new Dish("Orange Juice (Kids)", "Smaller cup", "Beverage", 1.80));

            // --- Specials (mixed types) ---
            specials.add(new Dish("Nasi Lemak (Mini)", "Coconut rice, ikan bilis, sambal, half egg", "Main Course", 4.20));
            specials.add(new Dish("Egg & Cheese Omelette", "Three-egg omelette with cheddar", "Main Course", 4.50));
            specials.add(new Dish("Hash Browns", "Crispy shredded potato patties", "Side Dish", 1.80));

            // --- Free Meals (sample freebies/combos) ---
            freeMeals.add(new Dish("Buttered Toast (Promo)", "Two slices with butter", "Side Dish", 0.00));
            freeMeals.add(new Dish("Brew of the Day (Promo)", "Limited-time morning coffee", "Beverage", 0.00));

            // --- Dessert Corner ---
            sweetTooth.add(new Dish("Banana Bread Slice", "Moist banana loaf slice", "Dessert", 2.00));
            sweetTooth.add(new Dish("Blueberry Muffin", "Buttery muffin with blueberries", "Dessert", 2.20));
            sweetTooth.add(new Dish("Pancakes", "Fluffy pancakes with maple syrup", "Dessert", 5.20));

            // --- Drinks Bar ---
            drinksBar.add(new Dish("Kopi O", "Black coffee, no sugar", "Beverage", 1.40));
            drinksBar.add(new Dish("Teh Tarik", "Pulled milk tea", "Beverage", 1.80));
            drinksBar.add(new Dish("Orange Juice", "Freshly squeezed OJ", "Beverage", 2.50));

            // --- Warm Bites (use Side Dish for soups to keep to 4 types) ---
            warmBites.add(new Dish("Tomato Soup (Cup)", "Fresh tomato and basil soup", "Side Dish", 3.20));
            warmBites.add(new Dish("Mushroom Soup", "Creamy button mushroom soup", "Side Dish", 3.20));

            // Nest submenus
            breakfastMenu.add(kidsMeals);
            breakfastMenu.add(specials);
            breakfastMenu.add(freeMeals);
            breakfastMenu.add(sweetTooth);
            breakfastMenu.add(drinksBar);
            breakfastMenu.add(warmBites);

            // ===== Example Restaurants with Menus =====

            // 1) KopiTiam Express (uses the Breakfast Menu above)
            Restaurant kopiTiam = new Restaurant("KopiTiam Express");
            kopiTiam.Menu = breakfastMenu;

            // 2) Western Diner (build a new menu quickly)
            Menu westernMenu = new Menu("Western All-Day");
            Menu wd_mains = new Menu("Mains");
            Menu wd_sides = new Menu("Sides");
            Menu wd_drinks = new Menu("Beverages");
            Menu wd_dessert = new Menu("Desserts");

            wd_mains.add(new Dish("Grilled Chicken", "Herb-seasoned breast with gravy", "Main Course", 9.50));
            wd_mains.add(new Dish("Fish & Chips", "Crispy battered fish, fries", "Main Course", 8.90));

            wd_sides.add(new Dish("Coleslaw", "Creamy slaw", "Side Dish", 2.20));
            wd_sides.add(new Dish("Garlic Bread", "Toasted with garlic butter", "Side Dish", 2.00));

            wd_drinks.add(new Dish("Latte", "Espresso with steamed milk", "Beverage", 3.50));
            wd_drinks.add(new Dish("Iced Lemon Tea", "Refreshing black tea with lemon", "Beverage", 2.20));

            wd_dessert.add(new Dish("Chocolate Cake", "Rich layered cake", "Dessert", 3.80));
            wd_dessert.add(new Dish("Apple Pie", "Classic cinnamon apple pie", "Dessert", 3.40));

            westernMenu.add(wd_mains);
            westernMenu.add(wd_sides);
            westernMenu.add(wd_drinks);
            westernMenu.add(wd_dessert);

            Restaurant westernDiner = new Restaurant("Western Diner");
            westernDiner.Menu = westernMenu;

            // 3) Veggie Corner (another example)
            Menu veggieMenu = new Menu("Veggie Highlights");
            Menu vc_mains = new Menu("Plant Mains");
            Menu vc_sides = new Menu("Light Sides & Soups");
            Menu vc_drinks = new Menu("Cold Pressed");
            Menu vc_sweets = new Menu("Sweet Bites");

            vc_mains.add(new Dish("Vegan Burger", "Plant-based patty, lettuce, tomato", "Main Course", 7.50));
            vc_mains.add(new Dish("Mushroom Risotto", "Creamy arborio with mushrooms", "Main Course", 8.20));

            vc_sides.add(new Dish("Tomato Basil Soup", "Fresh tomato & basil", "Side Dish", 3.10));
            vc_sides.add(new Dish("Garden Salad", "Mixed greens, vinaigrette", "Side Dish", 3.00));

            vc_drinks.add(new Dish("Cold Pressed Orange", "No sugar added", "Beverage", 3.20));
            vc_drinks.add(new Dish("Iced Matcha", "Lightly sweetened", "Beverage", 2.90));

            vc_sweets.add(new Dish("Chia Pudding", "Coconut milk, berries", "Dessert", 3.30));
            vc_sweets.add(new Dish("Brownie Bite", "Dark chocolate", "Dessert", 2.10));

            veggieMenu.add(vc_mains);
            veggieMenu.add(vc_sides);
            veggieMenu.add(vc_drinks);
            veggieMenu.add(vc_sweets);

            Restaurant veggieCorner = new Restaurant("Veggie Corner");
            veggieCorner.Menu = veggieMenu;

            kopiTiam.setOffer(new FixedOffer(10, "School holidays Offer"));
            westernDiner.setOffer(new PercentageOffer(0.5, "Black Friday Sale"));

            // ===== Example: display them =====
            List<Restaurant> sampleRestaurants = new List<Restaurant> { kopiTiam, westernDiner, veggieCorner };
            Graberroo.getInstance().GetRestaurants.AddRange(sampleRestaurants);

            return sampleRestaurants;
        }

        public Customer getAccount()
        {
            // Create example customer
            Customer customer = new Customer("John Tan");

            // Create some example restaurants with menus
            Restaurant rest1 = new Restaurant("Kopi House");
            Restaurant rest2 = new Restaurant("Nasi Padang Express");

            // Add example offers
            rest1.setOffer(new FixedOffer(20, "Christmas $20 off Discount"));
            rest2.setOffer(new PercentageOffer(0.2, "National Day 20% Off Discount"));

            // Link customer to restaurant notifications
            customer.addNotification(rest1);
            customer.addNotification(rest2);

            // Create example menus for restaurants
            Menu kopiMenu = new Menu("Breakfast Menu");
            kopiMenu.add(new Dish("Kaya Toast Set", "Kaya butter toast + soft boiled eggs", "Main Course", 3.80));
            kopiMenu.add(new Dish("Kopi O", "Black coffee", "Beverage", 1.40));
            rest1.Menu = kopiMenu;

            Menu nasiMenu = new Menu("Lunch Menu");
            nasiMenu.add(new Dish("Nasi Lemak", "Coconut rice with sambal and egg", "Main Course", 4.50));
            nasiMenu.add(new Dish("Teh Tarik", "Pulled milk tea", "Beverage", 1.80));
            rest2.Menu = nasiMenu;

            // Example previous orders
            Cart previousOrder1 = new Cart();
            previousOrder1.AddItem(new OrderItem((MenuItem)kopiMenu.getChild(1), 1));
            previousOrder1.AddItem(new OrderItem((MenuItem)kopiMenu.getChild(0), 1));

            Cart previousOrder2 = new Cart();
            previousOrder2.AddItem(new OrderItem((MenuItem)nasiMenu.getChild(0), 1));
            previousOrder2.AddItem(new OrderItem((MenuItem)nasiMenu.getChild(1), 1));

            Order order1 = new NormalOrder(previousOrder1, customer);
            Order order2 = new NormalOrder(previousOrder2, customer);

            // Store previous orders in customer (if you have a list in Customer)
            // Assuming we add a PreviousOrders property to Customer
            customer.AddOrder(order1);
            customer.AddOrder(order2);

            return customer;
        }
    }
}
