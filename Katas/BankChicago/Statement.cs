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
        return _transactions.Select(
                trans => new StatementLine(
                    trans.TransactionDate,
                    trans.Description,
                    trans.Amount
                )
            )
            .OrderByDescending(sl => sl.Date)
            .ToArray();
    }
}