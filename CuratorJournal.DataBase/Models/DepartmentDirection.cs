using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuratorJournal.DataBase.Models
{
    public class DepartmentDirection
    {
        [Key]
        public long Id { get; set; }
        
        [Display(Name = "Квалификация")]
        #region Qualification
        public Qualification Qualification { get; set; }

        [ForeignKey("Qualification")]
        public long QualificationId { get; set; }
        #endregion
        
        [Display(Name = "Направление")]
        #region Direction
        public virtual Direction Direction { get; set; }

        [ForeignKey("Direction")]
        public long? DirectionId { get; set; }
        #endregion

        [Display(Name = "Кафедра")]
        #region Department
        public virtual Department Department { get; set; }

        [ForeignKey("Department")]
        public long? DepartmentId { get; set; }
        #endregion

    }
}
