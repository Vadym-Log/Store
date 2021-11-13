using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Store
{
    public partial class frmEmployees : Form
    {
        public frmEmployees()
        {
            InitializeComponent();
            if (SharedClass.Employee.Position == Position.Manager || SharedClass.Employee.Position == Position.Seller)
            {
                Controls.Remove(label1);
                Controls.Remove(label2);
                Controls.Remove(label3);
                Controls.Remove(label3);
                Controls.Remove(label4);
                Controls.Remove(label5);
                Controls.Remove(label6);
                Controls.Remove(label7);
                Controls.Remove(txtFirstName);
                Controls.Remove(txtLastName);
                Controls.Remove(txtPhone);
                Controls.Remove(txtAddress);
                Controls.Remove(txtAge);
                Controls.Remove(txtSex);
                Controls.Remove(txtPosition);
                Controls.Remove(btnAdd);
                Controls.Remove(btnDelete);
                Size = new Size(876, 470);
            }
            SharedClass.storeModel.Employees.Load();
            dataGridView1.DataSource = SharedClass.storeModel.Employees.Local.ToBindingList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == String.Empty)
            {
                MessageBox.Show("Введите имя сотрудника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtLastName.Text == String.Empty)
            {
                MessageBox.Show("Введите фамилию сотрудника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtPhone.Text == String.Empty)
            {
                MessageBox.Show("Введите телефон сотрудника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtAddress.Text == String.Empty)
            {
                MessageBox.Show("Введите адрес сотрудника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtAge.Text == String.Empty)
            {
                MessageBox.Show("Введите возраст сотрудника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSex.Text == String.Empty)
            {
                MessageBox.Show("Введите пол сотрудника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtPosition.Text == String.Empty)
            {
                MessageBox.Show("Введите должность сотрудника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Employee employee = new Employee();
            employee.FirstName = txtFirstName.Text;
            employee.LastName = txtLastName.Text;
            employee.Phone = txtPhone.Text;
            employee.Address = txtAddress.Text;
            employee.Age = Convert.ToInt32(txtAge.Text);

            if (txtSex.Text == "Male")
                employee.Sex = Sex.Male;
            else if (txtSex.Text == "Female")
                employee.Sex = Sex.Female;
            else
            {
                MessageBox.Show("Пол: 'Male' или 'Female'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPosition.Text == "Manager")
                employee.Position = Position.Manager;
            else if (txtPosition.Text == "Seller")
                employee.Position = Position.Seller;
            else
            {
                MessageBox.Show("Должность: 'Manager' или 'Seller'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SharedClass.storeModel.Employees.Add(employee);
            SharedClass.storeModel.SaveChanges();

            SharedClass.User = User.Employee;
            SharedClass.Employee = employee;

            frmNewLogin frmNewLogin = new frmNewLogin();
            frmNewLogin.ShowDialog();

            if (!SharedClass.addLogin)
            {
                List<Employee> employeesList = SharedClass.storeModel.Employees.ToList();
                Employee lastEmployee = employeesList.Last();
                SharedClass.storeModel.Employees.Remove(lastEmployee);
                SharedClass.storeModel.SaveChanges();
            }
            dataGridView1.Refresh();
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtPhone.Text = String.Empty;
            txtAddress.Text = String.Empty;
            txtAge.Text = String.Empty;
            txtSex.Text = String.Empty;
            txtPosition.Text = String.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            Employee employee = dataGridView1.CurrentRow.DataBoundItem as Employee;

            if (employee == null) return;

            int id = employee.Id;
            Employee selectedEmployee = SharedClass.storeModel.Employees.Find(id);

            IQueryable<Log_Emp> log_emp = SharedClass.storeModel.Logs_Emps;
            Log_Emp selectedLog = log_emp.Where(log => log.EmployeeId == employee.Id).FirstOrDefault();

            if (selectedLog != null)
                SharedClass.storeModel.Logs_Emps.Remove(selectedLog);
            SharedClass.storeModel.Employees.Remove(selectedEmployee);

            SharedClass.storeModel.SaveChanges();
            dataGridView1.Refresh();
        }
    }
}
