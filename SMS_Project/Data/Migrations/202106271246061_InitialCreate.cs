namespace SMS_Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Strenght = c.Int(),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Age = c.Int(nullable: false),
                        Address = c.String(),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        TeacherId = c.Int(nullable: false),
                        Name = c.String(),
                        Duration = c.Int(nullable: false),
                        Fees = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        Hobby = c.String(),
                        Age = c.Int(nullable: false),
                        Address = c.String(),
                        StudentAccountId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Course_TeacherId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_TeacherId)
                .Index(t => t.Course_TeacherId);
            
            CreateTable(
                "dbo.StudentAccounts",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        Name = c.String(),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentTeachers",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Teacher_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Teacher_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Teacher_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.StudentTeachers", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.StudentTeachers", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.StudentAccounts", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "Course_TeacherId", "dbo.Courses");
            DropForeignKey("dbo.Sections", "ClassId", "dbo.Classes");
            DropIndex("dbo.StudentTeachers", new[] { "Teacher_Id" });
            DropIndex("dbo.StudentTeachers", new[] { "Student_Id" });
            DropIndex("dbo.StudentAccounts", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "Course_TeacherId" });
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            DropIndex("dbo.Sections", new[] { "ClassId" });
            DropIndex("dbo.Classes", new[] { "TeacherId" });
            DropTable("dbo.StudentTeachers");
            DropTable("dbo.StudentAccounts");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
            DropTable("dbo.Teachers");
            DropTable("dbo.Sections");
            DropTable("dbo.Classes");
        }
    }
}
