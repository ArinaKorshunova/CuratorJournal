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

        [Display(Name = "Декан")]
        #region Dean
        public virtual Person Dean { get; set; }

        [ForeignKey("Dean")]
        public long? DeanId { get; set; }
        #endregion

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Почтовая информация")]
        public string PostInformation { get; set; }

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
