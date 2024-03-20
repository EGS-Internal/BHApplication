using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BHGroup.DAL.Entities
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // auto increment
        [Required]  //notnull field
        [Key]       //entity primary key
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(8)]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        public  bool Status { get; set; } //assume true is active and false is inactive

    }
}
