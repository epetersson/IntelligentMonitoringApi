namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorPropertiesInLocationResource : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.LocationResources", "Path", "Uri");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.LocationResources", "Uri", "Path");
        }
    }
}
