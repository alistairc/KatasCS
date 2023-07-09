using Katas.BankChicago.Hexagon;
using Katas.BankChicago.Infrastructure;
using Katas.BankChicago.Schema;

namespace Katas.BankChicago.Tests.Infrastructure;

class AccountEndpointTestSystem
{
    readonly InMemoryTransactionRepository _transactionRepository = new();
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

    IBankAccountEndpoint GetBankAccountEndpoint()
    {
        return new BankAccountEndpoint(
            new FixedClock(_systemDate), new Account(_transactionRepository)
        );
    }
}