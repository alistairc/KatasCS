namespace AntsWorld;

class World : IDiscreteStepWorld
{
    int _counter;

    public int GetState()
    {
        return _counter;
    }

    public void Step()
    {
        _counter++;
    }
}