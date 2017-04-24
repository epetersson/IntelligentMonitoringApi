namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSensorMeasurements : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SensorMeasurements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(),
                        SensorId = c.Int(),
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
