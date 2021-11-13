using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Store
{
    public partial class frmNewOrder : Form
    {
        public frmNewOrder()
        {
            InitializeComponent();
            SharedClass.Orders_Products = new List<Order_Product>();
            SharedClass.NewOrderCreated = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddProduct frmAddProduct = new frmAddProduct();
            frmAddProduct.ShowDialog();
            MessageBox.Show("Список товаров сформирован.\nСформируйте заказ", "Формирование заказа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnAdd.Enabled = false;
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            if (btnAdd.Enabled == true)
            {
                MessageBox.Show("Сформируйте список товаров", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Customer customer = null;
            int? idCustomer = null;
            if (SharedClass.Orders_Products.Count > 0)
            {
                try
                {
                    idCustomer = Convert.ToInt32(txtCustomer.Text);
                }
                catch
                {
                    MessageBox.Show("Введен неверный ID код покупателя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                customer = SharedClass.storeModel.Customers.Find(idCustomer);
                if (txtCustomer.Text == string.Empty || customer == null)
                {
                    MessageBox.Show("Покупатель с указанным ID кодом отсутствует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                Order order = new Order();
                order.CustomerId = customer.Id;
                order.EmployeeId = SharedClass.Employee.Id;
                order.Date = DateTime.Now;
                double totalPrice = 0;
                foreach (Order_Product item in SharedClass.Orders_Products)
                {
                    Product product = SharedClass.storeModel.Products.Find(item.ProductId);
                    totalPrice += product.Cost * item.Quantity;
                }
                order.TotalPrice = totalPrice;
                SharedClass.storeModel.Orders.Add(order);
                SharedClass.storeModel.SaveChanges();

                List<Order> ordersList = SharedClass.storeModel.Orders.ToList();
                order = ordersList.Last();
                foreach (Order_Product item in SharedClass.Orders_Products)
                {
                    item.OrderId = order.Id;
                    SharedClass.storeModel.Orders_Products.Add(item);
                }
                SharedClass.storeModel.SaveChanges();
                SharedClass.NewOrderCreated = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Список товаров пуст. Добавьте товар", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnAdd.Enabled = true;
                return;
            }
        }
    }
}
