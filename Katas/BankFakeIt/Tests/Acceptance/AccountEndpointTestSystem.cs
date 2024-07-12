namespace Katas.BankFakeIt.Tests.Acceptance;

class AccountEndpointTestSystem
{
    readonly AccountEndpoint _endpoint = new();
    
    public AccountEndpointTestSystem SetDate(DateOnly dateOnly)
    {
        return this;
    }

    public AccountEndpointTestSystem Deposit(decimal amount)
    {
        _endpoint.Deposit(amount);
        return this;
    }

    public AccountEndpointTestSystem Withdraw(decimal amount)
    {
        _endpoint.Withdraw(amount);
        return this;
    }

    public string[] GetStatementText()
    {
        return _endpoint.GetStatementText()
            .ToArray();
    }
}