namespace Katas.BankChicago.Tests;

class StatementTextFormatting
{
    [Test]
    public void WithNoTransaction_ShouldBeJustTheHeaderAndFooter()
    {
        var statement = new StatementBuilder().Build();
        var lines = TextStatementFormat.Format(statement);

        lines.Length.ShouldBe(3);
        lines[0].ShouldBe("Date | Deposit | Withdrawal | Amount");
        lines[1].ShouldBe("");
        lines[2].ShouldBe("Closing Balance: 0.00");
    }
}