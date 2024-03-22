using Microsoft.EntityFrameworkCore;
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
    [Table("courses")]
    public class Course
    {
        //[Required]
        [Key,Column("course_id")]
        public int CourseID { get; set; }
        [Required]
        [Column("course_name")]
        public string Coursename { get; set; }
        [Required]
        [StringLength(6)]
        [Column("course_code")]
        public string CourseCode { get; set; }
        [AllowNull]
        [Column("description")]
        public string Description { get; set; }
        [Column("lecturer")]
        public Lecturer Lecturer { get; set; }
    }
}
