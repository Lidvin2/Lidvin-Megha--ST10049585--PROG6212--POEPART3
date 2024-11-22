using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PROG6212_POEPART3.Models
{
    public class Lecturer
    {
        //I create the table lecturer because I need to put some elements in the feedback and all part is done well.
        [Key]
        public int LecturerID { get; set; }
        [Required]
        [Range(1, 200)]
        public int HoursWorked { get; set; }
        [Required]
        [Range(1, 20000)]
        public int HourlyRate { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public string AdditionalNotes { get; set; }
        [Required]
        public string UploadFilePath { get; set; }
    }
}
