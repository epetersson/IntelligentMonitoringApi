namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePublicBoolHandeled : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FailurePronedDevices", "PublicBoolHandeled");
        }
        
        public override void Down()
        {
        }
    }
}
