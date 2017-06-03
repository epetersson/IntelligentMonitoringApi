namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPublicBoolHandledToFailurePronedDevice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FailurePronedDevices", "PublicBoolHandeled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
        }
    }
}
