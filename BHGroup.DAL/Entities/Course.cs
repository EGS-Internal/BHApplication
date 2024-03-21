using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHGroup.DAL.Entities
{
    public class Course
    {
        //[Required]
        [Key]
        public int CourseID { get; set; }
        [Required]
        public string Coursename { get; set; }
        [Required]
        [StringLength(6)]
        public string CourseCode { get; set; }
        [AllowNull]
        public string Description { get; set; }
        public Lecturer Lecturer { get; set; }
    }
}
