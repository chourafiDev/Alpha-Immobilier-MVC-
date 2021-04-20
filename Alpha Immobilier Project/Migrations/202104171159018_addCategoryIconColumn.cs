namespace Alpha_Immobilier_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCategoryIconColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryIcon", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "CategoryIcon");
        }
    }
}
