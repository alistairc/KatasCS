namespace Katas.BankChicago;

class Statement
{
    readonly IReadOnlyList<StatementLine> _statementLines;

    Statement(IReadOnlyList<StatementLine> statementLines, decimal closingBalance)
    {
        _statementLines = statementLines;
        ClosingBalance = closingBalance;
    }

    public decimal ClosingBalance { get; }

    public static Statement BuildFromTransactions(IEnumerable<Transaction> transactions)
    {
        var balance = 0m;
        var statementLines = transactions
            .Select(
                trans => new StatementLine(
                    trans.TransactionDate,
                    trans.Description,
                    trans.Amount,
                    balance += trans.Amount
                )
            )
            .OrderByDescending(sl => sl.Date)
            .ToArray();
        var closingBalance = balance;

        return new Statement(statementLines, closingBalance);
    }

    public IReadOnlyList<StatementLine> GetLines()
    {
        return _statementLines;
    }
}