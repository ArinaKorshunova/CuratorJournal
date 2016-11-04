using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CuratorJournal.Logic.EnumWork;

namespace CuratorJournal.DataBase.Models
{
    public class Qualification : IRussianEnum
    {
        public static readonly Qualification Bachelor = new Qualification { Id = 1, Name = "Bachelor", RussianName = "Бакалавр" };
        public static readonly Qualification Specialist = new Qualification { Id = 2, Name = "Specialist", RussianName = "Специалист" };
        public static readonly Qualification Master = new Qualification { Id = 3, Name = "Master", RussianName = "Магистр" };

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string RussianName { get; private set; }
    }
}
