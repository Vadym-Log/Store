using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Store
{
    public partial class frmNewLogin : Form
    {
        public frmNewLogin()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            SharedClass.addLogin = false;
            if (txtNewLogin.Text == String.Empty)
            {
                MessageBox.Show("Введите новый Login", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtNewPassword.Text == String.Empty)
            {
                MessageBox.Show("Введите новый Password", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SharedClass.User == User.Customer)
            {
                IQueryable<Log_Cus> log_cus = SharedClass.storeModel.Logs_Cuss;
                var customerLogin = log_cus.Where(log => log.LoginName == txtNewLogin.Text).FirstOrDefault();

                if (customerLogin != null && txtNewLogin.Text == customerLogin.LoginName)
                {
                    MessageBox.Show("Введенный логин уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var customerPassword = log_cus.Where(log => log.Password == txtNewPassword.Text).FirstOrDefault();
                if (customerPassword != null && txtNewPassword.Text == customerPassword.Password)
                {
                    MessageBox.Show("Введенный пароль уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Log_Cus new_log_cus = new Log_Cus();
                new_log_cus.LoginName = txtNewLogin.Text;
                new_log_cus.Password = txtNewPassword.Text;
                List<Customer> customersList = SharedClass.storeModel.Customers.ToList();
                Customer newCustomer = customersList.Last();
                new_log_cus.CustomerId = newCustomer.Id;
                SharedClass.storeModel.Logs_Cuss.Add(new_log_cus);
                SharedClass.storeModel.SaveChanges();
                SharedClass.addLogin = true;
                this.Close();
            }
            else
            {
                IQueryable<Log_Emp> log_emp = SharedClass.storeModel.Logs_Emps;
                var employeeLogin = log_emp.Where(log => log.LoginName == txtNewLogin.Text).FirstOrDefault();

                if (employeeLogin != null && txtNewLogin.Text == employeeLogin.LoginName)
                {
                    MessageBox.Show("Введенный логин уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var employeePassword = log_emp.Where(log => log.Password == txtNewPassword.Text).FirstOrDefault();
                if (employeePassword != null && txtNewPassword.Text == employeePassword.Password)
                {
                    MessageBox.Show("Введенный пароль уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Log_Emp new_log_emp = new Log_Emp();
                new_log_emp.LoginName = txtNewLogin.Text;
                new_log_emp.Password = txtNewPassword.Text;
                List<Employee> employeesList = SharedClass.storeModel.Employees.ToList();
                Employee newEmployee = employeesList.Last();
                new_log_emp.EmployeeId = newEmployee.Id;
                SharedClass.storeModel.Logs_Emps.Add(new_log_emp);
                SharedClass.storeModel.SaveChanges();
                SharedClass.addLogin = true;
                this.Close();
            }
        }        
    }
}
