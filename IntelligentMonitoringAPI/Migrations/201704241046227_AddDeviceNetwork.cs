namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeviceNetwork : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceNetworks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TenantName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Locations", "DeviceNetworkId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Locations", "DeviceNetworkId", "dbo.DeviceNetworks", "Id");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "DeviceNetworkId");
            DropTable("dbo.DeviceNetworks");
        }
    }
}
