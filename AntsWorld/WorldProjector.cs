namespace AntsWorld;

class WorldProjector : IProjector<World>
{
    readonly int _displayHeight;
    readonly int _displayWidth;

    public WorldProjector(int displayWidth, int displayHeight)
    {
        _displayWidth = displayWidth;
        _displayHeight = displayHeight;
    }

    public string[] Project(World world)
    {
        var displayModel = new string[_displayHeight];
        var blankLine = new string(' ', _displayWidth);
        Array.Fill(displayModel, blankLine);
        displayModel[world.GetState() % _displayHeight] = new string('X', _displayWidth);
        return displayModel;
    }
}