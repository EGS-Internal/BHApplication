using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHGroup.DAL.Entities
{
    public class Course
    {
        [Required]
        [Key]
        public int CourseID { get; set; }
        [Required]
        public string Coursename { get; set; }
        [Required]
        public string CourseCode { get; set; }
        public string Description { get; set; }
    }
}
