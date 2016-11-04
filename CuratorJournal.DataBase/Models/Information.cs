using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CuratorJournal.Logic.EnumWork;

namespace CuratorJournal.DataBase.Models
{
    public class Information : IRussianEnum
    {
        public static readonly Information Orphan = new Information { Id = 1, Name = "Orphan", RussianName = "Сирота" };
        public static readonly Information Disabled = new Information { Id = 2, Name = "Disabled", RussianName = "Инвалид" };
        public static readonly Information AkademVacation = new Information { Id = 3, Name = "AkademVacation", RussianName = "Академический отпуск" };
        public static readonly Information PaidForm = new Information { Id = 4, Name = "PaidForm", RussianName = "Платная форма" };
        public static readonly Information Praepostor = new Information { Id = 5, Name = "Praepostor", RussianName = "Староста" };
        public static readonly Information Proforg = new Information { Id = 6, Name = "Proforg", RussianName = "Профорг" };
        public static readonly Information HasDebt = new Information { Id = 7, Name = "HasDebt", RussianName = "Имеет задолженности на начало семестра" };

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string RussianName { get; private set; }
    }
}
