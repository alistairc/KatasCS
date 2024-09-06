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
    
    [Test]
    public void WorldCanContainEntitiesAtDifferentLocations()
    {
        var world = new World(Width, Height);
        var block1Location = new WorldCoordinate(1, 2);
        var block2Location = new WorldCoordinate(2, 3);
        world.Add(new BlockEntity(), block1Location);
        world.Add(new BlockEntity(), block2Location);
        
        Assert.Multiple(() =>
        {
            Assert.That(world.EntitiesAt(block1Location), Is.EqualTo(new [] {EntityType.Block}));
            Assert.That(world.EntitiesAt(block2Location), Is.EqualTo(new [] {EntityType.Block}));
            Assert.That(AllWorldCoordinates.Except([block1Location, block2Location]).Select(world.EntitiesAt), Has.All.Empty);
        });
    }

    [Test]
    public void EntitiesCanBeAtTheSameLocation()
    {
        var world = new World(Width, Height);
        var location = new WorldCoordinate(1, 2);
        
        world.Add(new BlockEntity(), location);
        world.Add(new BlockEntity(), location);
        
        Assert.That(world.EntitiesAt(location), Is.EqualTo(new [] {EntityType.Block, EntityType.Block}));
    }

    static IEnumerable<WorldCoordinate> AllWorldCoordinates 
        => from x in Enumerable.Range(0, Width) 
           from y in Enumerable.Range(0, Height) 
           select new WorldCoordinate(x, y);
}

