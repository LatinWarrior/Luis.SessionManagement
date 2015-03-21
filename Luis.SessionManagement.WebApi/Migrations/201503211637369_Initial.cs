namespace Luis.SessionManagement.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetName = c.String(),
                        Province = c.String(),
                        City = c.String(),
                        State = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Presenters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsProctor = c.Boolean(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        AddressId = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.SessionPresenters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.Int(nullable: false),
                        PresenterId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Presenters", t => t.PresenterId, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.SessionId, cascadeDelete: true)
                .Index(t => t.SessionId)
                .Index(t => t.PresenterId);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        SessionLevelId = c.Int(nullable: false),
                        Description = c.String(),
                        SessionCategoryId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        HasProctors = c.Boolean(nullable: false),
                        SessionDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SessionCategories", t => t.SessionCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.SessionLevels", t => t.SessionLevelId, cascadeDelete: true)
                .Index(t => t.SessionLevelId)
                .Index(t => t.SessionCategoryId);
            
            CreateTable(
                "dbo.SessionCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SessionLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SessionPresenters", "SessionId", "dbo.Sessions");
            DropForeignKey("dbo.Sessions", "SessionLevelId", "dbo.SessionLevels");
            DropForeignKey("dbo.Sessions", "SessionCategoryId", "dbo.SessionCategories");
            DropForeignKey("dbo.SessionPresenters", "PresenterId", "dbo.Presenters");
            DropForeignKey("dbo.Presenters", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Sessions", new[] { "SessionCategoryId" });
            DropIndex("dbo.Sessions", new[] { "SessionLevelId" });
            DropIndex("dbo.SessionPresenters", new[] { "PresenterId" });
            DropIndex("dbo.SessionPresenters", new[] { "SessionId" });
            DropIndex("dbo.Presenters", new[] { "AddressId" });
            DropTable("dbo.SessionLevels");
            DropTable("dbo.SessionCategories");
            DropTable("dbo.Sessions");
            DropTable("dbo.SessionPresenters");
            DropTable("dbo.Presenters");
            DropTable("dbo.Addresses");
        }
    }
}
