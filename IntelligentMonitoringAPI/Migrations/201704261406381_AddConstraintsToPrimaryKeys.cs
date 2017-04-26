namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConstraintsToPrimaryKeys : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.DeviceNetworks");
            DropPrimaryKey("dbo.LocationResources");
            DropPrimaryKey("dbo.Locations");
            DropPrimaryKey("dbo.Positions");
            AlterColumn("dbo.DeviceNetworks", "Id", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.LocationResources", "Id", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Locations", "Id", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Locations", "DeviceNetworkId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Positions", "Id", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Positions", "LocationResourceId", c => c.String(maxLength: 50));
            AddPrimaryKey("dbo.DeviceNetworks", "Id");
            AddPrimaryKey("dbo.LocationResources", "Id");
            AddPrimaryKey("dbo.Locations", "Id");
            AddPrimaryKey("dbo.Positions", "Id");
            AddForeignKey("dbo.Locations", "DeviceNetworkId", "dbo.DeviceNetworks", "Id");
            AddForeignKey("dbo.Positions", "LocationResourceId", "dbo.LocationResources", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Positions");
            DropPrimaryKey("dbo.Locations");
            DropPrimaryKey("dbo.LocationResources");
            DropPrimaryKey("dbo.DeviceNetworks");
            AlterColumn("dbo.Positions", "LocationResourceId", c => c.String());
            AlterColumn("dbo.Positions", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Locations", "DeviceNetworkId", c => c.String());
            AlterColumn("dbo.Locations", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.LocationResources", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.DeviceNetworks", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Positions", "Id");
            AddPrimaryKey("dbo.Locations", "Id");
            AddPrimaryKey("dbo.LocationResources", "Id");
            AddPrimaryKey("dbo.DeviceNetworks", "Id");
        }
    }
}
