namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowNullForParentLocationId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Locations", "ParentLocationId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "ParentLocationId", c => c.Int(nullable: false));
        }
    }
}
