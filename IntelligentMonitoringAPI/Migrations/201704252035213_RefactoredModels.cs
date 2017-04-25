namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactoredModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "LocationName", c => c.String());
            AlterColumn("dbo.SensorMeasurements", "Value", c => c.Int(nullable: false));
            AlterColumn("dbo.SensorMeasurements", "SensorId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SensorMeasurements", "SensorId", c => c.Int());
            AlterColumn("dbo.SensorMeasurements", "Value", c => c.Int());
            DropColumn("dbo.Devices", "LocationName");
        }
    }
}
