using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Store
{
    public partial class frmAuth : Form
    {
        public frmAuth()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain();
            if (txtLogin.Text == "")
            {
                MessageBox.Show("Вы не ввели Login", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Вы не ввели Password", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }                
            else if (SharedClass.User == User.Customer)
            {
                IQueryable<Log_Cus> log_cus = SharedClass.storeModel.Logs_Cuss;
                var customerLogin = log_cus.Where(log => log.LoginName == txtLogin.Text).FirstOrDefault();

                if (customerLogin != null && customerLogin.LoginName == txtLogin.Text && customerLogin.Password == txtPassword.Text)
                {
                    IQueryable<Customer> customers = SharedClass.storeModel.Customers;
                    SharedClass.Customer = customers.Where(cus => cus.Id == customerLogin.CustomerId).FirstOrDefault();
                    frmMain.Text = "Приветствуем, " + SharedClass.Customer.FirstName + " " + SharedClass.Customer.LastName + "!";
                }
                else
                {
                    MessageBox.Show("Вы ввели неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }                    
            }
            else
            {
                IQueryable<Log_Emp> log_emp = SharedClass.storeModel.Logs_Emps;
                var employeeLogin = log_emp.Where(log => log.LoginName == txtLogin.Text).FirstOrDefault();

                if (employeeLogin != null && employeeLogin.LoginName == txtLogin.Text && employeeLogin.Password == txtPassword.Text)
                {
                    IQueryable<Employee> employees = SharedClass.storeModel.Employees;
                    SharedClass.Employee = employees.Where(emp => emp.Id == employeeLogin.EmployeeId).FirstOrDefault();

                    switch (SharedClass.Employee.Position.ToString())
                    {
                        case "Director":
                            frmMain.Text = "Hello, " + SharedClass.Employee.FirstName + " " + SharedClass.Employee.LastName + "!!!";
                            break;
                        case "Manager":
                            frmMain.Text = "Good Luck, " + SharedClass.Employee.FirstName + " " + SharedClass.Employee.LastName + "...";
                            break;
                        case "Seller":
                            frmMain.Text = "Hi! " + SharedClass.Employee.FirstName + " " + SharedClass.Employee.LastName + ".";
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Вы ввели неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }                    
            }
            frmMain.Show();
            this.Close();
        }
    }
}
