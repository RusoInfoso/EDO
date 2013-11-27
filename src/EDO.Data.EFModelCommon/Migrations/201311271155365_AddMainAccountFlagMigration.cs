namespace EDO.Data.EFModelCommon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMainAccountFlagMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfile", "IsMainAccount", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfile", "IsMainAccount");
        }
    }
}
