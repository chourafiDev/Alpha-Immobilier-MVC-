namespace Alpha_Immobilier_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableListing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Listings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        DescListing = c.String(nullable: false),
                        imageListing = c.String(nullable: false),
                        PrixListing = c.Double(nullable: false),
                        CityListing = c.String(nullable: false),
                        AdressListing = c.String(nullable: false),
                        NbrChambre = c.Int(nullable: false),
                        NbrBath = c.Int(nullable: false),
                        NbrBed = c.Int(nullable: false),
                        size = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                        TypeListing_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.TypeListings", t => t.TypeListing_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.TypeListing_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Listings", "TypeListing_Id", "dbo.TypeListings");
            DropForeignKey("dbo.Listings", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Listings", new[] { "TypeListing_Id" });
            DropIndex("dbo.Listings", new[] { "CategoryId" });
            DropTable("dbo.Listings");
        }
    }
}
