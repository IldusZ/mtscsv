using CsvHelper.Configuration.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MTSTaskCSV.Models
{
    /// <summary>
    /// Личность
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        [Key]
        [Ignore]
        public int Id { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        [Name("PHONE")]
        [DisplayName("Телефон")]
        public string Phone { get; set; }

        /// <summary>
        /// Фамилия, имя и отчество
        /// </summary>
        [Name("FIO")]
        [DisplayName("ФИО")]
        public string FIO { get; set; }

        /// <summary>
        /// Субъект РФ
        /// </summary>
        [Name("REGION")]
        [DisplayName("Субъект РФ")]
        public string Region { get; set; }

        /// <summary>
        /// Серия и номер паспорта
        /// </summary>
        [Name("PASSPORT")]
        [DisplayName("Паспорт")]
        public string Passport { get; set; }
    }
}