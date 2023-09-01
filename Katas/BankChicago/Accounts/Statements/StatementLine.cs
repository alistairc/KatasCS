namespace Katas.BankChicago.Accounts.Statements;

record StatementLine(DateOnly Date, string Description, decimal Amount, decimal Balance)
{
    public bool IsDeposit()
    {
        return Amount > 0;
    }
}