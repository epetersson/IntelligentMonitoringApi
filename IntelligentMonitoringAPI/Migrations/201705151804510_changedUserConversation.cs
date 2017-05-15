namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedUserConversation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserConversations", "ServiceUrl", c => c.String());
            AddColumn("dbo.UserConversations", "FromId", c => c.String());
            AddColumn("dbo.UserConversations", "FromName", c => c.String());
            AddColumn("dbo.UserConversations", "ToId", c => c.String());
            AddColumn("dbo.UserConversations", "ToName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserConversations", "ToName");
            DropColumn("dbo.UserConversations", "ToId");
            DropColumn("dbo.UserConversations", "FromName");
            DropColumn("dbo.UserConversations", "FromId");
            DropColumn("dbo.UserConversations", "ServiceUrl");
        }
    }
}
