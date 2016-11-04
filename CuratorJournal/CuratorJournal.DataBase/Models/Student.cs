using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuratorJournal.DataBase.Models
{
    public class Student
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "ФИО")]
        public string FIO { get; set; }

        [Display(Name = "телефон")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name="Пол")]
        #region Gender
        public Gender Gender { get; set; }

        [ForeignKey("Gender")]
        public long GenderId { get; set; }
        #endregion

        [Display(Name = "Целевой набор")]
        public bool IsTargetSet { get; set; }

        [Display(Name = "Олимпиада")]
        public bool IsOlympiad { get; set; }

        [Display(Name = "Общий конкурс")]
        public bool IsGeneralCompetition { get; set; }

        [Display(Name = "Проживание")]
        [InverseProperty("Student")]
        public virtual List<StudentHabitation> StudentHabitations { get; set; }

        [Display(Name = "Сведения")]
        [InverseProperty("Student")]
        public virtual List<StudentInformation> StudentInformations { get; set; }
        
        [Display(Name = "Группа")]
        #region Group
        public Group Group { get; set; }

        [ForeignKey("Group")]
        public long GroupId { get; set; }
        #endregion

    }
}
