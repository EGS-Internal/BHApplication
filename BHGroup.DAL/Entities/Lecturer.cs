using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHGroup.DAL.Entities
{
    [Table("lecturers")]
    public class Lecturer : Person
    {
        //[Index(IsUnique = true)]
        [Column("staff_code",Order =1)]
        public string StaffCode {  get; set; }
        [Column("courses")]
        public ICollection<Course>? Courses { get; set; } = new List<Course>();
    }
}
