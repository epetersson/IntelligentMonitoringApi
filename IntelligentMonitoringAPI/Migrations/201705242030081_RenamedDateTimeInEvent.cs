namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedDateTimeInEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "CreatedTimeStamp", c => c.DateTime());
            AddColumn("dbo.Events", "ResetTimeStamp", c => c.DateTime());
            DropColumn("dbo.Events", "CreatedDateTime");
            DropColumn("dbo.Events", "ResetDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "ResetDateTime", c => c.DateTime());
            AddColumn("dbo.Events", "CreatedDateTime", c => c.DateTime());
            DropColumn("dbo.Events", "ResetTimeStamp");
            DropColumn("dbo.Events", "CreatedTimeStamp");
        }
    }
}
