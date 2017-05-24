namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUpdatedTimeStampToLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "UpdatedTimeStamp", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "UpdatedTimeStamp");
        }
    }
}
