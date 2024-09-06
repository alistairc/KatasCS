namespace AntsWorld;

class ConsoleGame
{
    public async Task RunUntilKeyPress<TWorld>(IProjector<TWorld> projector, TWorld world)
        where TWorld : IDiscreteStepWorld
    {
        Console.Clear();
        while (!Console.KeyAvailable)
        {
            var displayModel = projector.Project(world);
            RenderModel(displayModel);
            await Task.Delay(TimeSpan.FromMilliseconds(250));
            world.Step();
        }
    }

    static void RenderModel(string[] strings)
    {
        Console.SetCursorPosition(0, 0);
        foreach (var line in strings) { Console.WriteLine(line); }
    }
}