namespace Katas.BankFakeIt.Tests.Acceptance;

class AccountEndpointTestSystem
{
    public AccountEndpointTestSystem SetDate(DateOnly dateOnly)
    {
        return this;
    }

    public AccountEndpointTestSystem Deposit(decimal amount)
    {
        return this;
    }

    public AccountEndpointTestSystem Withdraw(decimal amount)
    {
        return this;
    }

    public string[] GetStatementText()
    {
        return
        [
            "Date        |     Deposit |  Withdrawal |     Balance",
            "30/06/2022  |             |       49.50 |      950.50",
            "29/06/2022  |    1,000.00 |             |    1,000.00",
            "",
            "Closing Balance: 950.50"
        ];
    }
}