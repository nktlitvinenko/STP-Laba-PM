namespace ProjectManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Uri = c.String(),
                        Issue_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Issues", t => t.Issue_Id)
                .Index(t => t.Issue_Id);
            
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Environment = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Priority = c.Int(nullable: false),
                        Parent_Id = c.Guid(),
                        Project_Id = c.Guid(),
                        Sprint_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Issues", t => t.Parent_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .ForeignKey("dbo.Sprints", t => t.Sprint_Id)
                .Index(t => t.Parent_Id)
                .Index(t => t.Project_Id)
                .Index(t => t.Sprint_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Text = c.String(),
                        Issue_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Issues", t => t.Issue_Id)
                .Index(t => t.Issue_Id);
            
            CreateTable(
                "dbo.Components",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sprints",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        FinishTime = c.DateTime(nullable: false),
                        Project_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IssueComponent",
                c => new
                    {
                        IssueId = c.Guid(nullable: false),
                        ComponentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.IssueId, t.ComponentId })
                .ForeignKey("dbo.Issues", t => t.IssueId, cascadeDelete: true)
                .ForeignKey("dbo.Components", t => t.ComponentId, cascadeDelete: true)
                .Index(t => t.IssueId)
                .Index(t => t.ComponentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Attachments", "Issue_Id", "dbo.Issues");
            DropForeignKey("dbo.Sprints", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Issues", "Sprint_Id", "dbo.Sprints");
            DropForeignKey("dbo.Issues", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.IssueComponent", "ComponentId", "dbo.Components");
            DropForeignKey("dbo.IssueComponent", "IssueId", "dbo.Issues");
            DropForeignKey("dbo.Comments", "Issue_Id", "dbo.Issues");
            DropForeignKey("dbo.Issues", "Parent_Id", "dbo.Issues");
            DropIndex("dbo.IssueComponent", new[] { "ComponentId" });
            DropIndex("dbo.IssueComponent", new[] { "IssueId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Sprints", new[] { "Project_Id" });
            DropIndex("dbo.Comments", new[] { "Issue_Id" });
            DropIndex("dbo.Issues", new[] { "Sprint_Id" });
            DropIndex("dbo.Issues", new[] { "Project_Id" });
            DropIndex("dbo.Issues", new[] { "Parent_Id" });
            DropIndex("dbo.Attachments", new[] { "Issue_Id" });
            DropTable("dbo.IssueComponent");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Teams");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Sprints");
            DropTable("dbo.Projects");
            DropTable("dbo.Components");
            DropTable("dbo.Comments");
            DropTable("dbo.Issues");
            DropTable("dbo.Attachments");
        }
    }
}
