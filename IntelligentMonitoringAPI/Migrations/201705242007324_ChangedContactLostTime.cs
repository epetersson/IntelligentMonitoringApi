namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedContactLostTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DataCollectors", "ContactLostTimeStamp", c => c.DateTime());
            AddColumn("dbo.Devices", "ContactLostTimeStamp", c => c.DateTime());
            DropColumn("dbo.DataCollectors", "ContactLostTime");
            DropColumn("dbo.Devices", "ContactLostTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Devices", "ContactLostTime", c => c.Long(nullable: false));
            AddColumn("dbo.DataCollectors", "ContactLostTime", c => c.Long(nullable: false));
            DropColumn("dbo.Devices", "ContactLostTimeStamp");
            DropColumn("dbo.DataCollectors", "ContactLostTimeStamp");
        }
    }
}
