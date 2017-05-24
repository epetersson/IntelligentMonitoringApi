namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRealTimeToken : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RealTimeTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceNetworkId = c.String(maxLength: 50),
                        Token = c.String(maxLength: 50),
                        CreatedTimeStamp = c.DateTime(nullable: false),
                        ExpiresTimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            AddForeignKey("dbo.RealTimeTokens", "DeviceNetworkId", "dbo.DeviceNetworks", "Id");           
        }
        
        public override void Down()
        {
            DropTable("dbo.RealTimeTokens");
        }
    }
}
