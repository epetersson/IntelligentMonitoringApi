namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewSensors1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Sensors", "SensorType", "SensorTypeName");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Sensors", "SensorTypeName", "SensorType");
        }
    }
}
