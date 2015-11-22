namespace ContosoUniversityAssessment.Migrations
{
    using ContosoUniversityAssessment.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContosoUniversityAssessment.DAL.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContosoUniversityAssessment.DAL.SchoolContext context)
        {
            var students = new List<Student>
            {
                new Student { FirstName = "Smith", LastName = "Alexander"},
                new Student { FirstName = "Chris", LastName = "Norman" },
                new Student { FirstName = "Joe", LastName = "Bloggs" }
            };
            students.ForEach(s => context.Students.AddOrUpdate(p => p.StudentID, s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course { CourseName = "Chemistry", Credits = 15 },
                new Course { CourseName = "Calculus", Credits = 15 },
                new Course { CourseName = "Physics", Credits = 15 }
            };
            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.CourseID, s));
            context.SaveChanges();

            var assignments = new List<Assignment>
            {
                new Assignment { AssignmentName = "Chemistry Assignment 1", DueDate = "1/1/2016", CourseID = courses.Single(s => s.CourseName == "Chemistry").CourseID },
                new Assignment { AssignmentName = "Chemistry Assignment 2", DueDate = "7/1/2016", CourseID = courses.Single(s => s.CourseName == "Chemistry").CourseID },
                new Assignment { AssignmentName = "Calculus Assignment 1", DueDate = "1/1/2016", CourseID = courses.Single(s => s.CourseName == "Calculus").CourseID }
            };
            assignments.ForEach(s => context.Assignment.AddOrUpdate(p => p.AssignmentID, s));
            context.SaveChanges();
        }
    }
}
