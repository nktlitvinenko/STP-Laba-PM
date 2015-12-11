namespace ProjectManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubIssues", "Issue_Id", "dbo.Issues");
            DropIndex("dbo.SubIssues", new[] { "Issue_Id" });
            AddColumn("dbo.Issues", "Parent_Id", c => c.Guid());
            CreateIndex("dbo.Issues", "Parent_Id");
            AddForeignKey("dbo.Issues", "Parent_Id", "dbo.Issues", "Id");
            DropTable("dbo.SubIssues");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubIssues",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        IsResolved = c.Boolean(nullable: false),
                        Issue_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Issues", "Parent_Id", "dbo.Issues");
            DropIndex("dbo.Issues", new[] { "Parent_Id" });
            DropColumn("dbo.Issues", "Parent_Id");
            CreateIndex("dbo.SubIssues", "Issue_Id");
            AddForeignKey("dbo.SubIssues", "Issue_Id", "dbo.Issues", "Id");
        }
    }
}
