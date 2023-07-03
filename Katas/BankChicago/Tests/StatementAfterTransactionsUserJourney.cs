﻿namespace Katas.BankChicago.Tests;

class StatementAfterTransactionsUserJourney
{
    [Test, Explicit("User journey not complete yet")]
    public void VerifyStatementAfterDepositAndWithdrawal()
    {
        var testSystem = new TestSystem()
            .SetDate(new DateOnly(2022, 06, 29))
            .Deposit(1000)
            .SetDate(new DateOnly(2022, 06, 30))
            .Withdraw(49.50m);

        //This seems very brittle, will have to improve that
        var statement = testSystem.GetStatementText();
        statement[0].ShouldBe("Date        |     Deposit |  Withdrawal |     Balance");
        statement[1].ShouldBe("30/06/2022  |             |       49.50 |      950.50");
        statement[2].ShouldBe("29/06/2022  |    1,000.00 |             |    1,000.00");
        statement[3].ShouldBe("");
        statement[4].ShouldBe("Closing Balance: 950.50");
    }

    class TestSystem
    {
        readonly Account _account = new();
        DateOnly _systemDate = DateOnly.MinValue;
        
        public TestSystem SetDate(DateOnly systemDate)
        {
            _systemDate = systemDate;
            return this;
        }
        
        public TestSystem Deposit(decimal amount)
        {
            //TODO: logic in test code
            _account.MakeTransaction(new Transaction(_systemDate, "Deposit", amount));
            return this;
        }

        public TestSystem Withdraw(decimal amount)
        {
            //TODO: logic in test code
            _account.MakeTransaction(new Transaction(_systemDate, "Withdrawal", -amount));
            return this;
        }

        public IReadOnlyList<string> GetStatementText()
        {
            //TODO: logic in test code
            return TextStatementFormat.Format(_account.GetStatement());
        }
    }
}