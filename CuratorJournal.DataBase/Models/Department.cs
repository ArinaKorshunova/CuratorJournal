using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace CuratorJournal.DataBase.Models
{
    public class Department
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [Display(Name="Название")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Код")]
        public string Code { get; set; }
        
        [Display(Name = "Факультет")]
        #region HeadDepartment
        public virtual Department HeadDepartment { get; set; }
        
        [ForeignKey("HeadDepartment")]
        public long? HeadDepartmentId { get; set; }
        #endregion

        [Display(Name = "список направлений кафедры")]
        [InverseProperty("Department")]
        public virtual List<DepartmentDirection> DepartmentDirections { get; set; }

        [NotMapped]
        public string Title
        {
            get { return string.Format("{0} - {1}", Code, Name); }
        }

    }
}
