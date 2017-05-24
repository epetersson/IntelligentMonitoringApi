namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedDateTimeInSensorMeasurement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SensorMeasurements", "CreatedTimeStamp", c => c.DateTime());
            DropColumn("dbo.SensorMeasurements", "CreatedDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SensorMeasurements", "CreatedDateTime", c => c.DateTime());
            DropColumn("dbo.SensorMeasurements", "CreatedTimeStamp");
        }
    }
}
