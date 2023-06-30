namespace Katas.BankChicago;

static class TextStatementFormat
{
    public static IReadOnlyList<string> Format(Statement statement)
    {
        var statementLines = statement.GetLines();
        var outputLines = new List<string>();
        outputLines.Add("Date | Deposit | Withdrawal | Amount");
        foreach (var statementLine in statementLines)
        {
            outputLines.Add("");
        }
        outputLines.Add("");
        outputLines.Add("Closing Balance: 0.00");
        return outputLines;
    }
}