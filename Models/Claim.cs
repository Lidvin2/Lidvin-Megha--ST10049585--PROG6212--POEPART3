using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PROG6212_POEPART3.Models
{
    public class Claim
    {
        //This is the table claim with that I can add a little limited of number row on the tables.
        [Key]
        public int ClaimID { get; set; }
        [Required]
        public string ClaimSurname { get; set; }
        [Required]
        public DateTime ClaimDate { get; set; }
        [Required]
        [Range(1, 200)]
        public int HoursWorked { get; set; }
        [Required]
        [Range(1, 200000)]
        public int HourlyRate { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
