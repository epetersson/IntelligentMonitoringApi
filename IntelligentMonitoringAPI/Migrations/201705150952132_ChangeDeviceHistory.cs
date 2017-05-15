namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDeviceHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeviceHistories", "ContactLost", c => c.Boolean(nullable: false));
            DropColumn("dbo.DeviceHistories", "ContactLostCount");
            DropColumn("dbo.DeviceHistories", "ContactLostTimeStamp");
            DropColumn("dbo.DeviceHistories", "LastDeviceState");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeviceHistories", "LastDeviceState", c => c.Boolean(nullable: false));
            AddColumn("dbo.DeviceHistories", "ContactLostTimeStamp", c => c.String());
            AddColumn("dbo.DeviceHistories", "ContactLostCount", c => c.String());
            DropColumn("dbo.DeviceHistories", "ContactLost");
        }
    }
}
