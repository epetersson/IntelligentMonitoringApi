namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDevice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Devices",
                    c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IsRegistered = c.Boolean(nullable: false),
                        LastSeen = c.Long(nullable: false),
                        ContactLost = c.Boolean(nullable: false),
                        ContactLostTime = c.Long(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            
        }
        
        public override void Down()
        {
            DropTable("dbo.Devices");
        }
    }
}
