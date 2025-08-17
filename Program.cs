// See https://aka.ms/new-console-template for more information
using SDP_Assignment_Team7;

Graberroo.getInstance().initializeData();
var Customer = Graberroo.getInstance().getAccount();


while (true)
{


    Console.Clear();
Console.WriteLine("=== Welcome to Grabberoo! ===");
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

static void RunRestaurantUI()
{
    var ui = new UIRestaurant();

    while (true)
    {
        Console.Clear();
        Console.WriteLine("=== Restaurant Owner Menu ===");
        Console.WriteLine("1) Create New Restaurant");
        Console.WriteLine("2) Manage Existing Restaurant");
        Console.WriteLine("0) Back to Main Menu");
        Console.Write("Choose option: ");

        var choice = Console.ReadLine()?.Trim();

        if (choice == "0") break;

        switch (choice)
        {
            case "1":
                var newRestaurant = ui.CreateRestaurant();
                if (newRestaurant != null)
                {
                    Console.WriteLine($"\nSuccessfully created {newRestaurant.Name}!");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadLine();
                }
                break;

            case "2":
                if (Graberroo.getInstance().GetRestaurants.Count == 0)
                {
                    Console.WriteLine("\nNo restaurants exist yet. Create one first!");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadLine();
                    continue;
                }
                ui.LoginAndManageRestaurant();
                break;

            default:
                Console.WriteLine("Invalid choice. Press ENTER to try again...");
                Console.ReadLine();
                break;
        }
    }


}

 void RunCustomerUI()
{
    var UI = new UICustomer();
    List<Restaurant> restaurants = Graberroo.getInstance().GetRestaurants;
    UI.Start(Customer, restaurants);

}
