namespace Accounting;

public class DataRecordStorage
{
    private IDictionary<string, List<BaseRecord>> data = new Dictionary<string, List<BaseRecord>>();

    public void AddNewData(string key, List<BaseRecord> records)
    {
        data.Add(key, records);
    }

    public IDictionary<string, List<BaseRecord>> GetData()
    {
        return data;
    }
}