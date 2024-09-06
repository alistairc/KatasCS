namespace AntsWorld;

public class World : IDiscreteStepWorld
{
    readonly int _width;
    readonly int _height;

    readonly List<(IWorldEntity entity, WorldCoordinate location)> _entityLocations = new(); 
    
    public World(int width, int height)
    {
        _width = width;
        _height = height;
    }

    public void Step()
    {
    }

    public IReadOnlyList<EntityType> EntitiesAt(WorldCoordinate coordinate)
    {
        return _entityLocations
            .Where(el => el.location == coordinate)
            .Select(el => el.entity.GetEntityType()).ToArray();
    }

    public void Add(IWorldEntity entity, WorldCoordinate coordinate)
    {
        _entityLocations.Add((entity, coordinate));
    }
}