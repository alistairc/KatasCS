namespace Katas.BankChicago.Tests;

public class StatementAfterTransactionsUserJourney
{
    [Test, Explicit("User journey not complete yet")]
    public void VerifyStatementAfterDepositAndWithdrawal()
    {
        var testSystem = new TestSystem()
            .SetDate(new DateOnly(2022, 06, 29))
            .Deposit(100)
            .SetDate(new DateOnly(2022, 06, 30))
            .Withdraw(49.50m);

        //This seems very brittle, will have to improve that
        var statement = testSystem.GetStatementText().ToArray();
        statement[0].ShouldBe(" Date       | Credit  |   Debit |  Balance");
        statement[1].ShouldBe(" 29/06/2022 |   1,000 |         | 100");
        statement[2].ShouldBe(" 30/06/2022 |         |   49.50 |  50.50");
        statement[3].ShouldBe("");
        statement[4].ShouldBe("Closing Balance: 50.50");
    }

    class TestSystem
    {
        public TestSystem SetDate(DateOnly systemDate)
        {
            return this;
        }
        
        public TestSystem Deposit(decimal amount)
        {
            return this;
        }

        public TestSystem Withdraw(decimal amount)
        {
            return this;
        }

        public IEnumerable<string> GetStatementText()
        {
            yield break;
        }
    }
}