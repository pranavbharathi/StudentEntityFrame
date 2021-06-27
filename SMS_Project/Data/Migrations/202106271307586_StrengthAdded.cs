namespace SMS_Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StrengthAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sections", "Strength", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sections", "Strength");
        }
    }
}
