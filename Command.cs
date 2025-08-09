using System;

internal interface Command
{
    public void execute();
    public void undo();

}
