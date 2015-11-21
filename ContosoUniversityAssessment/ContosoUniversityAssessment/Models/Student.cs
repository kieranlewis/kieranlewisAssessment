using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversityAssessment.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public virtual ICollection<StudentWork> StudentWorks { get; set; }
    }
}