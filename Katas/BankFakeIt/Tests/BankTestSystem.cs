namespace Katas.BankFakeIt.Tests;

class BankTestSystem
{
    readonly Account _account;

    public BankTestSystem()
    {
        _account = new Account(null);
    }

    BankTestSystem(Account account)
    {
        _account = account;
    }

    public BankTestSystem Deposit(Deposit deposit)
    {
        return new BankTestSystem(new Account(deposit));
    }

    public string GetStatementText()
    {
        return _account.GetStatement().FormatAsText();
    }
}