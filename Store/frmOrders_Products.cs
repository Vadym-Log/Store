using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Store
{
    public partial class frmOrders_Products : Form
    {
        public frmOrders_Products()
        {
            InitializeComponent();

            SharedClass.storeModel.Orders_Products.Load();
            if (SharedClass.User == User.Employee)
                dataGridView1.DataSource = SharedClass.storeModel.Orders_Products.Local.ToBindingList();
            else
            {
                Customer customer = SharedClass.storeModel.Customers.Find(SharedClass.Customer.Id);
                List<Order> customerOrders = SharedClass.storeModel.Orders.Where(id => id.CustomerId == customer.Id).ToList();
                List<Order_Product> orders_products = SharedClass.storeModel.Orders_Products.ToList();

                List<Order_Product> selected_Orders_Products = new List<Order_Product>();
                foreach (Order order in customerOrders)
                    foreach (Order_Product order_product in orders_products)
                        if (order.Id == order_product.OrderId)
                            selected_Orders_Products.Add(order_product);
                
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = selected_Orders_Products;
                dataGridView1.DataSource = bindingSource;

                Control ctnDataGridView1FrmOrders_Products = this.Controls["dataGridView1"];
                SharedClass.ctnDataGridView1FrmOrders_Products = ctnDataGridView1FrmOrders_Products;
                BackColor = SharedClass.BackColor;
            }
        }
    }
}
