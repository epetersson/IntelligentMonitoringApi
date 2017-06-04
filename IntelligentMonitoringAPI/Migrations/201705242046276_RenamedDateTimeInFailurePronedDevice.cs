namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedDateTimeInFailurePronedDevice : DbMigration
    {
        public override void Up()
        {
           // AddColumn("dbo.FailurePronedDevices", "CreatedTimeStamp", c => c.DateTime());
            //DropColumn("dbo.FailurePronedDevices", "CreatedDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FailurePronedDevices", "CreatedDateTime", c => c.DateTime());
            DropColumn("dbo.FailurePronedDevices", "CreatedTimeStamp");
        }
    }
}
