using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Store
{
    public partial class frmOrders : Form
    {
        public frmOrders()
        {
            InitializeComponent();
            if (SharedClass.User == User.Employee &&
                (SharedClass.Employee.Position == Position.Director || SharedClass.Employee.Position == Position.Manager)
                || SharedClass.User == User.Customer)
            {                
                Controls.Remove(btnAdd);
                Controls.Remove(btnDelete);
                Size = new Size(585, 575);
            }
            SharedClass.storeModel.Orders.Load();
            if (SharedClass.User == User.Employee)
                dataGridView1.DataSource = SharedClass.storeModel.Orders.Local.ToBindingList();
            else
            {
                Customer customer = SharedClass.storeModel.Customers.Find(SharedClass.Customer.Id);
                List<Order> customerOrders = SharedClass.storeModel.Orders.Where(id => id.CustomerId == customer.Id).ToList();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = customerOrders;
                dataGridView1.DataSource = bindingSource;
                BackColor = SharedClass.BackColor;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNewOrder frmNewOrder = new frmNewOrder();
            frmNewOrder.ShowDialog();
            dataGridView1.Refresh();
            if (SharedClass.ctnDataGridView1FrmOrders_Products != null)
                SharedClass.ctnDataGridView1FrmOrders_Products.Refresh();

            if (SharedClass.NewOrderCreated)
            {
                Func<string> myDelegate = new Func<string>(Check);
                IAsyncResult asyncResult = myDelegate.BeginInvoke(null, null);
                Thread.Sleep(1000);
                string fileInfo = myDelegate.EndInvoke(asyncResult);
                MessageBox.Show(fileInfo, "Создание файла 'Чек'", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmCheck frmCheck = new frmCheck();
                frmCheck.Show();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            Order order = dataGridView1.CurrentRow.DataBoundItem as Order;

            if (order == null) return;

            IEnumerable<Order_Product> order_Products = SharedClass.storeModel.Orders_Products.Where(id => id.OrderId == order.Id);
            SharedClass.storeModel.Orders_Products.RemoveRange(order_Products);

            Order selectedOrder = SharedClass.storeModel.Orders.Find(order.Id);
            SharedClass.storeModel.Orders.Remove(selectedOrder);

            SharedClass.storeModel.SaveChanges();
            dataGridView1.Refresh();
            if (SharedClass.ctnDataGridView1FrmOrders_Products != null)
                SharedClass.ctnDataGridView1FrmOrders_Products.Refresh();
        }

        private static string Check()
        {
            DirectoryInfo currentDirectory = new DirectoryInfo(@".");
            string tempName = currentDirectory.FullName + "\\temp";
            DirectoryInfo tempDirectory = new DirectoryInfo(tempName);
            try
            {
                if (!tempDirectory.Exists)
                    tempDirectory = currentDirectory.CreateSubdirectory("temp");
            }
            catch
            {
                return "Директорию 'temp' создать не удалось";
            }

            IEnumerable<Order> orders = SharedClass.storeModel.Orders;
            Order order = orders.Last<Order>();
            Customer customer = SharedClass.storeModel.Customers.Where(cus => cus.Id == order.CustomerId).FirstOrDefault<Customer>();
            Employee employee = SharedClass.storeModel.Employees.Where(emp => emp.Id == order.EmployeeId).FirstOrDefault<Employee>();

            Order_Product order_product = new Order_Product();
            List<Order_Product> orders_products = SharedClass.storeModel.Orders_Products.Where(o_p => o_p.OrderId == order.Id).ToList();
            List<Product> products = SharedClass.storeModel.Products.ToList();
            List<Product> selectedProducts = new List<Product>();
            
            foreach (Order_Product o_p in orders_products)
                foreach (Product pr in products)
                    if (o_p.ProductId == pr.Id)
                        selectedProducts.Add(pr);

            StringBuilder text = new StringBuilder();
            text.AppendLine("Заказ №" + order.Id);
            text.AppendLine("Покупатель: " + customer.FirstName + " " + customer.LastName);
            text.AppendLine("Сотрудник: " + employee.FirstName + " " + employee.LastName);
            text.AppendLine();
            text.AppendLine("Купленные товары:");
            foreach (Product item in selectedProducts)
            {
                text.Append(item.ProductName + ", Стоимость: " + item.Cost + ", Количество: ");
                order_product = orders_products.Where(o_p => o_p.ProductId == item.Id).FirstOrDefault<Order_Product>();
                text.AppendLine(order_product.Quantity.ToString());
            }
            text.AppendLine();
            text.AppendLine("Общая цена: " + order.TotalPrice);
            text.AppendLine("Дата: " + order.Date);

            SharedClass.fileName = tempDirectory.FullName + "\\check.txt";            
            if (tempDirectory.Exists)
            {
                try
                {
                    if (File.Exists(SharedClass.fileName))
                        File.Delete(SharedClass.fileName);
                    File.AppendAllText(SharedClass.fileName, text.ToString());
                }
                catch
                {
                    return "Файл 'Чек' создать не удалось";
                }
            }
            return "Файл 'Чек' создан";
        }
    }
}
