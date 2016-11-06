using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuratorJournal.DataBase.Models
{
    public class StudentHabitation
    {
        [Key]
        public long Id { get; set; }
        
        [Display(Name = "Студент")]
        #region Student
        public virtual Student Student { get; set; }

        [ForeignKey("Student")]
        public long StudentId { get; set; }
        #endregion

        [Display(Name = "Проживание")]
        #region Habitation
        public virtual Habitation Habitation { get; set; }

        [ForeignKey("Habitation")]
        public long HabitationId { get; set; }
        #endregion
    }
}
