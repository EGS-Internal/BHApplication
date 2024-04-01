using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BHGroup.DAL.Entities
{
    public enum EGrades { A = 4, B = 3, C = 2, D = 1, F = 0 };
    [Table("enrollments")]
    public class Enrollment
    {

        [Column("student_code")]
        [ForeignKey("student_code")]
        public Student Student { get; set; }
        [Column("id")]
        public int Id { get; set; }
        [Column("course_code")]
        [ForeignKey("course_code")]
        public Course Course { get; set; }
        [AllowNull]
        [Column("grade")]
        public EGrades Grade { get; set; }
        [StringLength(5)]
        [Required]
        [Column("semester")]
        public string Semester { get; set; }
    }
}
