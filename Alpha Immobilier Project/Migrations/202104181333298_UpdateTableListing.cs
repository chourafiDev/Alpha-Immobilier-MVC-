namespace Alpha_Immobilier_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableListing : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Listings", "TypeListing_Id", "dbo.TypeListings");
            DropIndex("dbo.Listings", new[] { "TypeListing_Id" });
            RenameColumn(table: "dbo.Listings", name: "TypeListing_Id", newName: "TypeListingId");
            AlterColumn("dbo.Listings", "TypeListingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Listings", "TypeListingId");
            AddForeignKey("dbo.Listings", "TypeListingId", "dbo.TypeListings", "Id", cascadeDelete: true);
            DropColumn("dbo.Listings", "TypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Listings", "TypeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Listings", "TypeListingId", "dbo.TypeListings");
            DropIndex("dbo.Listings", new[] { "TypeListingId" });
            AlterColumn("dbo.Listings", "TypeListingId", c => c.Int());
            RenameColumn(table: "dbo.Listings", name: "TypeListingId", newName: "TypeListing_Id");
            CreateIndex("dbo.Listings", "TypeListing_Id");
            AddForeignKey("dbo.Listings", "TypeListing_Id", "dbo.TypeListings", "Id");
        }
    }
}
