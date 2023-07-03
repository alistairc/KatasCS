using Katas.BankChicago.Tests.Infrastructure;

namespace Katas.BankChicago.Tests.Acceptance;

class StatementAfterTransactionsUserJourney
{
    [Test]
    public void VerifyStatementAfterDepositAndWithdrawal()
    {
        var testSystem = new AccountEndpointTestSystem()
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

    class AccountEndpointTestSystem
    {
        readonly Account _account = new();
        DateOnly _systemDate = DateOnly.MinValue;

        public AccountEndpointTestSystem SetDate(DateOnly systemDate)
        {
            _systemDate = systemDate;
            return this;
        }

        public AccountEndpointTestSystem Deposit(decimal amount)
        {
            GetBankAccountEndpoint().Deposit(amount);
            return this;
        }

        public AccountEndpointTestSystem Withdraw(decimal amount)
        {
            GetBankAccountEndpoint().Withdraw(amount);
            return this;
        }

        public IReadOnlyList<string> GetStatementText()
        {
            return GetBankAccountEndpoint().GetTextStatement();
        }

        BankAccountEndpoint GetBankAccountEndpoint()
        {
            var endpoint = new BankAccountEndpoint(new FixedClock(_systemDate), _account);
            return endpoint;
        }
    }
}