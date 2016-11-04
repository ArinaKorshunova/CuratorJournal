using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuratorJournal.DataBase.Models
{
    public class StudentInformation
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "Студент")]
        #region Student
        public virtual Student Student { get; set; }

        [ForeignKey("Student")]
        public long StudentId { get; set; }
        #endregion

        [Display(Name = "Сведения")]
        #region Information
        public virtual Information Information { get; set; }

        [ForeignKey("Information")]
        public long InformationId { get; set; }
        #endregion
    }
}
