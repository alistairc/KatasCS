namespace Katas.BankChicago.Accounts;

public interface ITransactionRepository
{
    void Add(Transaction transaction);
    IEnumerable<Transaction> GetTransactions();
}