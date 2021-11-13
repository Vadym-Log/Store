namespace Store
{
    using System.Data.Entity;

    public class StoreModel : DbContext
    {
        // Your context has been configured to use a 'StoreModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Store.StoreModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StoreModel' 
        // connection string in the application configuration file.
        public StoreModel()
            : base("name=StoreModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order_Product> Orders_Products { get; set; }
        public virtual DbSet<Log_Emp> Logs_Emps { get; set; }
        public virtual DbSet<Log_Cus> Logs_Cuss { get; set; }
    }
}