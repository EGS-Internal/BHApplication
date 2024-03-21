using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHGroup.DAL.Entities
{
    public enum Grade {A,B,C,D,F };
    public class Enrollment
    {
        [Required]
        public Student Student { get; set; }
        [Required]
        public Course Course { get; set; }
        [AllowNull]
        public Grade Grade { get; set; }
    }
}
