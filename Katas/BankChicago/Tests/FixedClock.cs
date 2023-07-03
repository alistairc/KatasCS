namespace Katas.BankChicago.Tests;

class FixedClock : IClock
{
    readonly DateOnly _date;

    public FixedClock(DateOnly date)
    {
        _date = date;
    }

    public DateOnly GetDate()
    {
        return _date;
    }
}