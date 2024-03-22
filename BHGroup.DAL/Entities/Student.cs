using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHGroup.DAL.Entities
{
    [Table("students")]
    public class Student : Person
    {
        [Required]
        [Column("student_code",Order = 1)]
        public string StudentCode { get; set; }
    }
}
