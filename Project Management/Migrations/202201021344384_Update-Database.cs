namespace Project_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faculty",
                c => new
                    {
                        name = c.String(nullable: false, maxLength: 128),
                        listMajor = c.String(),
                    })
                .PrimaryKey(t => t.name);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        password = c.String(),
                        name = c.String(),
                        gender = c.String(),
                        phone = c.String(),
                        address = c.String(),
                        birthday = c.DateTime(nullable: false),
                        subject = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        idProject = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                        subject = c.String(),
                        course = c.String(),
                        source = c.String(),
                        dateStart = c.DateTime(),
                        dateEnd = c.DateTime(),
                        mark = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.idProject);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        MSSV = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                        gender = c.String(),
                        birthday = c.DateTime(nullable: false),
                        address = c.String(),
                        numberPhone = c.String(),
                        faculty = c.String(),
                        major = c.String(),
                        Class = c.String(),
                        course = c.String(),
                        Progress_idProject = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MSSV)
                .ForeignKey("dbo.Progress", t => t.Progress_idProject)
                .Index(t => t.Progress_idProject);
            
            CreateTable(
                "dbo.Report",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        comment = c.String(),
                        Project_idProject = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Project", t => t.Project_idProject)
                .Index(t => t.Project_idProject);
            
            CreateTable(
                "dbo.Progress",
                c => new
                    {
                        idProject = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        dateStart = c.DateTime(nullable: false),
                        finishTime = c.DateTime(nullable: false),
                        submitTime = c.DateTime(nullable: false),
                        mark = c.Single(nullable: false),
                        finished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idProject);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        id = c.Int(nullable: false),
                        subject = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ProjectInstructors",
                c => new
                    {
                        Project_idProject = c.String(nullable: false, maxLength: 128),
                        Instructor_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Project_idProject, t.Instructor_id })
                .ForeignKey("dbo.Project", t => t.Project_idProject, cascadeDelete: true)
                .ForeignKey("dbo.Teacher", t => t.Instructor_id, cascadeDelete: true)
                .Index(t => t.Project_idProject)
                .Index(t => t.Instructor_id);
            
            CreateTable(
                "dbo.StudentProjects",
                c => new
                    {
                        Student_MSSV = c.String(nullable: false, maxLength: 128),
                        Project_idProject = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Student_MSSV, t.Project_idProject })
                .ForeignKey("dbo.Student", t => t.Student_MSSV, cascadeDelete: true)
                .ForeignKey("dbo.Project", t => t.Project_idProject, cascadeDelete: true)
                .Index(t => t.Student_MSSV)
                .Index(t => t.Project_idProject);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "Progress_idProject", "dbo.Progress");
            DropForeignKey("dbo.Report", "Project_idProject", "dbo.Project");
            DropForeignKey("dbo.StudentProjects", "Project_idProject", "dbo.Project");
            DropForeignKey("dbo.StudentProjects", "Student_MSSV", "dbo.Student");
            DropForeignKey("dbo.ProjectInstructors", "Instructor_id", "dbo.Teacher");
            DropForeignKey("dbo.ProjectInstructors", "Project_idProject", "dbo.Project");
            DropIndex("dbo.StudentProjects", new[] { "Project_idProject" });
            DropIndex("dbo.StudentProjects", new[] { "Student_MSSV" });
            DropIndex("dbo.ProjectInstructors", new[] { "Instructor_id" });
            DropIndex("dbo.ProjectInstructors", new[] { "Project_idProject" });
            DropIndex("dbo.Report", new[] { "Project_idProject" });
            DropIndex("dbo.Student", new[] { "Progress_idProject" });
            DropTable("dbo.StudentProjects");
            DropTable("dbo.ProjectInstructors");
            DropTable("dbo.Subject");
            DropTable("dbo.Progress");
            DropTable("dbo.Report");
            DropTable("dbo.Student");
            DropTable("dbo.Project");
            DropTable("dbo.Teacher");
            DropTable("dbo.Faculty");
        }
    }
}
