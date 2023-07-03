namespace Katas.BankChicago;

class BankAccountEndpoint
{
    readonly Account _account;
    readonly IClock _clock;

    public BankAccountEndpoint(IClock clock, Account account)
    {
        _clock = clock;
        _account = account;
    }

    public void Deposit(decimal amount)
    {
        _account.MakeTransaction(new Transaction(_clock.GetDate(), "Deposit", amount));
    }

    public void Withdraw(decimal amount)
    {
        _account.MakeTransaction(new Transaction(_clock.GetDate(), "Withdrawal", -amount));
    }

    public IReadOnlyList<string> GetTextStatement()
    {
        return TextStatementFormat.Format(_account.GetStatement());
    }
}