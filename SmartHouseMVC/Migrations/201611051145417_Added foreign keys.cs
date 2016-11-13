namespace SmartHouseMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedforeignkeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SwitchableAppModels", "LampId", c => c.Int());
            AddColumn("dbo.SwitchableAppModels", "ConditionerId", c => c.Int());
            AddColumn("dbo.SwitchableAppModels", "TVId", c => c.Int());
            AddColumn("dbo.SwitchableAppModels", "MicrowaveId", c => c.Int());
            AddColumn("dbo.CookableAppModels", "MicrowaveId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CookableAppModels", "MicrowaveId");
            DropColumn("dbo.SwitchableAppModels", "MicrowaveId");
            DropColumn("dbo.SwitchableAppModels", "TVId");
            DropColumn("dbo.SwitchableAppModels", "ConditionerId");
            DropColumn("dbo.SwitchableAppModels", "LampId");
        }
    }
}
