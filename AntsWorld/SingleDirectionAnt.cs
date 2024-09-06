namespace AntsWorld;

public class SingleDirectionAnt : IWorldEntity
{
    readonly Direction _direction;

    public SingleDirectionAnt(Direction direction)
    {
        _direction = direction;
    }

    public EntityType GetEntityType()
    {
        return EntityType.Block;
    }

    public void Act(IEntityActions actions)
    {
        actions.TryMove(_direction);
    }
}