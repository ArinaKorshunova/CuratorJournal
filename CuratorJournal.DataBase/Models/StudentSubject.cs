using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuratorJournal.DataBase.Models
{
    public class StudentSubject
    {
        [Key]
        public long Id { get; set; }

        [Display(Name="Студент")]
        #region Student
        public virtual Student Student { get; set; }
        
        [ForeignKey("Student")]
        public long StudentId { get; set; }
        #endregion

        [Display(Name = "Предмет")]
        #region Subject
        public virtual Subject Subject { get; set; }

        [ForeignKey("Subject")]
        public long SubjectId { get; set; }
        #endregion

        [Display(Name = "Преподаватель")]
        #region Teacher
        public virtual Person Teacher { get; set; }

        [ForeignKey("Teacher")]
        public long TeacherId { get; set; }
        #endregion
    }
}
