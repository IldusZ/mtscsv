using CsvHelper;
using MTSTaskCSV.Models;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace MTSTaskCSV.Helpers
{
    public static class DBOperations
    {
        public static async Task SaveDataAsync(string filePath)
        {
            // Чтение файла (используется библиотека "CsvHelper")
            var stream = new StreamReader(filePath);
            var csv = new CsvReader(stream, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<Person>();

            // Запись в БД
            using (var db = new CSVContext())
            {
                db.Persons.AddRange(records);
                await db.SaveChangesAsync();
            }
        }
    }
}