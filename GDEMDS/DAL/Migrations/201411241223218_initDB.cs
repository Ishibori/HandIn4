namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appartments",
                c => new
                    {
                        AppartmentId = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Size = c.Double(nullable: false),
                        Floor_FloorId = c.Int(),
                    })
                .PrimaryKey(t => t.AppartmentId)
                .ForeignKey("dbo.Floors", t => t.Floor_FloorId)
                .Index(t => t.Floor_FloorId);
            
            CreateTable(
                "dbo.Sensors",
                c => new
                    {
                        SensorId = c.Int(nullable: false, identity: true),
                        CalibrationDate = c.DateTime(nullable: false),
                        CalibrationEquation = c.String(),
                        CalibrationCoeff = c.String(),
                        Appartment_AppartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.SensorId)
                .ForeignKey("dbo.Appartments", t => t.Appartment_AppartmentId)
                .Index(t => t.Appartment_AppartmentId);
            
            CreateTable(
                "dbo.Floors",
                c => new
                    {
                        FloorId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.FloorId);
            
            CreateTable(
                "dbo.HistoricModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(nullable: false),
                        BinaryData = c.Binary(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Measurements",
                c => new
                    {
                        MeasurementId = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(nullable: false),
                        Value = c.Double(nullable: false),
                        Sensor_SensorId = c.Int(),
                    })
                .PrimaryKey(t => t.MeasurementId)
                .ForeignKey("dbo.Sensors", t => t.Sensor_SensorId)
                .Index(t => t.Sensor_SensorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Measurements", "Sensor_SensorId", "dbo.Sensors");
            DropForeignKey("dbo.Appartments", "Floor_FloorId", "dbo.Floors");
            DropForeignKey("dbo.Sensors", "Appartment_AppartmentId", "dbo.Appartments");
            DropIndex("dbo.Measurements", new[] { "Sensor_SensorId" });
            DropIndex("dbo.Sensors", new[] { "Appartment_AppartmentId" });
            DropIndex("dbo.Appartments", new[] { "Floor_FloorId" });
            DropTable("dbo.Measurements");
            DropTable("dbo.HistoricModels");
            DropTable("dbo.Floors");
            DropTable("dbo.Sensors");
            DropTable("dbo.Appartments");
        }
    }
}
