namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeviceNetworkIdAddedToAll : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthorizationTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Token = c.String(),
                        CreatedTimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AccumulatedStatistics", "DeviceNetworkId", c => c.String(maxLength: 50));
            AddColumn("dbo.CustomEvents", "DeviceNetworkId", c => c.String(maxLength: 50));
            AddColumn("dbo.DailyStatistics", "DeviceNetworkId", c => c.String(maxLength: 50));
            AddColumn("dbo.DataCollectors", "DeviceNetworkId", c => c.String(maxLength: 50));
            AddColumn("dbo.DeviceNetworks", "DeviceNetworkId", c => c.String(maxLength: 50));
            AddColumn("dbo.Devices", "DeviceNetworkId", c => c.String(maxLength: 50));
            AddColumn("dbo.Events", "DeviceNetworkId", c => c.String(maxLength: 50));
            AddColumn("dbo.FailurePronedDevices", "DeviceNetworkId", c => c.String(maxLength: 50));
            AddColumn("dbo.FailurePronedDevices", "PublicBoolHandled", c => c.Boolean(nullable: false));
            AddColumn("dbo.HourlyStatistics", "DeviceNetworkId", c => c.String(maxLength: 50));
            AddColumn("dbo.LocationResources", "DeviceNetworkId", c => c.String(maxLength: 50));
            AddColumn("dbo.Positions", "DeviceNetworkId", c => c.String(maxLength: 50));
            AddColumn("dbo.SensorMeasurements", "DeviceNetworkId", c => c.String(maxLength: 50));
            AddColumn("dbo.Sensors", "DeviceNetworkId", c => c.String(maxLength: 50));



        }
        
        public override void Down()
        {

            DropColumn("dbo.Sensors", "DeviceNetworkId");
            DropColumn("dbo.SensorMeasurements", "DeviceNetworkId");
            DropColumn("dbo.Positions", "DeviceNetworkId");
            DropColumn("dbo.LocationResources", "DeviceNetworkId");
            DropColumn("dbo.HourlyStatistics", "DeviceNetworkId");
            DropColumn("dbo.FailurePronedDevices", "PublicBoolHandled");
            DropColumn("dbo.FailurePronedDevices", "DeviceNetworkId");
            DropColumn("dbo.Events", "DeviceNetworkId");
            DropColumn("dbo.Devices", "DeviceNetworkId");
            DropColumn("dbo.DeviceNetworks", "DeviceNetworkId");
            DropColumn("dbo.DataCollectors", "DeviceNetworkId");
            DropColumn("dbo.DailyStatistics", "DeviceNetworkId");
            DropColumn("dbo.CustomEvents", "DeviceNetworkId");
            DropColumn("dbo.AccumulatedStatistics", "DeviceNetworkId");
            DropTable("dbo.AuthorizationTokens");
        }
    }
}
