namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDeviceHistoryProperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HourlyStatistics", "ContactLostTotalTime", c => c.Long(nullable: false));
            RenameColumn("dbo.DailyStatistics", "FailureProneDeviceId", "DeviceId");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HourlyStatistics", "ContactLostTotalTime", c => c.String());
            RenameColumn("dbo.DailyStatistics", "DeviceId", "FailureProneDeviceId");
        }
    }
}
