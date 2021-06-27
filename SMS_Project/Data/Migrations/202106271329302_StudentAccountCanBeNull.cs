namespace SMS_Project.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentAccountCanBeNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "StudentAccountId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "StudentAccountId", c => c.Int(nullable: false));
        }
    }
}
