using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CuratorJournal.Logic.EnumWork;

namespace CuratorJournal.DataBase.Models
{
    public class Role : IRussianEnum
    {
        public static readonly Role Сurator = new Role { Id = 1, Name = "Сurator", RussianName = "Куратор"};
        public static readonly Role HeadOfDepartment = new Role { Id = 2, Name = "HeadOfDepartment", RussianName = "Зав. кафедрой" };
        public static readonly Role Teacher = new Role { Id = 3, Name = "Teacher", RussianName = "Преподаватель" };
        public static readonly Role Guest = new Role { Id = 4, Name = "Guest", RussianName = "Гость" };

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string RussianName { get; private set; }
    }
}
