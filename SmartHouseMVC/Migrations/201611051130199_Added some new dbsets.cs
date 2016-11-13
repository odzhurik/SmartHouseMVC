namespace SmartHouseMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedsomenewdbsets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SwitchableAppModels",
                c => new
                    {
                        SwitchableAppModelId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.SwitchableAppModelId);
            
            CreateTable(
                "dbo.CookableAppModels",
                c => new
                    {
                        CookableAppModelId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CookableAppModelId);
            
            AddColumn("dbo.Conditioners", "Switchable_SwitchableAppModelId", c => c.Int());
            AddColumn("dbo.Lamps", "Switchable_SwitchableAppModelId", c => c.Int());
            AddColumn("dbo.Microwaves", "CookableApp_CookableAppModelId", c => c.Int());
            AddColumn("dbo.Microwaves", "Switchable_SwitchableAppModelId", c => c.Int());
            AddColumn("dbo.TVs", "Switchable_SwitchableAppModelId", c => c.Int());
            CreateIndex("dbo.Conditioners", "Switchable_SwitchableAppModelId");
            CreateIndex("dbo.Lamps", "Switchable_SwitchableAppModelId");
            CreateIndex("dbo.Microwaves", "CookableApp_CookableAppModelId");
            CreateIndex("dbo.Microwaves", "Switchable_SwitchableAppModelId");
            CreateIndex("dbo.TVs", "Switchable_SwitchableAppModelId");
            AddForeignKey("dbo.Conditioners", "Switchable_SwitchableAppModelId", "dbo.SwitchableAppModels", "SwitchableAppModelId");
            AddForeignKey("dbo.Lamps", "Switchable_SwitchableAppModelId", "dbo.SwitchableAppModels", "SwitchableAppModelId");
            AddForeignKey("dbo.Microwaves", "CookableApp_CookableAppModelId", "dbo.CookableAppModels", "CookableAppModelId");
            AddForeignKey("dbo.Microwaves", "Switchable_SwitchableAppModelId", "dbo.SwitchableAppModels", "SwitchableAppModelId");
            AddForeignKey("dbo.TVs", "Switchable_SwitchableAppModelId", "dbo.SwitchableAppModels", "SwitchableAppModelId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TVs", "Switchable_SwitchableAppModelId", "dbo.SwitchableAppModels");
            DropForeignKey("dbo.Microwaves", "Switchable_SwitchableAppModelId", "dbo.SwitchableAppModels");
            DropForeignKey("dbo.Microwaves", "CookableApp_CookableAppModelId", "dbo.CookableAppModels");
            DropForeignKey("dbo.Lamps", "Switchable_SwitchableAppModelId", "dbo.SwitchableAppModels");
            DropForeignKey("dbo.Conditioners", "Switchable_SwitchableAppModelId", "dbo.SwitchableAppModels");
            DropIndex("dbo.TVs", new[] { "Switchable_SwitchableAppModelId" });
            DropIndex("dbo.Microwaves", new[] { "Switchable_SwitchableAppModelId" });
            DropIndex("dbo.Microwaves", new[] { "CookableApp_CookableAppModelId" });
            DropIndex("dbo.Lamps", new[] { "Switchable_SwitchableAppModelId" });
            DropIndex("dbo.Conditioners", new[] { "Switchable_SwitchableAppModelId" });
            DropColumn("dbo.TVs", "Switchable_SwitchableAppModelId");
            DropColumn("dbo.Microwaves", "Switchable_SwitchableAppModelId");
            DropColumn("dbo.Microwaves", "CookableApp_CookableAppModelId");
            DropColumn("dbo.Lamps", "Switchable_SwitchableAppModelId");
            DropColumn("dbo.Conditioners", "Switchable_SwitchableAppModelId");
            DropTable("dbo.CookableAppModels");
            DropTable("dbo.SwitchableAppModels");
        }
    }
}
