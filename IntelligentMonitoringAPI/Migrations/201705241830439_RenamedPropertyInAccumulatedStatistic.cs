namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedPropertyInAccumulatedStatistic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccumulatedStatistics", "UpdatedTimeStamp", c => c.DateTime());
            DropColumn("dbo.AccumulatedStatistics", "LastUpdate");
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccumulatedStatistics", "UpdatedTimeStamp");
            RenameTable(name: "dbo.HourlyStatistics", newName: "DeviceHistories");
        }
    }
}
