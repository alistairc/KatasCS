namespace Katas.BankChicago.Hexagon;

public record Transaction(DateOnly TransactionDate, string Description, decimal Amount);