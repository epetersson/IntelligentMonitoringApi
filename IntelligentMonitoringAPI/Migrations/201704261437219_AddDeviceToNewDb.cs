namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeviceToNewDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        DataCollectorName = c.String(),
                        IsRegistered = c.Boolean(nullable: false),
                        DeviceTypeName = c.String(),
                        LastSeen = c.Long(nullable: false),
                        ContactLost = c.Boolean(nullable: false),
                        ContactLostTime = c.Long(nullable: false),
                        Name = c.String(),
                        DataCollectorId = c.String(maxLength: 50),
                        LocationId = c.String(maxLength: 50),
                        LocationName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            AddForeignKey("dbo.Devices", "LocationId", "dbo.Locations", "Id");
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Devices");
        }
    }
}
