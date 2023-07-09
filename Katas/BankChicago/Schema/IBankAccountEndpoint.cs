namespace Katas.BankChicago.Schema;

public interface IBankAccountEndpoint
{
    void Deposit(decimal amount);
    void Withdraw(decimal amount);
    IReadOnlyList<string> GetTextStatement();
}