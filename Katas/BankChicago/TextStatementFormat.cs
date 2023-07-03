namespace Katas.BankChicago;

static class TextStatementFormat
{
    public static IReadOnlyList<string> Format(Statement statement)
    {
        return Enumerable.Empty<string>()
            .Append("Date        |     Deposit |  Withdrawal |     Balance")
            .Concat(statement.GetLines().Select(FormatLine))
            .Append("")
            .Append($"Closing Balance: {statement.ClosingBalance:N2}")
            .ToArray();
    }

    static string FormatLine(StatementLine statementLine)
    {
        return statementLine.IsDeposit()
            ? $"{statementLine.Date}  |{statementLine.Amount,12:N2} |             |{statementLine.Balance,12:N2}"
            : $"{statementLine.Date}  |             |{statementLine.Amount,12:0.00;0.00} |{statementLine.Balance,12:N2}";
    }
}