namespace Katas.BankChicago;

record StatementLine(DateOnly Date, string Description, decimal Amount, decimal Balance)
{
    public bool IsDeposit()
    {
        return Amount > 0;
    }
}