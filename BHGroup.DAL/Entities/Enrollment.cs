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
        [NotMapped]
        public string Student { get; set; }
        [Column("student_code",Order = 1)]
        public string StudentCode { get; set; }
        
        [Column("id")]
        public int Id { get; set; }
        [NotMapped]
        public Course Course { get; set; }
        [Column("course_code",Order = 2)]
        public string CourseCode { get; set; }
        [AllowNull]
        [Column("grade")]
        public Grades Grade { get; set; }
        [StringLength(5)]
        [Required]
        [Column("semester", Order = 3)]
        public string Semester { get; set; }
    }
}
