namespace Katas.BankFakeIt.Tests;

class AcceptanceTest
{
    [Test]
    public void GetStatementAfterTransactionsUserJourney()
    {
        var system = new BankTestSystem();
        var statement = system
            .Deposit(new TimestampedAmount(new DateOnly(2012, 01, 10), 1000m))
            .Deposit(new TimestampedAmount(new DateOnly(2012, 01, 13), 2000m))
            .Withdraw(new TimestampedAmount(new DateOnly(2012, 01, 14), 500m))
            .GetStatementText();

        const string expected =
            """
            Date       || Amount || Balance
            14/01/2012 || -500   || 2500
            13/01/2012 || 2000   || 3000
            10/01/2012 || 1000   || 1000
            """;

        statement.ShouldBe(expected);
    }
}

record TimestampedAmount(DateOnly Date, decimal Amount);