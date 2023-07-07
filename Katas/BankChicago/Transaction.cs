namespace Katas.BankChicago;

//TODO: Shouldn't be public
public record Transaction(DateOnly TransactionDate, string Description, decimal Amount);