using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuratorJournal.DataBase.Models
{
    public class Subject
    {
        [Key]
        public long Id { get; set; }

        [Display(Name="Название")]
        public string Name { get; set; }
    }
}
