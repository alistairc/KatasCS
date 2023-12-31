﻿using Katas.BankChicago.Accounts;
using Katas.BankChicago.Accounts.Statements;

namespace Katas.BankChicago.Tests.Infrastructure;

class StatementBuilder
{
    readonly List<Transaction> _transactions = new();

    public StatementBuilder WithTransactions(params Transaction[] transactions)
    {
        _transactions.AddRange(transactions);
        return this;
    }

    public Statement Build()
    {
        var account = new Account(new InMemoryTransactionRepository());
        foreach (var transaction in _transactions)
        {
            account.MakeTransaction(transaction);
        }
        return account.GetStatement();
    }
}