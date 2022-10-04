namespace Accounting;

public class YearlyReport: BaseReport
{
    public int income { get; set; }

    public int expense { get; set; }
    public int proceed { get; set; }

    public DataReportStorage GetYearlyReport(DataRecordStorage yearlyRecords)
    {
        DataReportStorage yReport = new DataReportStorage();
        foreach (var year in yearlyRecords.GetData().Keys)
        {
            IDictionary<int, BaseReport> yReportByMonth = new Dictionary<int, BaseReport>();
            foreach (var record in yearlyRecords.GetData()[year])
            {
                YearlyReport report = new YearlyReport();
                if (!yReportByMonth.ContainsKey(Int32.Parse(record.month)))
                {
                    if (record.isExpense)
                    {
                        report.expense += record.amount;
                    }
                    else
                    {
                        report.income += record.amount;
                    }
                    yReportByMonth.Add(Int32.Parse(record.month), report);
                }
                else
                {
                    if (record.isExpense)
                    {
                        yReportByMonth[Int32.Parse(record.month)].expense += record.amount;
                    }
                    else
                    {
                        yReportByMonth[Int32.Parse(record.month)].income += record.amount;
                    }
                }
            }

            yReport.AddNewData(year, yReportByMonth);
        }
        return yReport;
    }

    public void GetYearlyProceed(DataReportStorage yearlyReport)
    {
        foreach (var year in yearlyReport.GetData().Keys)
        {
            foreach (var month in yearlyReport.GetData()[year].Keys)
            {
                var m = yearlyReport.GetData()[year][month];
                m.proceed = m.income - m.expense;
            }
        }
    }

    // public double GetAverage(IDictionary<int, BaseReport> year, int property)
    // {
    //     int allExpense = 0;
    //     foreach (var month in year)
    //     {
    //         allExpense += month.;
    //     }
    //     //(double)allExpense;
    //     int averageExpense = allExpense/year.Keys
    // }


    public void PrintPrettyReport(DataReportStorage yearlyReport)
    {
        foreach (var year in yearlyReport.GetData().Keys)
        {
            Console.WriteLine(
                "\n======================" +
                $"\nОтчет для {year} года:"
            );
            foreach (var month in yearlyReport.GetData()[year].Keys)
            {
                Console.WriteLine(
                    $"Прибыль за {month}: {yearlyReport.GetData()[year][month].proceed}"
                );
            }
        }
    }
}