using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CuratorJournal.Logic.EnumWork;

namespace CuratorJournal.DataBase.Models
{
    public class Semester : IRussianEnum
    {
        public static readonly Semester Autumn = new Semester { Id = 1, Name = "Autumn", RussianName = "Осенний семестр" };
        public static readonly Semester Spring = new Semester { Id = 2, Name = "Spring", RussianName = "Весенний семестр" };

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string RussianName { get; private set; }
    }
}
