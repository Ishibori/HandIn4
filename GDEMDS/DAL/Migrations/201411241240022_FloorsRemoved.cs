namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FloorsRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appartments", "Floor_FloorId", "dbo.Floors");
            DropIndex("dbo.Appartments", new[] { "Floor_FloorId" });
            AddColumn("dbo.Appartments", "Floor", c => c.Int(nullable: false));
            DropColumn("dbo.Appartments", "Floor_FloorId");
            DropTable("dbo.Floors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Floors",
                c => new
                    {
                        FloorId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.FloorId);
            
            AddColumn("dbo.Appartments", "Floor_FloorId", c => c.Int());
            DropColumn("dbo.Appartments", "Floor");
            CreateIndex("dbo.Appartments", "Floor_FloorId");
            AddForeignKey("dbo.Appartments", "Floor_FloorId", "dbo.Floors", "FloorId");
        }
    }
}
