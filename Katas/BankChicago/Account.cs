namespace Katas.BankChicago;

public class Account
{
    readonly List<Transaction> _transactions = new();

    public void MakeTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
    }

    public Statement GetStatement()
    {
        return Statement.BuildFromTransactions(_transactions);
    }
}