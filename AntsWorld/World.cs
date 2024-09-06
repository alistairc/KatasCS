namespace AntsWorld;

public class World : IDiscreteStepWorld
{
    readonly int _width;
    readonly int _height;

    class EntityLocation(IWorldEntity entity, WorldCoordinate location)
    {
        public IWorldEntity Entity { get; } = entity;
        public WorldCoordinate Location { get; set; } = location;
    }

    readonly List<EntityLocation> _entityLocations = new(); 
    
    public World(int width, int height)
    {
        _width = width;
        _height = height;
    }

    public void Step()
    {
        foreach (var entityLocation in _entityLocations)
        {
            entityLocation.Entity.Act(new Action(entityLocation));
        }
    }

    class Action(EntityLocation entityLocation) : IEntityActions
    {
        public bool TryMove(Direction direction)
        {
            entityLocation.Location = entityLocation.Location with { X = entityLocation.Location.X + 1 };
            return true;
        }
    } 

    public IReadOnlyList<EntityType> EntitiesAt(WorldCoordinate location)
    {
        return _entityLocations
            .Where(el => el.Location == location)
            .Select(el => el.Entity.GetEntityType()).ToArray();
    }

    public void Add(IWorldEntity entity, WorldCoordinate location)
    {
        _entityLocations.Add(new EntityLocation(entity,location));
    }

    public WorldCoordinate GetLocation(IWorldEntity entity)
    {
        return _entityLocations.First(el => el.Entity == entity).Location;
    }
}