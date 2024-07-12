namespace Katas.BankFakeIt;

public class Statement
{
    readonly Deposit? _deposit;

    public Statement(Deposit? deposit)
    {
        _deposit = deposit;
    }

    public string FormatAsText()
    {
        const string statementHeader = "Date       || Amount || Balance";
        if (_deposit == null)
        {
            return statementHeader;
        }
        
        var transactionLine = $"{_deposit.Date} || {_deposit.Amount}   || {_deposit.Amount}";
        return $"""
                {statementHeader}
                {transactionLine}
                """;
    }
}