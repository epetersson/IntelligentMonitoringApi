namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMeasurementUnitToSensor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sensors", "MeasurementUnit", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sensors", "MeasurementUnit");
        }
    }
}
