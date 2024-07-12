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
        return new Statement().FormatAsText();
    }
}