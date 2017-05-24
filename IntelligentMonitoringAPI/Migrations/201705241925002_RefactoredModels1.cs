namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactoredModels1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DailyStatistics", "CreatedTimeStamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.DailyStatistics", "AverageSignalStrength", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DailyStatistics", "MaxSignalStrength", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DailyStatistics", "MinSignalStrength", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DailyStatistics", "SignalMeasurementUnit", c => c.String());
            AddColumn("dbo.DeviceNetworks", "AuthToken", c => c.String());
            AddColumn("dbo.DeviceNetworks", "DateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Devices", "UpdatedTimeStamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.Devices", "SignalMeasurementUnit", c => c.String());
            AddColumn("dbo.Devices", "SensorCount", c => c.Int(nullable: false));
            AddColumn("dbo.FailurePronedDevices", "SignalMeasurementUnit", c => c.String());
            AddColumn("dbo.FailurePronedDevices", "UpdatedTimeStamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.HourlyStatistics", "SignalMeasurementUnit", c => c.String());
            AddColumn("dbo.LocationResources", "UpdatedTimeStamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.LocationResources", "ChildPositionCount", c => c.Int(nullable: false));
            AddColumn("dbo.Locations", "ChildLocationCount", c => c.Int(nullable: false));
            AddColumn("dbo.Positions", "UpdatedTimeStamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.Positions", "ParentLocationId", c => c.String(maxLength: 50));
            AddColumn("dbo.Positions", "ParentLocationName", c => c.String());
            AddColumn("dbo.SensorMeasurements", "CreatedDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.SensorMeasurements", "MeasurementUnit", c => c.String(maxLength: 200));
            AddColumn("dbo.Sensors", "UpdatedTimeStamp", c => c.DateTime(nullable: false));
            DropColumn("dbo.DailyStatistics", "TimeStamp");
            DropColumn("dbo.DailyStatistics", "Average");
            DropColumn("dbo.DailyStatistics", "Peak");
            DropColumn("dbo.DailyStatistics", "Low");
            DropColumn("dbo.SensorMeasurements", "UnixTimestamp");
            DropColumn("dbo.SensorMeasurements", "Unit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SensorMeasurements", "Unit", c => c.String(maxLength: 200));
            AddColumn("dbo.SensorMeasurements", "UnixTimestamp", c => c.Long(nullable: false));
            AddColumn("dbo.DailyStatistics", "Low", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DailyStatistics", "Peak", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DailyStatistics", "Average", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.DailyStatistics", "TimeStamp", c => c.DateTime());
            DropColumn("dbo.Sensors", "UpdatedTimeStamp");
            DropColumn("dbo.SensorMeasurements", "MeasurementUnit");
            DropColumn("dbo.SensorMeasurements", "CreatedDateTime");
            DropColumn("dbo.Positions", "ParentLocationName");
            DropColumn("dbo.Positions", "ParentLocationId");
            DropColumn("dbo.Positions", "UpdatedTimeStamp");
            DropColumn("dbo.Locations", "ChildLocationCount");
            DropColumn("dbo.LocationResources", "ChildPositionCount");
            DropColumn("dbo.LocationResources", "UpdatedTimeStamp");
            DropColumn("dbo.HourlyStatistics", "SignalMeasurementUnit");
            DropColumn("dbo.FailurePronedDevices", "UpdatedTimeStamp");
            DropColumn("dbo.FailurePronedDevices", "SignalMeasurementUnit");
            DropColumn("dbo.Devices", "SensorCount");
            DropColumn("dbo.Devices", "SignalMeasurementUnit");
            DropColumn("dbo.Devices", "UpdatedTimeStamp");
            DropColumn("dbo.DeviceNetworks", "DateTime");
            DropColumn("dbo.DeviceNetworks", "AuthToken");
            DropColumn("dbo.DailyStatistics", "SignalMeasurementUnit");
            DropColumn("dbo.DailyStatistics", "MinSignalStrength");
            DropColumn("dbo.DailyStatistics", "MaxSignalStrength");
            DropColumn("dbo.DailyStatistics", "AverageSignalStrength");
            DropColumn("dbo.DailyStatistics", "CreatedTimeStamp");
        }
    }
}
