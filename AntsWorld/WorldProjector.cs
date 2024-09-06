namespace AntsWorld;

public class WorldProjector : IProjector<World>
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
        
        for (var lineNumber = 0;lineNumber < _displayHeight;  lineNumber++)
        {
            displayModel[lineNumber] = BuildLine(world, lineNumber);
        }
        
        return displayModel;
    }

    string BuildLine(World world, int lineNumber)
    {
        var chars = new char[_displayWidth];
        Array.Fill(chars, ' ');
            
        var y = (_displayHeight - 1) - lineNumber;
        for (var columnNumber = 0;columnNumber < _displayWidth;  columnNumber++)
        {
            var coord = new WorldCoordinate(columnNumber, y);
            var entities = world.EntitiesAt(coord);
            foreach (var entityType in entities)
            {
                chars[columnNumber] = 'B';
            }
        }
        var line = new string(chars);
        return line;
    }
}