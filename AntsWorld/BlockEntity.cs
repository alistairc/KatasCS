namespace AntsWorld;

public class BlockEntity : IWorldEntity
{
    public EntityType GetEntityType() => EntityType.Block;
}