namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecreatingDb : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.SensorMeasurements");
            DropTable("dbo.Events");
            DropTable("dbo.Sensors");
            DropTable("dbo.Devices");
            DropTable("dbo.Positions");
            DropTable("dbo.LocationResources");
            DropTable("dbo.Locations");
            DropTable("dbo.DeviceNetworks");   
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Sensors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SigmaId = c.String(),
                        DeviceName = c.String(),
                        SensorType = c.String(),
                        Name = c.String(),
                        DeviceId = c.Int(nullable: false),
                        SensorTypeId = c.String(),
                        IsVirtual = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SensorMeasurements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        SensorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SigmaId = c.String(),
                        Name = c.String(),
                        X = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Y = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Z = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LocationResourceId = c.Int(nullable: false),
                        EntityId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SigmaId = c.String(),
                        Name = c.String(),
                        ParentLocationName = c.String(),
                        ParentLocationId = c.Int(),
                        LocationType = c.Int(nullable: false),
                        DeviceNetworkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LocationResources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SigmaId = c.String(),
                        Name = c.String(),
                        Label = c.String(),
                        Path = c.String(),
                        StartPositionX = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartPositionY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartPositionZ = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartZoomLevel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SigmaId = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                        ResetDateTime = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Information = c.String(),
                        EventCategoryId = c.String(),
                        EventCategoryName = c.String(),
                        EventCategoryTypeId = c.Int(nullable: false),
                        RuleId = c.String(),
                        RuleName = c.String(),
                        SeverityLevel = c.Int(nullable: false),
                        RuleDescription = c.String(),
                        TriggerId = c.String(),
                        TriggerName = c.String(),
                        TriggerLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TriggerValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ResetValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SensorId = c.Int(nullable: false),
                        SensorName = c.String(),
                        DeviceId = c.Int(nullable: false),
                        DeviceName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SigmaId = c.String(),
                        LocationName = c.String(),
                        IsRegistered = c.Boolean(nullable: false),
                        LastSeen = c.Long(nullable: false),
                        ContactLost = c.Boolean(nullable: false),
                        ContactLostTime = c.Long(nullable: false),
                        Name = c.String(),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeviceNetworks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SigmaId = c.String(),
                        Name = c.String(),
                        TenantName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.__MigrationHistory",
                c => new
                    {
                        MigrationId = c.String(nullable: false, maxLength: 150),
                        ContextKey = c.String(nullable: false, maxLength: 300),
                        Model = c.Binary(nullable: false),
                        ProductVersion = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => new { t.MigrationId, t.ContextKey });
            
        }
    }
}
