namespace Katas.BankChicago;

public class Statement
{
    readonly IEnumerable<Transaction> _transactions;

    public Statement(IEnumerable<Transaction> transactions)
    {
        _transactions = transactions;
    }

    public IReadOnlyList<StatementLine> GetLines()
    {
        var balance = 0m;
        return _transactions.Select(trans => new StatementLine(
                trans.TransactionDate,
                trans.Description,
                trans.Amount,
                balance += trans.Amount
            ))
            .OrderByDescending(sl => sl.Date)
            .ToArray();
    }
}