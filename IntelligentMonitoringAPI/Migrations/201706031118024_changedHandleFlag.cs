namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedHandleFlag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FailurePronedDevices", "Handled", c => c.Boolean(nullable: false));
            DropColumn("dbo.FailurePronedDevices", "PublicBoolHandled");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FailurePronedDevices", "PublicBoolHandled", c => c.Boolean(nullable: false));
            DropColumn("dbo.FailurePronedDevices", "Handled");
        }
    }
}
