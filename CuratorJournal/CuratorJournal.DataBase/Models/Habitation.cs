using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CuratorJournal.Logic.EnumWork;

namespace CuratorJournal.DataBase.Models
{
    public class Habitation : IRussianEnum
    {
        public static readonly Habitation Kaluga = new Habitation { Id = 1, Name = "Kaluga", RussianName = "Калуга"};
        public static readonly Habitation KalugaRegion = new Habitation { Id = 2, Name = "KalugaRegion", RussianName = "Калужская область" };
        public static readonly Habitation RemoteRegions = new Habitation { Id = 3, Name = "RemoteRegions", RussianName = "Отдаленные регионы" };
        public static readonly Habitation PrivateSector = new Habitation { Id = 4, Name = "PrivateSector", RussianName = "Частный сектор" };
        public static readonly Habitation Dormitory = new Habitation { Id = 5, Name = "Dormitory", RussianName = "Общежитие" };
        public static readonly Habitation Foreigner = new Habitation { Id = 6, Name = "Foreigner", RussianName = "Иностранец" };

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string RussianName { get; private set; }
    }
}
