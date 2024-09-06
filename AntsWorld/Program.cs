Console.Clear();

var state = 0;
while (true)
{
    var displayModel = MakeModel(state);
    RenderModel(displayModel);
    await Task.Delay(TimeSpan.FromMilliseconds(250));
    state++;
}
return;

void RenderModel(string[] strings)
{
    Console.SetCursorPosition(0, 0);
    foreach (var line in strings)
    {
        Console.WriteLine(line);
    }
}

string[] MakeModel(int state)
{
    const int displayHeight = 25;
    const int displayWidth = 100;
    var displayModel = new string[displayHeight];
    var blankLine = new string(' ', displayWidth);
    Array.Fill(displayModel, blankLine);
    displayModel[state % displayHeight]=new string('X', displayWidth);
    return displayModel;
}
