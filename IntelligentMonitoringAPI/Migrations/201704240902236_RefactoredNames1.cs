namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactoredNames1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Device", name: "Location-Id", newName: "LocationId");
            //RenameIndex(table: "dbo.Device", name: "IX_Location-Id", newName: "IX_LocationId");
        }
        
        public override void Down()
        {
            //RenameIndex(table: "dbo.Device", name: "IX_LocationId", newName: "IX_Location-Id");
            RenameColumn(table: "dbo.Device", name: "LocationId", newName: "Location-Id");
        }
    }
}
