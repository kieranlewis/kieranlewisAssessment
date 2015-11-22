namespace ContosoUniversityAssessment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignment",
                c => new
                    {
                        AssignmentID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        AssignmentName = c.String(unicode: false),
                        DueDate = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.AssignmentID);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseName = c.String(unicode: false),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        LastName = c.String(unicode: false),
                        FirstName = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.StudentWork",
                c => new
                    {
                        StudentWorkID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        LinkName = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.StudentWorkID)
                .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentWork", "StudentID", "dbo.Student");
            DropIndex("dbo.StudentWork", new[] { "StudentID" });
            DropTable("dbo.StudentWork");
            DropTable("dbo.Student");
            DropTable("dbo.Course");
            DropTable("dbo.Assignment");
        }
    }
}
