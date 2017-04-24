namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChanges1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LocationResources", "Path", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LocationResources", "Path");
        }
    }
}
