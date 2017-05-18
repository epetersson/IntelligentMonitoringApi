namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEventCountToDevice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "EventCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "EventCount");
        }
    }
}
