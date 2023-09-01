using Katas.BankChicago.Accounts;
using Katas.BankChicago.Tests.Infrastructure;

namespace Katas.BankChicago.Tests;

class AddingAndWithdrawingMoney
{
    [Test]
    public void Deposit_ShouldAddMoneyToTheAccount()
    {
        const decimal amountDeposited = 123.45m;
        var depositDate = new DateOnly(2022, 12, 13);
        
        var account = new Account(new InMemoryTransactionRepository());
        var endpoint = new BankAccountEndpoint(new FixedClock(depositDate), account);
        endpoint.Deposit(amountDeposited);
        
        var statementLine = account.GetStatement().GetLines()[0];
        statementLine.Amount.ShouldBe(amountDeposited);
        statementLine.Date.ShouldBe(depositDate);
    }

    [Test]
    public void Withdrawal_ShouldRemoveMoney()
    {
        const decimal amountWithdrawn = 123.45m;
        var withdrawalDate = new DateOnly(2022, 12, 13);
        
        var account = new Account(new InMemoryTransactionRepository());
        var endpoint = new BankAccountEndpoint(new FixedClock(withdrawalDate), account);
        endpoint.Withdraw(amountWithdrawn);
        
        var statementLine = account.GetStatement().GetLines()[0];
        statementLine.Amount.ShouldBe(0 - amountWithdrawn);
        statementLine.Date.ShouldBe(withdrawalDate);
    }
}