namespace Accounting;

public class DataReportStorage
{
    private IDictionary<string, IDictionary<int, BaseReport>> data = new Dictionary<String, IDictionary<int, BaseReport>>();

    public void AddNewData(string key, IDictionary<int, BaseReport> reports)
    {
        data.Add(key, reports);
    }

    public IDictionary<string, IDictionary<int, BaseReport>> GetData()
    {
        return data;
    }
}