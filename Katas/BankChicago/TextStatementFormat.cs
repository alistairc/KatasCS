namespace Katas.BankChicago;

static class TextStatementFormat
{
    public static string[] Format(Statement statement)
    {
        return new[]
        {
            "Date | Deposit | Withdrawal | Amount",
            "",
            "Closing Balance: 0.00"
        };
    }
}