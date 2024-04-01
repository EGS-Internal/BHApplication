using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BHGroup.DAL.Entities
{
    [Table("students")]
    public class Student : Person
    {
        [Required]
        [Key]
        [Column("student_code", Order = 1)]
        public int StudentCode { get; set; }
    }
}
