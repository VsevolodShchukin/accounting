using System.Text.RegularExpressions;

namespace Accounting
{
    public class Program
    {
        private static string path;
        private static DataReportStorage yearlyReport;
        private static DataRecordStorage yearlyDataStorage;

        private static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в Бугхалтерию 1С");
            Boolean toNext = true;

            while (toNext)
            {
                Console.WriteLine("Введите путь до расположения файлов с отчетами для дальнейшей работы с ними: ");

                path = Console.ReadLine();

                Console.WriteLine($"Указанный вами путь: {path}");
                Console.WriteLine("\n1. Перейти к счету отчетов" +
                                  "\n2. Изменить путь до расположения файлов с отчетами");
                switch (Console.ReadLine())
                {
                    case "1":
                        toNext = false;
                        break;
                    case "2":
                        break;
                }
            }

            Boolean isOn = true;
            while (isOn)
            {
                Console.WriteLine(
                    "\n1. Считать все месячные отчёты" +
                    "\n2. Считать годовой отчёт" +
                    "\n3. Сверить отчёты" +
                    "\n4. Вывести информацию о всех месячных отчётах" +
                    "\n5. Вывести информацию о годовом отчёте" +
                    "\n0. Выход");

                switch (Console.ReadLine())
                {
                    case "1":
                        // ReportReader monthlyRecord = new ReportReader(path, "m.");
                        // monthlyReport = monthlyRecord.ReadFile();
                        // Console.WriteLine("End");
                        break;
                    case "2":
                        try
                        {
                            FileReader fileReader = new FileReader(path, "y.");
                            yearlyDataStorage = fileReader.ReadYFiles();
                            Console.WriteLine("Отчет считан");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Произошла ошибка считывания файла");
                            throw;
                        }

                        break;
                    case "3":
                        Console.WriteLine("Сверить отчёты");
                        break;
                    case "4":
                        Console.WriteLine("Вывести информацию о всех месячных отчётах");
                        break;
                    case "5":
                        YearlyReport y = new YearlyReport();
                        yearlyReport = y.GetYearlyReport(yearlyDataStorage);
                        y.GetYearlyProceed(yearlyReport);
                        y.PrintPrettyReport(yearlyReport);
                        break;
                    case "0":
                        isOn = false;
                        break;
                }
            }
        }
    }
}