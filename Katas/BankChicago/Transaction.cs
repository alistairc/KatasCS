namespace Katas.BankChicago;

public record Transaction(DateOnly TransactionDate, string Description, decimal Amount);
