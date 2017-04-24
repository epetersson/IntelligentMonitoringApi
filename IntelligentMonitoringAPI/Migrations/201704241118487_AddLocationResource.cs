namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocationResource : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LocationResources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Label = c.String(),
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
        }
    }
}
