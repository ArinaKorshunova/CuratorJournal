using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuratorJournal.DataBase.Models
{
    public class Person
    {
        [Key]
        public long Id { get; set; }

        [Display(Name="ФИО")]
        public string FIO { get; set; }

        [Display(Name="степень")]
        public string Rank { get; set; }
        
        [Display(Name = "Пользователь")]
        #region User
        public virtual User User { get; set; }

        [ForeignKey("User")]
        public long UsereId { get; set; }
        #endregion
    }
}
