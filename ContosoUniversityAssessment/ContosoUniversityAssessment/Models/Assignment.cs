using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversityAssessment.Models
{
    public class Assignment
    {
        public int AssignmentID { get; set; }
        public int CourseID { get; set; }
        public string AssignmentName { get; set; }
        public string DueDate { get; set; }
    }
}