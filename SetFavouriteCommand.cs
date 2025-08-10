using System;

internal class SetFavouriteCommand : Command
{
    private FavouriteOrder myOrder;

    public SetFavouriteCommand(FavouriteOrder order)
    {
        this.myOrder = order;
    }
    public void execute()
    {
        FavouriteOrder.addToFavourite();
    }

    public void undo()
    {
        Console.WriteLine($"Undoing favourite command");
    }
}
