namespace Katas.BankFakeIt.Tests;

class BankTestSystem
{
    readonly Deposit? _deposit;

    public BankTestSystem()
    {
    }

    BankTestSystem(Deposit deposit)
    {
        _deposit = deposit;
    }

    public BankTestSystem Deposit(Deposit deposit)
    {
        return new BankTestSystem(deposit);
    }

    public string GetStatementText()
    {
        var statement = new Statement(_deposit);
        return statement.FormatAsText();
    }
}