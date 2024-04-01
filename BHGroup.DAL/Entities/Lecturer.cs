using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BHGroup.DAL.Entities
{
    [Table("lecturers")]
    public class Lecturer : Person
    {
        //[Index(IsUnique = true)]
        [Key]
        [Column("staff_code", Order = 1)]
        public int StaffCode { get; set; }
        [Column("courses")]
        public ICollection<Course>? Courses { get; set; } = new List<Course>();
    }
}
