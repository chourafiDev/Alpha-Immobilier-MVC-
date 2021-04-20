namespace Alpha_Immobilier_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateColumnImageListing2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Listings", "imageListing", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Listings", "imageListing", c => c.String());
        }
    }
}
