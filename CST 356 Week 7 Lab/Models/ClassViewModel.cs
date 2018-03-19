using System;
using System.ComponentModel.DataAnnotations;

namespace CST_356_Week_7_Lab.Models
{
    public class ClassViewModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int CRN { get; set; }
        [Required]
        [Display(Name = "Class")]
        public string ClassName { get; set; }
        [Required]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Class Length")]
        public TimeSpan ClassLength { get; set; }

        [Required]
        public String Instructor { get; set; }

        public string UserID { get; set; }
    }
}