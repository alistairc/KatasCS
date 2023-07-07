namespace Katas.BankChicago;

class InMemoryTransactionRepository : ITransactionRepository
{
    readonly List<Transaction> _transactions = new();

    public void Add(Transaction transaction)
    {
        _transactions.Add(transaction);
    }

    public IEnumerable<Transaction> GetTransactions()
    {
        return _transactions;
    }
}