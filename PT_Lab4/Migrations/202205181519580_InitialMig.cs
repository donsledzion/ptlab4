namespace PT_Lab4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apartments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AptNo = c.String(),
                        Floor = c.Int(nullable: false),
                        Area = c.Single(nullable: false),
                        Owner_Id = c.Int(),
                        Building_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Owners", t => t.Owner_Id)
                .ForeignKey("dbo.Buildings", t => t.Building_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.Building_Id);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        StreetName = c.String(),
                        StreetNo = c.String(),
                        FloorsCount = c.Int(nullable: false),
                        AptsCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Apartments", "Building_Id", "dbo.Buildings");
            DropForeignKey("dbo.Apartments", "Owner_Id", "dbo.Owners");
            DropIndex("dbo.Apartments", new[] { "Building_Id" });
            DropIndex("dbo.Apartments", new[] { "Owner_Id" });
            DropTable("dbo.Buildings");
            DropTable("dbo.Owners");
            DropTable("dbo.Apartments");
        }
    }
}
