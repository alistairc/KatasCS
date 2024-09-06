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
        
        var block1 = new BlockEntity();
        var block1Location = new WorldCoordinate(1, 2);
        
        var block2 = new BlockEntity();
        var block2Location = new WorldCoordinate(2, 3);
        
        world.Add(block1, block1Location);
        world.Add(block2, block2Location);
        
        Assert.Multiple(() =>
        {
            Assert.That(world.EntitiesAt(block1Location), Is.EqualTo(new [] {EntityType.Block}));
            Assert.That(world.EntitiesAt(block2Location), Is.EqualTo(new [] {EntityType.Block}));
            
            Assert.That(world.GetLocation(block1), Is.EqualTo(block1Location));
            Assert.That(world.GetLocation(block2), Is.EqualTo(block2Location));
            
            Assert.That(AllWorldCoordinates.Except([block1Location, block2Location]).Select(world.EntitiesAt), Has.All.Empty);
        });
    }

    [Test]
    public void EntitiesCanBeAtTheSameLocation()
    {
        var world = new World(Width, Height);
        var location = new WorldCoordinate(1, 2);

        var block1 = new BlockEntity();
        var block2 = new BlockEntity();
        world.Add(block1, location);
        world.Add(block2, location);
        
        Assert.That(world.EntitiesAt(location), Is.EqualTo(new [] {EntityType.Block, EntityType.Block}));
        Assert.That(world.GetLocation(block1), Is.EqualTo(location));
        Assert.That(world.GetLocation(block2), Is.EqualTo(location));
    }

    static IEnumerable<WorldCoordinate> AllWorldCoordinates 
        => from x in Enumerable.Range(0, Width) 
           from y in Enumerable.Range(0, Height) 
           select new WorldCoordinate(x, y);
}

