namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyToPosition : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Positions", "ParentLocationId", "dbo.Locations", "Id");
        }
        
        public override void Down()
        {
        }
    }
}
