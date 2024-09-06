namespace AntsWorld.Tests;

public class EntityMovementTests
{
    const int Width = 5;
    const int Height = 5;

    [Test]
    public void EntitiesCanMoveInTheWorld()
    {
        var world = new World(Width,Height);
        var ant = new SingleDirectionAnt(Direction.Right);
        world.Add(ant, new WorldCoordinate(0,2));
        
        Assert.That(world.GetLocation(ant), Is.EqualTo(new WorldCoordinate(0,2)));
        world.Step();
        Assert.That(world.GetLocation(ant), Is.EqualTo(new WorldCoordinate(1,2)));
        world.Step();
        Assert.That(world.GetLocation(ant), Is.EqualTo(new WorldCoordinate(2,2)));
    }
}