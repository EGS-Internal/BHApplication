using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHGroup.DAL.Entities
{
    public enum Grades {A,B,C,D,F };
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
        public Grades Grade { get; set; }
        [StringLength(5)]
        [Required]
        [Column("semester")]
        public string Semester { get; set; }
    }
}
