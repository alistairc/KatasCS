namespace AntsWorld;

public class World : IDiscreteStepWorld
{
    readonly int _width;
    readonly int _height;
    int _counter;

    public World(int width, int height)
    {
        _width = width;
        _height = height;
    }

    public int GetState()
    {
        return _counter;
    }

    public void Step()
    {
        _counter++;
    }

    public IReadOnlyList<EntityType> EntitiesAt(WorldCoordinate coordinate)
    {
        return [];
    }
}