namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAVGBAtteryLevel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DailyStatistics", "AverageBatteryLevel", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DailyStatistics", "AverageBatteryLevel");
        }
    }
}
