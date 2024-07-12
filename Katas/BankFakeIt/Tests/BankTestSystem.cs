namespace Katas.BankFakeIt.Tests;

class BankTestSystem
{
    public BankTestSystem Deposit(TimestampedAmount timestampedAmount)
    {
        return this;
    }

    public BankTestSystem Withdraw(TimestampedAmount timestampedAmount)
    {
        return this;
    }

    public string GetStatementText()
    {
        return  """
                Date       || Amount || Balance
                14/01/2012 || -500   || 2500
                13/01/2012 || 2000   || 3000
                10/01/2012 || 1000   || 1000
                """;
    }
}