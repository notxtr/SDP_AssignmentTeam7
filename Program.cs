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


}

static void RunCustomerUI()
{
    var UI = new UICustomer();
    var Customer = Graberroo.getInstance().getAccount();
    List<Restaurant> restaurants = Graberroo.getInstance().GetRestaurants;
    UI.Start(Customer, restaurants);

}
