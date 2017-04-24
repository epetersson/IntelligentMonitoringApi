namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSigmaIdToTables : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Events");
            AddColumn("dbo.DeviceNetworks", "SigmaId", c => c.String());
            AddColumn("dbo.Events", "SigmaId", c => c.String());
            AddColumn("dbo.LocationResources", "SigmaId", c => c.String());
            AlterColumn("dbo.Events", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Events", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Events");
            AlterColumn("dbo.Events", "Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.LocationResources", "SigmaId");
            DropColumn("dbo.Events", "SigmaId");
            DropColumn("dbo.DeviceNetworks", "SigmaId");
            AddPrimaryKey("dbo.Events", "Id");
        }
    }
}
