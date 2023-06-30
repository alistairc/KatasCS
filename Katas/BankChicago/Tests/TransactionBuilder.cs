namespace Katas.BankChicago.Tests;

public class TransactionBuilder
{
    public DateOnly Date { get; init; } = new(2020, 12, 31);
    public decimal Amount { get; init; } = 123.45m;
    public string Description { get; init; } = "A transaction";
    
    public Transaction Build()
    {
        return new Transaction(Date, Description, Amount);
    }
}