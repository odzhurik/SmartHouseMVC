namespace SmartHouseMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDefaultTemptoDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Conditioners", "Switchable_SwitchableAppModelId", "dbo.SwitchableAppModels");
            DropForeignKey("dbo.Lamps", "Switchable_SwitchableAppModelId", "dbo.SwitchableAppModels");
            DropForeignKey("dbo.Microwaves", "CookableApp_CookableAppModelId", "dbo.CookableAppModels");
            DropForeignKey("dbo.Microwaves", "Switchable_SwitchableAppModelId", "dbo.SwitchableAppModels");
            DropForeignKey("dbo.TVs", "Switchable_SwitchableAppModelId", "dbo.SwitchableAppModels");
            DropIndex("dbo.Conditioners", new[] { "Switchable_SwitchableAppModelId" });
            DropIndex("dbo.Lamps", new[] { "Switchable_SwitchableAppModelId" });
            DropIndex("dbo.Microwaves", new[] { "CookableApp_CookableAppModelId" });
            DropIndex("dbo.Microwaves", new[] { "Switchable_SwitchableAppModelId" });
            DropIndex("dbo.TVs", new[] { "Switchable_SwitchableAppModelId" });
            AddColumn("dbo.Conditioners", "DefaultTemp", c => c.Int(nullable: false));
            DropColumn("dbo.Conditioners", "Switchable_SwitchableAppModelId");
            DropColumn("dbo.Lamps", "Switchable_SwitchableAppModelId");
            DropColumn("dbo.Microwaves", "CookableApp_CookableAppModelId");
            DropColumn("dbo.Microwaves", "Switchable_SwitchableAppModelId");
            DropColumn("dbo.TVs", "Switchable_SwitchableAppModelId");
            DropTable("dbo.SwitchableAppModels");
            DropTable("dbo.CookableAppModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CookableAppModels",
                c => new
                    {
                        CookableAppModelId = c.Int(nullable: false, identity: true),
                        MicrowaveId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CookableAppModelId);
            
            CreateTable(
                "dbo.SwitchableAppModels",
                c => new
                    {
                        SwitchableAppModelId = c.Int(nullable: false, identity: true),
                        LampId = c.Int(),
                        ConditionerId = c.Int(),
                        TVId = c.Int(),
                        MicrowaveId = c.Int(),
                    })
                .PrimaryKey(t => t.SwitchableAppModelId);
            
            AddColumn("dbo.TVs", "Switchable_SwitchableAppModelId", c => c.Int());
            AddColumn("dbo.Microwaves", "Switchable_SwitchableAppModelId", c => c.Int());
            AddColumn("dbo.Microwaves", "CookableApp_CookableAppModelId", c => c.Int());
            AddColumn("dbo.Lamps", "Switchable_SwitchableAppModelId", c => c.Int());
            AddColumn("dbo.Conditioners", "Switchable_SwitchableAppModelId", c => c.Int());
            DropColumn("dbo.Conditioners", "DefaultTemp");
            CreateIndex("dbo.TVs", "Switchable_SwitchableAppModelId");
            CreateIndex("dbo.Microwaves", "Switchable_SwitchableAppModelId");
            CreateIndex("dbo.Microwaves", "CookableApp_CookableAppModelId");
            CreateIndex("dbo.Lamps", "Switchable_SwitchableAppModelId");
            CreateIndex("dbo.Conditioners", "Switchable_SwitchableAppModelId");
            AddForeignKey("dbo.TVs", "Switchable_SwitchableAppModelId", "dbo.SwitchableAppModels", "SwitchableAppModelId");
            AddForeignKey("dbo.Microwaves", "Switchable_SwitchableAppModelId", "dbo.SwitchableAppModels", "SwitchableAppModelId");
            AddForeignKey("dbo.Microwaves", "CookableApp_CookableAppModelId", "dbo.CookableAppModels", "CookableAppModelId");
            AddForeignKey("dbo.Lamps", "Switchable_SwitchableAppModelId", "dbo.SwitchableAppModels", "SwitchableAppModelId");
            AddForeignKey("dbo.Conditioners", "Switchable_SwitchableAppModelId", "dbo.SwitchableAppModels", "SwitchableAppModelId");
        }
    }
}
