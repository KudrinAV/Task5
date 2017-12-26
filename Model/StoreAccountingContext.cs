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
           // Database.SetInitializer(new UserDbInitializer());
        }

        //public StoreAccountingContext(string connectionString)
        //    : base(connectionString)
        //{
        //}

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public class UserDbInitializer : DropCreateDatabaseAlways<StoreAccountingContext>
        {
            protected override void Seed(StoreAccountingContext context)
            {
                Role admin = new Role { RoleId = 1, Name = "admin" };
                context.Roles.Add(admin);
                context.Roles.Add(new Role { RoleId = 2, Name = "user" });
                context.Managers.Add(new Manager { ManagerID = 1, LastName = "Admin" });
                context.Users.Add(new User
                {
                    UserId = 1,
                    Login = "admin",
                    Password = "123",
                    RoleId = 1,
                    ManagerId = 1
                });
                base.Seed(context);
            }
        }
    }
}