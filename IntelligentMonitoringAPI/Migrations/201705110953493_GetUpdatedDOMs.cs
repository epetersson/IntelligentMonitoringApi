namespace IntelligentMonitoringAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetUpdatedDOMs : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserConversations", "Id");
            RenameColumn("dbo.UserConversations", "FromId", "Id");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserConversations", "FromId", c => c.String(nullable: false, maxLength: 100));
            DropPrimaryKey("dbo.UserConversations");
            AddPrimaryKey("dbo.UserConversations", "FromId");
        }
    }
}
