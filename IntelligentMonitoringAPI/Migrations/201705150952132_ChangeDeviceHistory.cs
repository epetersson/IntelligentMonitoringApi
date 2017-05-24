namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDeviceHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HourlyStatistics", "ContactLost", c => c.Boolean(nullable: false));
            DropColumn("dbo.HourlyStatistics", "ContactLostCount");
            DropColumn("dbo.HourlyStatistics", "ContactLostTimeStamp");
            DropColumn("dbo.HourlyStatistics", "LastDeviceState");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HourlyStatistics", "LastDeviceState", c => c.Boolean(nullable: false));
            AddColumn("dbo.HourlyStatistics", "ContactLostTimeStamp", c => c.String());
            AddColumn("dbo.HourlyStatistics", "ContactLostCount", c => c.String());
            DropColumn("dbo.HourlyStatistics", "ContactLost");
        }
    }
}
