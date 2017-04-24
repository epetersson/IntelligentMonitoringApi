namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEvents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CreatedDateTime = c.DateTime(nullable: false),
                        ResetDateTime = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Information = c.String(),
                        EventCategoryId = c.String(),
                        EventCategoryName = c.String(),
                        EventCategoryTypeId = c.Int(nullable: false),
                        RuleId = c.String(),
                        RuleName = c.String(),
                        SeverityLevel = c.Int(nullable: false),
                        RuleDescription = c.String(),
                        TriggerId = c.String(),
                        TriggerName = c.String(),
                        TriggerLimit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TriggerValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ResetValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SensorId = c.Int(nullable: false),
                        SensorName = c.String(),
                        DeviceId = c.Int(nullable: false),
                        DeviceName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            AddForeignKey("dbo.Events", "SensorId", "dbo.Sensors", "Id");
            AddForeignKey("dbo.Events", "DeviceId", "dbo.Devices", "Id");
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
