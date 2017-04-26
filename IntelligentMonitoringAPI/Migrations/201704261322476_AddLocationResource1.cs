namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocationResource1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SigmaId = c.String(),
                        IsRegistered = c.Boolean(nullable: false),
                        LastSeen = c.Long(nullable: false),
                        ContactLost = c.Boolean(nullable: false),
                        ContactLostTime = c.Long(nullable: false),
                        Name = c.String(),
                        LocationId = c.Int(nullable: false),
                        LocationName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LocationResources",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Label = c.String(),
                        ResourceType = c.String(),
                        Path = c.String(),
                        StartPositionX = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartPositionY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartPositionZ = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartZoomLevel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LocationResources");
            DropTable("dbo.Devices");
        }
    }
}
