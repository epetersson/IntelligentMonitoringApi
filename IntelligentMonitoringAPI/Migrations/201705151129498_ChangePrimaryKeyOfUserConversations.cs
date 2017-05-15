namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePrimaryKeyOfUserConversations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserConversations", "FromId", c => c.String());
            AlterColumn("dbo.UserConversations", "Id", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserConversations", "Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.UserConversations", "FromId");
        }
    }
}
