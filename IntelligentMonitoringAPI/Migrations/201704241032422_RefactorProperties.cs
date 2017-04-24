namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorProperties : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Devices");
            DropPrimaryKey("dbo.Locations");
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
            
            AddColumn("dbo.Devices", "SigmaId", c => c.String());
            AddColumn("dbo.Devices", "LocationId", c => c.Int(nullable: false));
            AddColumn("dbo.Locations", "SigmaId", c => c.String());
            AlterColumn("dbo.Devices", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Locations", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Locations", "ParentLocationId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Devices", "Id");
            AddPrimaryKey("dbo.Locations", "Id");
            AddForeignKey("dbo.Devices", "LocationId", "dbo.Locations", "Id");
            AddForeignKey("dbo.Sensors", "DeviceId", "dbo.Devices", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Locations");
            DropPrimaryKey("dbo.Devices");
            AlterColumn("dbo.Locations", "ParentLocationId", c => c.String());
            AlterColumn("dbo.Locations", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Devices", "Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Locations", "SigmaId");
            DropColumn("dbo.Devices", "LocationId");
            DropColumn("dbo.Devices", "SigmaId");
            DropTable("dbo.Sensors");
            AddPrimaryKey("dbo.Locations", "Id");
            AddPrimaryKey("dbo.Devices", "Id");
        }
    }
}
