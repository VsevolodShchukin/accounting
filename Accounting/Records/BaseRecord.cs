namespace Accounting;

public interface BaseRecord
{
    void ParseFileToObject(string line)
    {
    }

    public string month { set; get; }

    public int amount { get; set; }

    public bool isExpense { get; set; }
}