namespace Katas.BankFakeIt;

public class Statement
{
    public IEnumerable<string> FormatAsText()
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