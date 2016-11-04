using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CuratorJournal.Logic.EnumWork;

namespace CuratorJournal.DataBase.Models
{
    public class Gender : IRussianEnum
    {
        public static readonly Gender Male = new Gender { Id = 1, Name = "Male", RussianName = "Мужской", ShortName = "M"};
        public static readonly Gender Female = new Gender { Id = 2, Name = "Female", RussianName = "Женский", ShortName = "Ж" };

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string RussianName { get; private set; }

        [NotMapped]
        public string ShortName { get; private set; }
    }
}
