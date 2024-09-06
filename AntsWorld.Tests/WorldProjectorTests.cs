namespace AntsWorld.Tests;

public class WorldProjectorTests
{
    const int DisplayWidth = 10;
    const int DisplayHeight = 5;

    [Test]
    public void ProjectingAnEmptyWorldProducesEmptyLines()
    {
        var projector = new WorldProjector(DisplayWidth, DisplayHeight);
        
        var lines = projector.Project(new World(DisplayWidth, DisplayHeight));

        Assert.Multiple(() => {
            Assert.That(lines, Has.Length.EqualTo(DisplayHeight));
            Assert.That(lines, Has.All.Length.EqualTo(DisplayWidth));
            Assert.That(lines, Has.All.All.EqualTo(' ')); // All.All here means every char of every line
        });
    }

    [Test]
    public void DisplaysLetterBForBlock()
    {
        var projector = new WorldProjector(DisplayWidth, DisplayHeight);
        var world = new World(DisplayWidth, DisplayHeight);
        world.Add(new BlockEntity(), new WorldCoordinate(8, 3));
        
        var lines = projector.Project(world);
        
        Assert.Multiple(() => {
            Assert.That(lines[1][8], Is.EqualTo('B'));

            Assert.That(lines[0][8], Is.EqualTo(' '));
            Assert.That(lines[2][8], Is.EqualTo(' '));
            Assert.That(lines[3][8], Is.EqualTo(' '));

            Assert.That(lines[1][7], Is.EqualTo(' '));
            Assert.That(lines[1][9], Is.EqualTo(' '));
        });
    }

    [Test]
    public void BottomLeftIsZeroZero()
    {
        var projector = new WorldProjector(DisplayWidth, DisplayHeight);
        var world = new World(DisplayWidth, DisplayHeight);
        world.Add(new BlockEntity(), new WorldCoordinate(0, 0));
        
        var lines = projector.Project(world);
        
        Assert.That(lines[4][0], Is.EqualTo('B'));
    }
}