using System.ComponentModel.DataAnnotations;

namespace POE_FINAL_PROG6212.Models
{
    public class Module
    {
        [Key]
        public int ModuleId { get; set; }
        public int hoursWorked { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int noOfCredits { get; set; }
        public int classHoursPerWeek { get; set; }
        public int remaininghours { get; set; }
        public double selfStudyHours { get; set; }
        public int semNoOfWeeks { get; set; }
        public string studentID { get; set; }
    }
}
