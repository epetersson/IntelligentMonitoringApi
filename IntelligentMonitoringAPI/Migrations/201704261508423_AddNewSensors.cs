namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewSensors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sensors",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 50),
                        Name = c.String(),
                        SensorTypeId = c.String(),
                        SensorType = c.String(),
                        DeviceId = c.String(maxLength: 50),
                        DeviceName = c.String(),
                        IsVirtual = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            AddForeignKey("dbo.Sensors", "DeviceId", "dbo.Devices", "Id");
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sensors");
        }
    }
}
