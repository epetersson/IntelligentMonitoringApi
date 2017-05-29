namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAverageBattery : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccumulatedStatistics", "AverageBatteryLevel", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.FailurePronedDevices", "AverageBatteryLevel", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.FailurePronedDevices", "CreatedTimeStamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FailurePronedDevices", "CreatedTimeStamp", c => c.DateTime());
            DropColumn("dbo.FailurePronedDevices", "AverageBatteryLevel");
            DropColumn("dbo.AccumulatedStatistics", "AverageBatteryLevel");
        }
    }
}
