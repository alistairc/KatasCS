namespace Katas.BankChicago.Hexagon;

public interface ITransactionRepository
{
    void Add(Transaction transaction);
    IEnumerable<Transaction> GetTransactions();
}