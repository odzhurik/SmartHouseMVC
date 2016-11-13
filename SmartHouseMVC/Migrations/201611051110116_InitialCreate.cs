namespace SmartHouseMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conditioners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Airconditioning = c.String(),
                        Temperature = c.Int(nullable: false),
                        Name = c.String(),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lamps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Max = c.Int(nullable: false),
                        Unit = c.Int(nullable: false),
                        Name = c.String(),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Microwaves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Max = c.Int(nullable: false),
                        Unit = c.Int(nullable: false),
                        Food = c.Boolean(nullable: false),
                        Name = c.String(),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TVs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Max = c.Int(nullable: false),
                        Unit = c.Int(nullable: false),
                        Name = c.String(),
                        State = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TVs");
            DropTable("dbo.Microwaves");
            DropTable("dbo.Lamps");
            DropTable("dbo.Conditioners");
        }
    }
}
