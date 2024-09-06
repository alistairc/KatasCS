namespace AntsWorld.Tests;

public class WorldTests
{
    const int Width = 5;
    const int Height = 5;

    [Test]
    public void EmptyWorld_ShouldHaveNoEntities()
    {
        var world = new World(Width, Height);
        
        Assert.That(AllWorldCoordinates.Select(world.EntitiesAt), Has.All.Empty);
    }

    static IEnumerable<WorldCoordinate> AllWorldCoordinates 
        => from x in Enumerable.Range(0, Width) 
           from y in Enumerable.Range(0, Height) 
           select new WorldCoordinate(x, y);
    
}