namespace Alpha_Immobilier_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDateCreationColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DateCreation", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DateCreation");
        }
    }
}
