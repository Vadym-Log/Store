using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace Store
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            
            Database.SetInitializer(new DropCreateDatabaseAlways<StoreModel>());
            SharedClass.storeModel = new StoreModel();

            SharedClass.storeModel.Categories.Add(new Category() { CategoryName = "Toys" });
            SharedClass.storeModel.Categories.Add(new Category() { CategoryName = "Clothes" });
            SharedClass.storeModel.Categories.Add(new Category() { CategoryName = "Electronics" });
            SharedClass.storeModel.Categories.Add(new Category() { CategoryName = "Food" });

            SharedClass.storeModel.Producers.Add(new Producer() {
                ProducerName = "USA_1", Country = "USA", Phone = "11-11-01" });
            SharedClass.storeModel.Producers.Add(new Producer() {
                ProducerName = "USA_2", Country = "USA", Phone = "11-11-02" });
            SharedClass.storeModel.Producers.Add(new Producer() {
                ProducerName = "USA_3", Country = "USA", Phone = "11-11-03" });
            SharedClass.storeModel.Producers.Add(new Producer() {
                ProducerName = "Russia_1", Country = "Russia", Phone = "11-22-01" });
            SharedClass.storeModel.Producers.Add(new Producer() {
                ProducerName = "Russia_2", Country = "Russia", Phone = "11-22-02" });
            SharedClass.storeModel.Producers.Add(new Producer() {
                ProducerName = "Ukraine_1", Country = "Ukraine", Phone = "11-33-01" });

            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Toys_1_1", CategoryId = 1, ProducerId = 1, Cost = 1101 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Toys_1_2", CategoryId = 1, ProducerId = 1, Cost = 1102 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Toys_1_3", CategoryId = 1, ProducerId = 1, Cost = 1103 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Toys_2_1", CategoryId = 1, ProducerId = 2, Cost = 1201 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Toys_2_2", CategoryId = 1, ProducerId = 2, Cost = 1202 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Toys_2_3", CategoryId = 1, ProducerId = 2, Cost = 1203 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Toys_3_1", CategoryId = 1, ProducerId = 3, Cost = 1301 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Toys_3_2", CategoryId = 1, ProducerId = 3, Cost = 1302 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Toys_3_3", CategoryId = 1, ProducerId = 3, Cost = 1303 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Toys_4_1", CategoryId = 1, ProducerId = 4, Cost = 1401 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Toys_4_2", CategoryId = 1, ProducerId = 4, Cost = 1402 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Toys_4_3", CategoryId = 1, ProducerId = 4, Cost = 1403 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Toys_5_1", CategoryId = 1, ProducerId = 5, Cost = 1501 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Toys_5_2", CategoryId = 1, ProducerId = 5, Cost = 1502 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Toys_5_3", CategoryId = 1, ProducerId = 5, Cost = 1503 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Toys_6_1", CategoryId = 1, ProducerId = 6, Cost = 1601 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Toys_6_2", CategoryId = 1, ProducerId = 6, Cost = 1602 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Toys_6_3", CategoryId = 1, ProducerId = 6, Cost = 1603 });

            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Clothes_1_1", CategoryId = 2, ProducerId = 1, Cost = 2101 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Clothes_1_2", CategoryId = 2, ProducerId = 1, Cost = 2102 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Clothes_1_3", CategoryId = 2, ProducerId = 1, Cost = 2103 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Clothes_2_1", CategoryId = 2, ProducerId = 2, Cost = 2201 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Clothes_2_2", CategoryId = 2, ProducerId = 2, Cost = 2202 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Clothes_2_3", CategoryId = 2, ProducerId = 2, Cost = 2203 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Clothes_3_1", CategoryId = 2, ProducerId = 3, Cost = 2301 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Clothes_3_2",  CategoryId = 2, ProducerId = 3, Cost = 2302 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Clothes_3_3", CategoryId = 2, ProducerId = 3, Cost = 2303 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Clothes_4_1", CategoryId = 2, ProducerId = 4, Cost = 2401 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Clothes_4_2", CategoryId = 2, ProducerId = 4, Cost = 2402 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Clothes_4_3", CategoryId = 2, ProducerId = 4, Cost = 2403 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Clothes_5_1", CategoryId = 2, ProducerId = 5, Cost = 2501 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Clothes_5_2", CategoryId = 2, ProducerId = 5, Cost = 2502 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Clothes_5_3", CategoryId = 2, ProducerId = 5, Cost = 2503 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Clothes_6_1", CategoryId = 2, ProducerId = 6, Cost = 2601 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Clothes_6_2", CategoryId = 2, ProducerId = 6, Cost = 2602 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Clothes_6_3", CategoryId = 2, ProducerId = 6, Cost = 2603 });

            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Electronics_1_1", CategoryId = 3, ProducerId = 1, Cost = 3101 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Electronics_1_2", CategoryId = 3, ProducerId = 1, Cost = 3102 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Electronics_1_3", CategoryId = 3, ProducerId = 1, Cost = 3103 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Electronics_2_1", CategoryId = 3, ProducerId = 2, Cost = 3201 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Electronics_2_2", CategoryId = 3, ProducerId = 2, Cost = 3202 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Electronics_2_3", CategoryId = 3, ProducerId = 2, Cost = 3203 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Electronics_3_1", CategoryId = 3, ProducerId = 3, Cost = 3301 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Electronics_3_2", CategoryId = 3, ProducerId = 3, Cost = 3302 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Electronics_3_3", CategoryId = 3, ProducerId = 3, Cost = 3303 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Electronics_4_1", CategoryId = 3, ProducerId = 4, Cost = 3401 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Electronics_4_2", CategoryId = 3, ProducerId = 4, Cost = 3402 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Electronics_4_3", CategoryId = 3, ProducerId = 4, Cost = 3403 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Electronics_5_1", CategoryId = 3, ProducerId = 5, Cost = 3501 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Electronics_5_2", CategoryId = 3, ProducerId = 5, Cost = 3502 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Electronics_5_3", CategoryId = 3, ProducerId = 5, Cost = 3503 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Electronics_6_1", CategoryId = 3, ProducerId = 6, Cost = 3601 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Electronics_6_2", CategoryId = 3, ProducerId = 6, Cost = 3602 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Electronics_6_3", CategoryId = 3, ProducerId = 6, Cost = 3603 });

            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Food_1_1", CategoryId = 4, ProducerId = 1, Cost = 4101 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Food_1_2", CategoryId = 4, ProducerId = 1, Cost = 4102 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Food_1_3", CategoryId = 4, ProducerId = 1, Cost = 4103 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Food_2_1", CategoryId = 4, ProducerId = 2, Cost = 4201 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Food_2_2", CategoryId = 4, ProducerId = 2, Cost = 4202 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Food_2_3", CategoryId = 4, ProducerId = 2, Cost = 4203 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Food_3_1", CategoryId = 4, ProducerId = 3, Cost = 4301 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Food_3_2", CategoryId = 4, ProducerId = 3, Cost = 4302 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Food_3_3", CategoryId = 4, ProducerId = 3, Cost = 4303 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Food_4_1", CategoryId = 4, ProducerId = 4, Cost = 4401 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Food_4_2", CategoryId = 4, ProducerId = 4, Cost = 4402 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Food_4_3", CategoryId = 4, ProducerId = 4, Cost = 4403 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Food_5_1", CategoryId = 4, ProducerId = 5, Cost = 4501 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Food_5_2", CategoryId = 4, ProducerId = 5, Cost = 4502 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Food_5_3", CategoryId = 4, ProducerId = 5, Cost = 4503 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Food_6_1", CategoryId = 4, ProducerId = 6, Cost = 4601 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Food_6_2", CategoryId = 4, ProducerId = 6, Cost = 4602 });
            SharedClass.storeModel.Products.Add(new Product() {
                ProductName = "Food_6_3", CategoryId = 4, ProducerId = 6, Cost = 4603 });

            SharedClass.storeModel.Employees.Add(new Employee() {
                FirstName = "Main", LastName = "Boss", Phone = "22-00-01",
                Address = "Director Address", Age = 75, Sex = Sex.Male, Position = Position.Director });
            SharedClass.storeModel.Employees.Add(new Employee() {
                FirstName = "First", LastName = "Manager_1", Phone = "22-01-01",
                Address = "Manager_1 Address", Age = 70, Sex = Sex.Male, Position = Position.Manager });
            SharedClass.storeModel.Employees.Add(new Employee() {
                FirstName = "Second", LastName = "Manager_2", Phone = "22-01-02",
                Address = "Manager_2 Address", Age = 65, Sex = Sex.Male, Position = Position.Manager });
            SharedClass.storeModel.Employees.Add(new Employee() {
                FirstName = "First", LastName = "Seller_1", Phone = "22-02-01",
                Address = "Seller_1 Address", Age = 21, Sex = Sex.Female, Position = Position.Seller });
            SharedClass.storeModel.Employees.Add(new Employee() {
                FirstName = "Second", LastName = "Seller_2", Phone = "22-02-02",
                Address = "Seller_2 Address", Age = 22, Sex = Sex.Female, Position = Position.Seller });
            SharedClass.storeModel.Employees.Add(new Employee() {
                FirstName = "Third", LastName = "Seller_3", Phone = "22-02-03",
                Address = "Seller_3 Address", Age = 23, Sex = Sex.Female, Position = Position.Seller });
            SharedClass.storeModel.Employees.Add(new Employee() {
                FirstName = "Fourth", LastName = "Seller_4", Phone = "22-02-04",
                Address = "Seller_4 Address", Age = 24, Sex = Sex.Female, Position = Position.Seller });

            SharedClass.storeModel.Logs_Emps.Add(new Log_Emp() { EmployeeId = 1, LoginName = "Director", Password = "1" });
            SharedClass.storeModel.Logs_Emps.Add(new Log_Emp() { EmployeeId = 2, LoginName = "Manager_1", Password = "2" });
            SharedClass.storeModel.Logs_Emps.Add(new Log_Emp() { EmployeeId = 3, LoginName = "Manager_2", Password = "3" });
            SharedClass.storeModel.Logs_Emps.Add(new Log_Emp() { EmployeeId = 4, LoginName = "Seller_1", Password = "4" });
            SharedClass.storeModel.Logs_Emps.Add(new Log_Emp() { EmployeeId = 5, LoginName = "Seller_2", Password = "5" });
            SharedClass.storeModel.Logs_Emps.Add(new Log_Emp() { EmployeeId = 6, LoginName = "Seller_3", Password = "6" });
            SharedClass.storeModel.Logs_Emps.Add(new Log_Emp() { EmployeeId = 7, LoginName = "Seller_4", Password = "7" });

            SharedClass.storeModel.Customers.Add(new Customer() {
                FirstName = "One", LastName = "Customer_1", Phone = "33-01-01",
                Address = "Customer_1 Address", Age = 31, Sex = Sex.Male
            });
            SharedClass.storeModel.Customers.Add(new Customer() {
                FirstName = "Two", LastName = "Customer_2", Phone = "33-01-02",
                Address = "Customer_2 Address", Age = 41, Sex = Sex.Female });
            SharedClass.storeModel.Customers.Add(new Customer() {
                FirstName = "Three", LastName = "Customer_3", Phone = "33-01-03",
                Address = "Customer_3 Address", Age = 51, Sex = Sex.Male });
            SharedClass.storeModel.Customers.Add(new Customer() {
                FirstName = "Four", LastName = "Customer_4", Phone = "33-01-04",
                Address = "Customer_4 Address", Age = 61, Sex = Sex.Female });
            SharedClass.storeModel.Customers.Add(new Customer() {
                FirstName = "Five", LastName = "Customer_5", Phone = "33-02-01",
                Address = "Customer_5 Address", Age = 32, Sex = Sex.Male });
            SharedClass.storeModel.Customers.Add(new Customer() {
                FirstName = "Six", LastName = "Customer_6", Phone = "33-02-02",
                Address = "Customer_6 Address", Age = 42, Sex = Sex.Female });
            SharedClass.storeModel.Customers.Add(new Customer() {
                FirstName = "Seven", LastName = "Customer_7", Phone = "33-02-03",
                Address = "Customer_7 Address", Age = 52, Sex = Sex.Male });
            SharedClass.storeModel.Customers.Add(new Customer() {
                FirstName = "Eight", LastName = "Customer_8", Phone = "33-02-04",
                Address = "Customer_8 Address", Age = 62, Sex = Sex.Female });
            SharedClass.storeModel.Customers.Add(new Customer() {
                FirstName = "Nine", LastName = "Customer_9", Phone = "33-03-01",
                Address = "Customer_9 Address", Age = 33, Sex = Sex.Male });
            SharedClass.storeModel.Customers.Add(new Customer() {
                FirstName = "Ten", LastName = "Customer_10", Phone = "33-03-02",
                Address = "Customer_10 Address", Age = 43, Sex = Sex.Female });
            SharedClass.storeModel.Customers.Add(new Customer() {
                FirstName = "Eleven", LastName = "Customer_11", Phone = "33-03-03",
                Address = "Customer_11 Address", Age = 53, Sex = Sex.Male });
            SharedClass.storeModel.Customers.Add(new Customer() {
                FirstName = "Twelve", LastName = "Customer_12", Phone = "33-03-04",
                Address = "Customer_12 Address", Age = 63, Sex = Sex.Female });
            SharedClass.storeModel.Customers.Add(new Customer() {
                FirstName = "Thirteen", LastName = "Customer_13", Phone = "33-04-01",
                Address = "Customer_13 Address", Age = 34, Sex = Sex.Male });
            SharedClass.storeModel.Customers.Add(new Customer() {
                FirstName = "Fourteen", LastName = "Customer_14", Phone = "33-04-02",
                Address = "Customer_14 Address", Age = 44, Sex = Sex.Female });
            SharedClass.storeModel.Customers.Add(new Customer() {
                FirstName = "Fifteen", LastName = "Customer_15", Phone = "33-04-03",
                Address = "Customer_15 Address", Age = 54, Sex = Sex.Male });
            SharedClass.storeModel.Customers.Add(new Customer() {
                FirstName = "Sixteen", LastName = "Customer_16", Phone = "33-04-04",
                Address = "Customer_16 Address", Age = 64, Sex = Sex.Female });

            SharedClass.storeModel.Logs_Cuss.Add(new Log_Cus() { CustomerId = 1, LoginName = "Customer_1", Password = "1" });
            SharedClass.storeModel.Logs_Cuss.Add(new Log_Cus() { CustomerId = 2, LoginName = "Customer_2", Password = "2" });
            SharedClass.storeModel.Logs_Cuss.Add(new Log_Cus() { CustomerId = 3, LoginName = "Customer_3", Password = "3" });
            SharedClass.storeModel.Logs_Cuss.Add(new Log_Cus() { CustomerId = 4, LoginName = "Customer_4", Password = "4" });
            SharedClass.storeModel.Logs_Cuss.Add(new Log_Cus() { CustomerId = 5, LoginName = "Customer_5", Password = "5" });
            SharedClass.storeModel.Logs_Cuss.Add(new Log_Cus() { CustomerId = 6, LoginName = "Customer_6", Password = "6" });
            SharedClass.storeModel.Logs_Cuss.Add(new Log_Cus() { CustomerId = 7, LoginName = "Customer_7", Password = "7" });
            SharedClass.storeModel.Logs_Cuss.Add(new Log_Cus() { CustomerId = 8, LoginName = "Customer_8", Password = "8" });
            SharedClass.storeModel.Logs_Cuss.Add(new Log_Cus() { CustomerId = 9, LoginName = "Customer_9", Password = "9" });
            SharedClass.storeModel.Logs_Cuss.Add(new Log_Cus() { CustomerId = 10, LoginName = "Customer_10", Password = "10" });
            SharedClass.storeModel.Logs_Cuss.Add(new Log_Cus() { CustomerId = 11, LoginName = "Customer_11", Password = "11" });
            SharedClass.storeModel.Logs_Cuss.Add(new Log_Cus() { CustomerId = 12, LoginName = "Customer_12", Password = "12" });
            SharedClass.storeModel.Logs_Cuss.Add(new Log_Cus() { CustomerId = 13, LoginName = "Customer_13", Password = "13" });
            SharedClass.storeModel.Logs_Cuss.Add(new Log_Cus() { CustomerId = 14, LoginName = "Customer_14", Password = "14" });
            SharedClass.storeModel.Logs_Cuss.Add(new Log_Cus() { CustomerId = 15, LoginName = "Customer_15", Password = "15" });
            SharedClass.storeModel.Logs_Cuss.Add(new Log_Cus() { CustomerId = 16, LoginName = "Customer_16", Password = "16" });

            SharedClass.storeModel.SaveChanges();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (rbnCustomer.Checked)
                SharedClass.User = User.Customer;
            else
                SharedClass.User = User.Employee;            
            frmAuth frmAuth = new frmAuth();
            frmAuth.Show();
            this.Hide();
        }
    }
}
