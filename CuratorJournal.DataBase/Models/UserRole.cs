using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuratorJournal.DataBase.Models
{
    public class UserRole
    {
        [Key]
        public long Id { get; set; }
        
        [Display(Name = "Пользователь")]
        #region HeadDepartment
        public virtual User User { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }
        #endregion

        [Display(Name = "Роль")]
        #region HeadDepartment
        public virtual Role Role { get; set; }

        [ForeignKey("Role")]
        public long RoleId { get; set; }
        #endregion
    }
}
