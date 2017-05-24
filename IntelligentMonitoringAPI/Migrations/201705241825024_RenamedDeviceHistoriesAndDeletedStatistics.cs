namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedDeviceHistoriesAndDeletedStatistics : DbMigration
    {
        public override void Up()
        {
            RenameTable("dbo.HourlyStatistics", "HourlyStatistics");
            DropTable("dbo.MonthlyStatistics");
            DropTable("dbo.WeeklyStatistics");
            DropTable("dbo.YearlyStatistics");
        }
        
        public override void Down()
        {
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
                "dbo.MonthlyStatistics",
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
    }
}
