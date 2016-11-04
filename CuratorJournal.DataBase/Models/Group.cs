using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuratorJournal.DataBase.Models
{
    public class Group
    {
        [Key]
        public long Id { get; set; }

        [Display(Name="Год")]
        [Range(1700, 2500, ErrorMessage = "Недопустимый год")]
        public int Year { get; set; }

        [Display(Name = "Шифр")]
        public string Cipher { get; set; }

        [Display(Name = "Куратор")]
        #region Curator
        public virtual Person Сurator { get; set; }

        [ForeignKey("Сurator")]
        public long СuratorId { get; set; }
        #endregion

        [Display(Name = "Зав. кафедры")]
        #region HeadOfDepartment
        public virtual Person HeadOfDepartment { get; set; }

        [ForeignKey("HeadOfDepartment")]
        public long HeadOfDepartmentId { get; set; }
        #endregion

        [Display(Name = "Кафедра")]
        #region Department
        public virtual Department Department { get; set; }

        [ForeignKey("Department")]
        public long DepartmentId { get; set; }
        #endregion
    }
}
