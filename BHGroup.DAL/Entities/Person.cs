using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BHGroup.DAL.Entities
{

    public class Person
    {
        public enum EGender
        {
            Male,
            Female,
        }

        public enum EStatus
        {
            Active,
            Inactive
        }

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
        [DefaultValue(EStatus.Active)]
        public EStatus Status { get; set; }

        [Required]
        [Column("deleteStatus")]
        public int DeleteStatus { get; set; } = 0; // 1 is deleted

    }
}
