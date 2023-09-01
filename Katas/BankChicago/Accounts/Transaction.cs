namespace Katas.BankChicago.Accounts;

public record Transaction(DateOnly TransactionDate, string Description, decimal Amount);