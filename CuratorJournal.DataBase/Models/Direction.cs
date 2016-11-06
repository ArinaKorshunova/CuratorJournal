using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuratorJournal.DataBase.Models
{
    public class Direction
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "Наименование направления/специальности")]
        public string Name { get; set; }

        [Display(Name = "Код направления/специальности")]
        public string Code { get; set; }
        
        [Display(Name = "список выпускающих кафедр")]
        [InverseProperty("Direction")]
        public virtual List<DepartmentDirection> DepartmentDirections { get; set; }

    }
}
