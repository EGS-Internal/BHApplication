using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHGroup.DAL.Entities
{
    public class Student : Person
    {
        [Required]
        public DateTime JoinDate {  get; set; }
    }
}
