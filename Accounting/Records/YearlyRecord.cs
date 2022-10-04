namespace Accounting;

public class YearlyRecord : BaseRecord
{
    public string month { get; set; }

    public int amount { get; set; }

    public bool isExpense { get; set; }

    public void ParseFileToObject(string line)
    {
        string[] str = line.Split("\t");
        month = str[0];
        amount = Convert.ToInt32(str[1]);
        isExpense = Convert.ToBoolean(str[2]);
    }
}