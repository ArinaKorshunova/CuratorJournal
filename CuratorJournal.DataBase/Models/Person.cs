using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuratorJournal.DataBase.Models
{
    [Table("Persons")]
    public class Person
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [Display(Name="Имя")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name="степень")]
        public string Rank { get; set; }
        
        [Display(Name = "Пользователь")]
        #region User
        public virtual User User { get; set; }

        [ForeignKey("User")]
        public long? UsereId { get; set; }
        #endregion
        
        [Display(Name = "Кафедра")]
        #region Department
        public virtual Department Department { get; set; }

        [ForeignKey("Department")]
        public long? DepartmentId { get; set; }
        #endregion

        [NotMapped]
        public string NameAndRank {
            get { return string.Format("{0} {1} {2} ({3})", LastName, FirstName, MiddleName, Rank); }
        }
    }
}
