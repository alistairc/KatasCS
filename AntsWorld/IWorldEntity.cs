namespace AntsWorld;

public interface IWorldEntity
{
    EntityType GetEntityType();
    void Act(IEntityActions actions);
}