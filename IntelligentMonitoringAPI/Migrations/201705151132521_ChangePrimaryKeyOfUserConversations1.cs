namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePrimaryKeyOfUserConversations1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserConversations", "FromId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserConversations", "FromId", c => c.String());
        }
    }
}
