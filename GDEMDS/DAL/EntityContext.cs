namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EntityContext : DbContext
    {
        // Your context has been configured to use a 'EntityContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAL.EntityContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EntityContext' 
        // connection string in the application configuration file.
        public EntityContext()
            : base("data source=10.29.0.29;initial catalog=E14I4DABH1Gr8;User Id=E14I4DABH1Gr8;Password=E14I4DABH1Gr8;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        //CurrentModel
        public DbSet<Appartment> Appartments { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Measurement> Measurements { get; set; }

        //HistoricModel
        public DbSet<HistoricModel> HistoricModels { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}


}