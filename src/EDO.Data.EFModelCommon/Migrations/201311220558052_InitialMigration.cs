namespace EDO.Data.EFModelCommon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Okato = c.String(),
                        Country = c.String(),
                        Zip = c.String(),
                        State = c.String(),
                        City = c.String(),
                        Punkt = c.String(),
                        Street = c.String(),
                        Building = c.String(),
                        Office = c.String(),
                        RawAddress = c.String(),
                        Created = c.DateTime(),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Business",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ShortTitle = c.String(),
                        IsAccreditated = c.Boolean(nullable: false),
                        IsInvoiceStatement = c.Boolean(nullable: false),
                        Created = c.DateTime(),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Office",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        IsMainOffice = c.Boolean(nullable: false),
                        Inn = c.String(),
                        Ogrn = c.String(),
                        Kpp = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Fax = c.String(),
                        AdditionalContacts = c.String(),
                        OfficeEssentials_Bik = c.String(),
                        OfficeEssentials_PersonalAccount = c.String(),
                        OfficeEssentials_SettlementAccount = c.String(),
                        OfficeEssentials_CorrespondentAccount = c.String(),
                        OfficeEssentials_BankName = c.String(),
                        OfficeEssentials_BankAddress = c.String(),
                        Created = c.DateTime(),
                        Modified = c.DateTime(),
                        Address_Id = c.Int(),
                        Business_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.Address_Id)
                .ForeignKey("dbo.Business", t => t.Business_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.Business_Id);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        Surname = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        MobilePhone = c.String(),
                        Email = c.String(),
                        PassPhrase = c.String(),
                        Created = c.DateTime(),
                        Modified = c.DateTime(),
                        AccountType_Id = c.Int(),
                        Business_Id = c.Int(),
                        Office_Id = c.Int(),
                        Position_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountType", t => t.AccountType_Id)
                .ForeignKey("dbo.Business", t => t.Business_Id)
                .ForeignKey("dbo.Office", t => t.Office_Id)
                .ForeignKey("dbo.UserPosition", t => t.Position_Id)
                .Index(t => t.AccountType_Id)
                .Index(t => t.Business_Id)
                .Index(t => t.Office_Id)
                .Index(t => t.Position_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Office", "Business_Id", "dbo.Business");
            DropForeignKey("dbo.Office", "Address_Id", "dbo.Address");
            DropForeignKey("dbo.UserProfile", "Position_Id", "dbo.UserPosition");
            DropForeignKey("dbo.UserProfile", "Office_Id", "dbo.Office");
            DropForeignKey("dbo.UserProfile", "Business_Id", "dbo.Business");
            DropForeignKey("dbo.UserProfile", "AccountType_Id", "dbo.AccountType");
            DropIndex("dbo.Office", new[] { "Business_Id" });
            DropIndex("dbo.Office", new[] { "Address_Id" });
            DropIndex("dbo.UserProfile", new[] { "Position_Id" });
            DropIndex("dbo.UserProfile", new[] { "Office_Id" });
            DropIndex("dbo.UserProfile", new[] { "Business_Id" });
            DropIndex("dbo.UserProfile", new[] { "AccountType_Id" });
            DropTable("dbo.UserPosition");
            DropTable("dbo.UserProfile");
            DropTable("dbo.Office");
            DropTable("dbo.Business");
            DropTable("dbo.Address");
            DropTable("dbo.AccountType");
        }
    }
}
