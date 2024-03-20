using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHGroup.DAL.Entities
{

    public class Lecturer : Person
    {
        [Required]
        public DateOnly JoinDate { get; set; }
    }
}
