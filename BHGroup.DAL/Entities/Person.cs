using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BHGroup.DAL.Entities
{

    public class Person
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] // auto increment
        public enum EStatus { active, inactive}
        public enum EGender { male,female}
        [Required]
        [Column("last_name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        [Column("first_name")]
        public string FirstName { get; set; }

        public EGender Gender { get; set; }
        [Required]
        [StringLength(8)]
        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }
        [Column("join_date")]
        public DateTime JoinDate { get; set; }
        [Required]
        [Column("status")]
        public EStatus Status { get; set; } //assume true is active and false is inactive

    }
}
