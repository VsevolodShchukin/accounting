namespace Accounting;

public class FileReader
{
    private IEnumerable<string> files;

    public FileReader(string path, string pattern)
    {
        files = Directory.GetFiles(path, "*.csv").Where(s => s.Contains(pattern));
        PrintCount(files);
    }

    private static void PrintCount(IEnumerable<string> files)
    {
        Console.WriteLine($"Найденное кол-во файлов: {files.Count()}");
    }

    public DataRecordStorage ReadYFiles()
    {
        DataRecordStorage dataStorage = new DataRecordStorage();
        foreach (var file in files)
        {
            List<BaseRecord> record = new List<BaseRecord>();
            using (StreamReader str = new StreamReader(file))
            {
                str.ReadLine();
                string line;
                while ((line = str.ReadLine()) != null)
                {
                    YearlyRecord r = new YearlyRecord();
                    r.ParseFileToObject(line);
                    record.Add(r);
                }
            }

            dataStorage.AddNewData(file.Split(".")[^2], record);
        }

        return dataStorage;
    }
}


// public IDictionary<int, List<BaseReport>> ReadFile()
// {
//     IDictionary<int, List<BaseReport>> report = new Dictionary<int, List<BaseReport>>();
//
//     int i = 0;
//     foreach (var file in files)
//     {
//         List<BaseReport> record = new List<BaseReport>();
//         using (StreamReader str = new StreamReader(file))
//         {
//             
//             str.ReadLine();
//             string line;
//             while ((line = str.ReadLine()) != null)
//             {
//                 if (file.Contains("m."))
//                 {
//                     MonthlyReport r = new MonthlyReport();
//                     r.ParseFileToObject(line);
//                     record.Add(r);
//                 }
//
//                 if (file.Contains("y."))
//                 {
//                     YearlyReport r = new YearlyReport();
//                     r.ParseFileToObject(line);
//                     record.Add(r);
//                 }
//             }
//         }
//         report.Add(i, record);
//         i += 1;
//     }
//     return report;
// }