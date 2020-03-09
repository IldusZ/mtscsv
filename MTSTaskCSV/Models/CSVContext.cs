using System.Data.Entity;

namespace MTSTaskCSV.Models
{
    /// <summary>
    /// Контекст данных, используемый для взаимодействия с базой данных
    /// </summary>
    public class CSVContext : DbContext
    {
        /// <summary>
        /// Данные о клиентах
        /// </summary>
        public DbSet<Person> Persons { get; set; }
    }
}