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
    public class Enrollment
    {
        [Required]
        [Key,Column(Order = 1)]
        public Student Student { get; set; }
        [Required]
        [Key, Column(Order = 2)]
        public Course Course { get; set; }
        [AllowNull]
        public Grades Grade { get; set; }
        [StringLength(5)]
        [Required]
        [Key,Column(Order = 3)]
        public string Semester { get; set; }
    }
}
