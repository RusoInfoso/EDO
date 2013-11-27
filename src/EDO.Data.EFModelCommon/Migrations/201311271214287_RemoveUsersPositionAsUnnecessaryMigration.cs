namespace EDO.Data.EFModelCommon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUsersPositionAsUnnecessaryMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProfile", "Position_Id", "dbo.UserPosition");
            DropIndex("dbo.UserProfile", new[] { "Position_Id" });
            AddColumn("dbo.UserProfile", "Position", c => c.String());
            DropColumn("dbo.UserProfile", "Position_Id");
            DropTable("dbo.UserPosition");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserPosition",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Created = c.DateTime(),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserProfile", "Position_Id", c => c.Int());
            DropColumn("dbo.UserProfile", "Position");
            CreateIndex("dbo.UserProfile", "Position_Id");
            AddForeignKey("dbo.UserProfile", "Position_Id", "dbo.UserPosition", "Id");
        }
    }
}
