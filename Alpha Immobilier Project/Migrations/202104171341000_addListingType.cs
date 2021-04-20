namespace Alpha_Immobilier_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addListingType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypeListings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TypeListings");
        }
    }
}
