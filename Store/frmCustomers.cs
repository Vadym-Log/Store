using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Store
{
    public partial class frmCustomers : Form
    {
        public frmCustomers()
        {
            InitializeComponent();
            if (SharedClass.Employee.Position == Position.Director || SharedClass.Employee.Position == Position.Manager)
            {
                Controls.Remove(label1);
                Controls.Remove(label2);
                Controls.Remove(label3);
                Controls.Remove(label3);
                Controls.Remove(label4);
                Controls.Remove(label5);
                Controls.Remove(label6);
                Controls.Remove(txtFirstName);
                Controls.Remove(txtLastName);
                Controls.Remove(txtPhone);
                Controls.Remove(txtAddress);
                Controls.Remove(txtAge);
                Controls.Remove(txtSex);
                Controls.Remove(btnAdd);
                Controls.Remove(btnDelete);
                Size = new Size(790, 500);
            }
            SharedClass.storeModel.Customers.Load();
            dataGridView1.DataSource = SharedClass.storeModel.Customers.Local.ToBindingList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == String.Empty)
            {
                MessageBox.Show("Введите имя покупателя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtLastName.Text == String.Empty)
            {
                MessageBox.Show("Введите фамилию покупателя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtPhone.Text == String.Empty)
            {
                MessageBox.Show("Введите телефон покупателя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtAddress.Text == String.Empty)
            {
                MessageBox.Show("Введите адрес покупателя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtAge.Text == String.Empty)
            {
                MessageBox.Show("Введите возраст покупателя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSex.Text == String.Empty)
            {
                MessageBox.Show("Введите пол покупателя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Customer customer = new Customer();
            customer.FirstName = txtFirstName.Text;
            customer.LastName = txtLastName.Text;
            customer.Phone = txtPhone.Text;
            customer.Address = txtAddress.Text;
            customer.Age = Convert.ToInt32(txtAge.Text);

            if (txtSex.Text == "Male")
                customer.Sex = Sex.Male;
            else if (txtSex.Text == "Female")
                customer.Sex = Sex.Female;
            else
            {
                MessageBox.Show("Пол: 'Male' или 'Female'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SharedClass.storeModel.Customers.Add(customer);
            SharedClass.storeModel.SaveChanges();

            SharedClass.User = User.Customer;
            SharedClass.Customer = customer;
            
            frmNewLogin frmNewLogin = new frmNewLogin();
            frmNewLogin.ShowDialog();

            if (!SharedClass.addLogin)
            {
                List<Customer> customersList = SharedClass.storeModel.Customers.ToList();
                Customer lastCustomer = customersList.Last();
                SharedClass.storeModel.Customers.Remove(lastCustomer);
                SharedClass.storeModel.SaveChanges();
            }
            dataGridView1.Refresh();
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtAddress.Text = String.Empty;
            txtAge.Text = String.Empty;
            txtSex.Text = String.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            Customer customer = dataGridView1.CurrentRow.DataBoundItem as Customer;

            if (customer == null) return;

            int id = customer.Id;
            Customer selectedCustomer = SharedClass.storeModel.Customers.Find(id);

            IQueryable<Log_Cus> log_cus = SharedClass.storeModel.Logs_Cuss;
            Log_Cus selectedLog = log_cus.Where(log => log.CustomerId == customer.Id).FirstOrDefault();

            if (selectedLog != null)
                SharedClass.storeModel.Logs_Cuss.Remove(selectedLog);
            SharedClass.storeModel.Customers.Remove(selectedCustomer);

            SharedClass.storeModel.SaveChanges();
            dataGridView1.Refresh();
        }
    }
}
