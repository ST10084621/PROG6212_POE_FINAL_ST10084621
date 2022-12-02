using System.ComponentModel.DataAnnotations;
using System;

namespace POE_FINAL_PROG6212.Models
{
    public class Semester
    {
        [Key]
        public int SemesterId { get; set; }
        public string semesterName { get; set; }
        public int noOfWeeks { get; set; }
        [DataType(DataType.Date)]
        public DateTime startDate { get; set; }
        public string studentID { get; set; }
        public Semester()
        {

        }
    }
}
