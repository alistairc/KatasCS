namespace Katas.BankChicago;

public interface ITransactionRepository
{
    void Add(Transaction transaction);
    IEnumerable<Transaction> GetTransactions();
}