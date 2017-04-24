namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPosition : DbMigration
    {
        public override void Up()
        {
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
            AddForeignKey("dbo.Positions", "LocationResourceId", "dbo.LocationResources", "Id");
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Positions");
        }
    }
}
