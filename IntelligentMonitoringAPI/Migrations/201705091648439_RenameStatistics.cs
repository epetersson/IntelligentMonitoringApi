namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameStatistics : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.StatsWeekly");
            DropTable("dbo.StatsYearly");
            RenameTable(name: "dbo.StatsMonthly", newName: "MonthlyStatistics");
            CreateTable(
                "dbo.WeeklyStatistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(),
                        Average = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Peak = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Low = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CollectiveContactLostTime = c.Long(nullable: false),
                        CollectiveContactLostCount = c.Int(nullable: false),
                        FailureProneDeviceId = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.YearlyStatistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(),
                        Average = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Peak = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Low = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CollectiveContactLostTime = c.Long(nullable: false),
                        CollectiveContactLostCount = c.Int(nullable: false),
                        FailureProneDeviceId = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StatsYearlies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(),
                        Average = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Peak = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Low = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CollectiveContactLostTime = c.Long(nullable: false),
                        CollectiveContactLostCount = c.Int(nullable: false),
                        FailureProneDeviceId = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StatsWeeklies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(),
                        Average = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Peak = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Low = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CollectiveContactLostTime = c.Long(nullable: false),
                        CollectiveContactLostCount = c.Int(nullable: false),
                        FailureProneDeviceId = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.YearlyStatistics");
            DropTable("dbo.WeeklyStatistics");
            RenameTable(name: "dbo.MonthlyStatistics", newName: "StatsMonthly");
        }
    }
}
