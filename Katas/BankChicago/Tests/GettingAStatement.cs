namespace Katas.BankChicago.Tests;

abstract class GettingAStatement
{
    class WithNoTransactions : GettingAStatement
    {
        readonly Statement _statement = new StatementBuilder().Build();

        [Test]
        public void ShouldHaveNoLines()
        {
            _statement.GetLines().ShouldBeEmpty();
        }

        [Test]
        public void ShouldHaveZeroClosingBalance()
        {
            _statement.ClosingBalance.ShouldBe(0m);
        }
    }

    class WithTransactions : GettingAStatement
    {
        [Test]
        public void ShouldHaveLinesForEachTransaction()
        {
            var transaction1 = new Transaction(new DateOnly(2022, 01, 01), "Salary", 1000m);
            var transaction2 = new Transaction(new DateOnly(2022, 01, 02), "Sainsburys", -80.50m);

            var lines = GetStatementLinesForTransactions(transaction1, transaction2);

            var linesWithBalanceRemoved = lines.Select(line => line with { Balance = 0m }).ToArray();
            linesWithBalanceRemoved.ShouldContain(new StatementLine(new DateOnly(2022, 01, 01), "Salary", 1000m, 0));
            linesWithBalanceRemoved.ShouldContain(
                new StatementLine(new DateOnly(2022, 01, 02), "Sainsburys", -80.5m, 0)
            );
        }
        
        [Test]
        public void ShouldHaveClosingBalance()
        {
            var statement = new StatementBuilder()
                .WithTransactions(
                    new TransactionBuilder{ Amount = 1000 }.Build(),
                    new TransactionBuilder{ Amount = 50.12m }.Build()
                )
                .Build();
            statement.ClosingBalance.ShouldBe(1050.12m);
        }
        

        [Test]
        public void ShouldHaveLinesWithNewestFirst()
        {
            var outOfOrderTransactions = new[]
            {
                new TransactionBuilder{ Date = new DateOnly(2022, 01, 01) }.Build(),
                new TransactionBuilder{ Date = new DateOnly(2022, 01, 02) }.Build()
            };
            var lines = GetStatementLinesForTransactions(outOfOrderTransactions);

            lines
                .Select(line => line.Date)
                .ShouldBeInOrder(SortDirection.Descending);
        }

        [Test]
        public void ShouldIncludeTheCurrentBalanceOnEveryLine()
        {
            var transaction1 = new Transaction(new DateOnly(2022, 01, 01), "Salary", 1000m);
            var transaction2 = new Transaction(new DateOnly(2022, 01, 02), "Sainsburys", -80.50m);

            var lines = GetStatementLinesForTransactions(transaction1, transaction2);

            lines[0].Balance.ShouldBe(1000m - 80.50m);
            lines[1].Balance.ShouldBe(1000m);
        }
    }

    static IReadOnlyList<StatementLine> GetStatementLinesForTransactions(params Transaction[] transactions)
        => new StatementBuilder()
            .WithTransactions(transactions)
            .Build()
            .GetLines();
}