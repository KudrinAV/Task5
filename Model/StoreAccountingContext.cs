namespace Model
{
    using Model.DataModel;
    using Model.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StoreAccountingContext : DbContext
    {
        public StoreAccountingContext()
            : base("name=StoreAccountingContext")
        {
        }

        //public StoreAccountingContext(string connectionString)
        //    : base(connectionString)
        //{
        //}

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}