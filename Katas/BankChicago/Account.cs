namespace Katas.BankChicago;

class Account
{
    readonly ITransactionRepository _transactionRepository;

    public Account(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public void MakeTransaction(Transaction transaction)
    {
        _transactionRepository.Add(transaction);
    }

    public Statement GetStatement()
    {
        return Statement.BuildFromTransactions(_transactionRepository.GetTransactions());
    }
}