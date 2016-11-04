using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuratorJournal.DataBase.Models
{
    public class Department
    {
        [Key]
        public long Id { get; set; }

        [Display(Name="Название")]
        public string Name { get; set; }

        [Display(Name = "Код")]
        public string Code { get; set; }
        
        [Display(Name = "Факультет")]
        #region HeadDepartment
        public virtual Department HeadDepartment { get; set; }

        [ForeignKey("HeadDepartment")]
        public long HeadDepartmentId { get; set; }
        #endregion
        
        [Display(Name = "Направление")]
        #region HeadDepartment
        public virtual Direction Direction { get; set; }

        [ForeignKey("Direction")]
        public long DirectionId { get; set; }
        #endregion

    }
}
