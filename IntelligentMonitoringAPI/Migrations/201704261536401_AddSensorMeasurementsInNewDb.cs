namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSensorMeasurementsInNewDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SensorMeasurements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SensorId = c.String(maxLength: 50),
                        UnixTimestamp = c.Long(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            AddForeignKey("dbo.SensorMeasurements", "SensorId", "dbo.Sensors", "Id");
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SensorMeasurements");
        }
    }
}
