using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuratorJournal.DataBase.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [Display(Name="Логин")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        
        [Display(Name = "список ролей")]
        [InverseProperty("User")]
        public virtual List<UserRole> UserRoles { get; set; }
    }
}
