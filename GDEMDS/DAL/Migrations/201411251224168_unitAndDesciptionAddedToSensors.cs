namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unitAndDesciptionAddedToSensors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sensors", "Unit", c => c.String());
            AddColumn("dbo.Sensors", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sensors", "Description");
            DropColumn("dbo.Sensors", "Unit");
        }
    }
}
