namespace Katas.BankChicago;

//TODO: shouldn't be public
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