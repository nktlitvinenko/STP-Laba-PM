namespace ProjectManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_subissues : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Issues", "Parent_Id", "dbo.Issues");
            DropIndex("dbo.Issues", new[] { "Parent_Id" });
            CreateTable(
                "dbo.SubIssues",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        IsResolved = c.Boolean(nullable: false),
                        Issue_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Issues", t => t.Issue_Id)
                .Index(t => t.Issue_Id);
            
            AddColumn("dbo.Issues", "Assigne_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Issues", "Reporter_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Comments", "Author_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Projects", "Lead_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Projects", "ProjectManager_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Project_Id", c => c.Guid());
            AddColumn("dbo.AspNetUsers", "Team_Id", c => c.Guid());
            CreateIndex("dbo.Issues", "Assigne_Id");
            CreateIndex("dbo.Issues", "Reporter_Id");
            CreateIndex("dbo.AspNetUsers", "Project_Id");
            CreateIndex("dbo.AspNetUsers", "Team_Id");
            CreateIndex("dbo.Comments", "Author_Id");
            CreateIndex("dbo.Projects", "Lead_Id");
            CreateIndex("dbo.Projects", "ProjectManager_Id");
            AddForeignKey("dbo.Issues", "Assigne_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Comments", "Author_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Projects", "Lead_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Projects", "ProjectManager_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "Project_Id", "dbo.Projects", "Id");
            AddForeignKey("dbo.Issues", "Reporter_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "Team_Id", "dbo.Teams", "Id");
            DropColumn("dbo.Issues", "Parent_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Issues", "Parent_Id", c => c.Guid());
            DropForeignKey("dbo.AspNetUsers", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.SubIssues", "Issue_Id", "dbo.Issues");
            DropForeignKey("dbo.Issues", "Reporter_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Projects", "ProjectManager_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Projects", "Lead_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Issues", "Assigne_Id", "dbo.AspNetUsers");
            DropIndex("dbo.SubIssues", new[] { "Issue_Id" });
            DropIndex("dbo.Projects", new[] { "ProjectManager_Id" });
            DropIndex("dbo.Projects", new[] { "Lead_Id" });
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Team_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Project_Id" });
            DropIndex("dbo.Issues", new[] { "Reporter_Id" });
            DropIndex("dbo.Issues", new[] { "Assigne_Id" });
            DropColumn("dbo.AspNetUsers", "Team_Id");
            DropColumn("dbo.AspNetUsers", "Project_Id");
            DropColumn("dbo.Projects", "ProjectManager_Id");
            DropColumn("dbo.Projects", "Lead_Id");
            DropColumn("dbo.Comments", "Author_Id");
            DropColumn("dbo.Issues", "Reporter_Id");
            DropColumn("dbo.Issues", "Assigne_Id");
            DropTable("dbo.SubIssues");
            CreateIndex("dbo.Issues", "Parent_Id");
            AddForeignKey("dbo.Issues", "Parent_Id", "dbo.Issues", "Id");
        }
    }
}
