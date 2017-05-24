namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeDateTimesNullable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomEvents", "CreatedTimeStamp", c => c.DateTime());
            AddColumn("dbo.DataCollectors", "UpdatedTimeStamp", c => c.DateTime());
            AddColumn("dbo.DeviceNetworks", "UpdatedTimeStamp", c => c.DateTime());
            AlterColumn("dbo.DailyStatistics", "CreatedTimeStamp", c => c.DateTime());
            AlterColumn("dbo.Devices", "UpdatedTimeStamp", c => c.DateTime());
            AlterColumn("dbo.FailurePronedDevices", "UpdatedTimeStamp", c => c.DateTime());
            AlterColumn("dbo.LocationResources", "UpdatedTimeStamp", c => c.DateTime());
            AlterColumn("dbo.Positions", "UpdatedTimeStamp", c => c.DateTime());
            AlterColumn("dbo.RealTimeTokens", "Token", c => c.String());
            AlterColumn("dbo.RealTimeTokens", "CreatedTimeStamp", c => c.DateTime());
            AlterColumn("dbo.RealTimeTokens", "ExpiresTimeStamp", c => c.DateTime());
            AlterColumn("dbo.SensorMeasurements", "CreatedDateTime", c => c.DateTime());
            AlterColumn("dbo.Sensors", "UpdatedTimeStamp", c => c.DateTime());
            DropColumn("dbo.CustomEvents", "CreatedDateTime");
            DropColumn("dbo.DeviceNetworks", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeviceNetworks", "DateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.CustomEvents", "CreatedDateTime", c => c.DateTime());
            AlterColumn("dbo.Sensors", "UpdatedTimeStamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SensorMeasurements", "CreatedDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RealTimeTokens", "ExpiresTimeStamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RealTimeTokens", "CreatedTimeStamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RealTimeTokens", "Token", c => c.String(maxLength: 50));
            AlterColumn("dbo.Positions", "UpdatedTimeStamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LocationResources", "UpdatedTimeStamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FailurePronedDevices", "UpdatedTimeStamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Devices", "UpdatedTimeStamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DailyStatistics", "CreatedTimeStamp", c => c.DateTime(nullable: false));
            DropColumn("dbo.DeviceNetworks", "UpdatedTimeStamp");
            DropColumn("dbo.DataCollectors", "UpdatedTimeStamp");
            DropColumn("dbo.CustomEvents", "CreatedTimeStamp");
        }
    }
}
