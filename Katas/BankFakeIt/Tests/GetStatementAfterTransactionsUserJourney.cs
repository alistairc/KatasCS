namespace Katas.BankFakeIt.Tests;

class GetStatementAfterTransactionsUserJourney
{
    // [Test]
    // public void WithDepositsAndWithdrawals()
    // {
    //     var system = new BankTestSystem()
    //         .Deposit(new TimestampedAmount(new DateOnly(2012, 01, 10), 1000m))
    //         .Deposit(new TimestampedAmount(new DateOnly(2012, 01, 13), 2000m))
    //         .Withdraw(new TimestampedAmount(new DateOnly(2012, 01, 14), 500m));
    //
    //     const string expected =
    //         """
    //         Date       || Amount || Balance
    //         14/01/2012 || -500   || 2500
    //         13/01/2012 || 2000   || 3000
    //         10/01/2012 || 1000   || 1000
    //         """;
    //     
    //     AssertStatementText(system, expected);
    // }

    [Test]
    public void WithNoTransactions()
    {
        var system = new BankTestSystem();

        const string expected = "Date       || Amount || Balance";
        AssertStatementText(system, expected);
    }

    [Test]
    public void WithASingleDeposit()
    {
        var system = new BankTestSystem()
            .Deposit(new Deposit(new DateOnly(2012, 01, 10), 1000m));

        const string expected =
            """
            Date       || Amount || Balance
            10/01/2012 || 1000   || 1000
            """;
        
        AssertStatementText(system, expected);
    }

    [Test]
    public void WithADifferentDeposit()
    {
        var system = new BankTestSystem()
            .Deposit(new Deposit(new DateOnly(2013, 02, 11), 999m));

        const string expected =
            """
            Date       || Amount || Balance
            11/02/2013 || 999   || 999
            """;
        
        AssertStatementText(system, expected);
    }
   
    static void AssertStatementText(BankTestSystem updatedSystem, string expected)
    {
        var statement = updatedSystem.GetStatementText();
        statement.ShouldBe(expected);
    }
}