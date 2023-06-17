namespace Katas.BankChicago.Tests;

public class StatementTests
{
    [Test]
    public void WithNoTransactions_ShouldHaveNoLines()
    {
        var statement = new Statement(Array.Empty<Transaction>());
        statement.GetLines().ShouldBeEmpty();
    }

    [Test]
    public void WithTransactions_ShouldHaveLinesForEachTransaction()
    {
        var transaction1 = new Transaction(new DateOnly(2022, 01, 01), "Salary", 1000m);
        var transaction2 = new Transaction(new DateOnly(2022, 01, 02), "Sainsburys", -80.50m);
        var transactions = new[] { transaction1, transaction2 };

        var lines = new Statement(transactions).GetLines();

        lines.ShouldContain(new StatementLine(new DateOnly(2022, 01, 01), "Salary", 1000m));
        lines.ShouldContain(new StatementLine(new DateOnly(2022, 01, 02), "Sainsburys", -80.5m));
    }

    // [Test]
    // public void WithTransactions_ShouldHaveLinesWithNewestFirst()
    // {
    //     var outOfOrderTransactions = new[]
    //     {
    //         new Transaction(new DateOnly(2022,01,01)),
    //         new Transaction(new DateOnly(2022,01,02))
    //     };
    //     var statement = new Statement(outOfOrderTransactions);
    //
    //     statement.GetLines()
    //         .Select(line => line.Date)
    //         .ShouldBeInOrder(SortDirection.Descending);
    // }
}