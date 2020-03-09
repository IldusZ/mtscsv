using System.Data.Entity;

namespace MTSTaskCSV.Models
{
    /// <summary>
    /// Инициализация базы данных
    /// </summary>
    public class CSVDbInitializer : DropCreateDatabaseAlways<CSVContext>
    {
        protected override void Seed(CSVContext context)
        {
            context.Persons.Add(new Person { });

            base.Seed(context);
        }
    }
}