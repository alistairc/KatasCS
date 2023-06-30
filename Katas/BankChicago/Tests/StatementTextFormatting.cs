namespace Katas.BankChicago.Tests;

class StatementTextFormatting
{
    const int HeaderAndFooterLineCount = 3;
    
    [Test]
    public void WithNoTransactions_ShouldBeJustTheHeaderAndFooter()
    {
        var statement = new StatementBuilder().Build();
        var lines = TextStatementFormat.Format(statement);

        lines.Count.ShouldBe(3);
        lines[0].ShouldBe("Date | Deposit | Withdrawal | Amount");
        lines[1].ShouldBe("");
        lines[2].ShouldBe("Closing Balance: 0.00");
    }

    [Test]
    public void WithTransactions_ShouldIncludeHeaderAndFooterOneLinePerTransaction()
    {
        var statement = new StatementBuilder()
            .WithTransactions(
                new TransactionBuilder().Build(),
                new TransactionBuilder().Build()
            )
            .Build();
        var lines = TextStatementFormat.Format(statement);

        const int numberOfTransactions = 2;
        const int lineCount = HeaderAndFooterLineCount + numberOfTransactions;
        
        lines.Count.ShouldBe(lineCount);
        lines[0].ShouldBe("Date | Deposit | Withdrawal | Amount");
        
        lines[^2].ShouldBe("");
        lines[^1].ShouldStartWith("Closing Balance: ");
    }

    [Test]
    public void ShouldIncludeTheClosingBalance()
    {
        var statement = new StatementBuilder()
            .WithTransactions(
                new TransactionBuilder { Amount = 1000}.Build(),
                new TransactionBuilder { Amount = 1.2m }.Build()
            )
            .Build();
        var lines = TextStatementFormat.Format(statement);
        lines[^1].ShouldBe($"Closing Balance: 1,001.20");
    }

    // //TOO BIG
    // [Test]
    // public void WithTransactions_ShouldFormatAsExpected()
    // {
    //     //bit of a vague name, but this test covers quite a few bits
    //     // Date formatting - inc UK vs US dates
    //     // numeric formatting
    //     // alignment of columns
    //     // inclusion of total
    //     var statement = new StatementBuilder()
    //         .WithTransactions(
    //             new Transaction(new DateOnly(2022, 1, 1), "Deposit 1", 1234m),
    //             new Transaction(new DateOnly(2022, 12, 13), "Deposit 2", 5.67m),
    //             new Transaction(new DateOnly(2022, 12, 14), "Withdrawal 1", -10.6m)
    //         )
    //         .Build();
    //     var lines = TextStatementFormat.Format(statement);
    //     
    //     lines.Length.ShouldBe(6);
    //     lines[0].ShouldBe("Date       | Deposit | Withdrawal | Balance");
    //     lines[1].ShouldBe("01/01/2022 | 1234.00 |            | 1234.00");
    //     lines[2].ShouldBe("01/01/2022 |    5.67 |            | 1239.67");
    //     lines[3].ShouldBe("01/01/2022 |         |      10.60 | 1229.07");
    //     lines[4].ShouldBe("");
    //     lines[5].ShouldBe("Closing Balance: 1229.07");
    // }
}