namespace Katas.BankFakeIt;

public class Account
{
    readonly Deposit? _deposit;

    public Account(Deposit? deposit)
    {
        _deposit = deposit;
    }

    public Statement GetStatement()
    {
        return new Statement(_deposit);
    }
}