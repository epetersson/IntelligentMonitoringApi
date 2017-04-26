namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocationsAndDeviceNetworks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceNetworks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        TenantName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        ParentLocationName = c.String(),
                        ParentLocationId = c.String(),
                        LocationType = c.Int(nullable: false),
                        DeviceNetworkId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Locations");
            DropTable("dbo.DeviceNetworks");
        }
    }
}
