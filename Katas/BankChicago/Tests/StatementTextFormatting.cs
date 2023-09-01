using Katas.BankChicago.Accounts;
using Katas.BankChicago.Accounts.Statements;
using Katas.BankChicago.Tests.Infrastructure;

namespace Katas.BankChicago.Tests;

class StatementTextFormatting
{
    [Test]
    public void WithNoTransactions_ShouldBeJustTheHeaderAndFooter()
    {
        var statement = new StatementBuilder().Build();
        var lines = TextStatementFormat.Format(statement);

        lines.Count.ShouldBe(3);
        lines[0].ShouldBe("Date        |     Deposit |  Withdrawal |     Balance");
        lines[1].ShouldBe("");
        lines[2].ShouldBe("Closing Balance: 0.00");
    }

    [Test]
    public void ShouldFormatNegativeClosingBalance()
    {
        var statement = new StatementBuilder()
            .WithTransactions(
                new TransactionBuilder { Amount = -1000 }.Build(),
                new TransactionBuilder { Amount = -1.2m }.Build()
            )
            .Build();
        var lines = TextStatementFormat.Format(statement);
        lines[^1].ShouldBe("Closing Balance: -1,001.20");
    }

    [Test]
    public void WithTransactions_ShouldUseApprovedLayout()
    {
        // This is an Approval test.  Inevitably covers quite a bit of stuff
        // and is a bit brittle, but good for visual stuff

        var statement = new StatementBuilder()
            .WithTransactions(
                new Transaction(new DateOnly(2022, 1, 1), "Deposit 1", 1234m),
                new Transaction(new DateOnly(2022, 12, 13), "Deposit 2", 5.67m),
                new Transaction(new DateOnly(2022, 12, 14), "Withdrawal 1", -10.6m)
            )
            .Build();
        var lines = TextStatementFormat.Format(statement);

        lines[0].ShouldBe("Date        |     Deposit |  Withdrawal |     Balance");
        lines[1].ShouldBe("14/12/2022  |             |       10.60 |    1,229.07");
        lines[2].ShouldBe("13/12/2022  |        5.67 |             |    1,239.67");
        lines[3].ShouldBe("01/01/2022  |    1,234.00 |             |    1,234.00");
        lines[4].ShouldBeEmpty();
        lines[5].ShouldBe("Closing Balance: 1,229.07");
    }
}