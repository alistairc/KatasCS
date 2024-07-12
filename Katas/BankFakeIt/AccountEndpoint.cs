using Katas.BankFakeIt.Tests.Acceptance;

namespace Katas.BankFakeIt;

class AccountEndpoint
{
    public void Deposit(decimal amount)
    {
    }

    public void Withdraw(decimal amount)
    {
    }

    public IEnumerable<string> GetStatementText()
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