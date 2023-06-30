namespace Katas.BankChicago.Tests;

public abstract class GettingAStatement
{
    class WithNoTransactions : GettingAStatement
    {
        [Test]
        public void ShouldHaveNoLines()
        {
            var statementLines = GetStatementLinesForTransactions();
            statementLines.ShouldBeEmpty();
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
            
            var linesWithBalanceRemoved = lines.Select(line => line with { Balance = 0m}).ToArray();
            linesWithBalanceRemoved.ShouldContain(new StatementLine(new DateOnly(2022, 01, 01), "Salary", 1000m, 0));
            linesWithBalanceRemoved.ShouldContain(new StatementLine(new DateOnly(2022, 01, 02), "Sainsburys", -80.5m, 0));
        }

        [Test]
        public void ShouldHaveLinesWithNewestFirst()
        {
            var outOfOrderTransactions = new[]
            {
                new Transaction(new DateOnly(2022,01,01), "Older", 0),
                new Transaction(new DateOnly(2022,01,02), "Newer", 0)
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
    {
        var statement = new Statement(transactions);
        var statementLines = statement.GetLines();
        return statementLines;
    }
}