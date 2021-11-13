using System;
using System.Data.Entity;
using System.Drawing;
using System.Windows.Forms;

namespace Store
{
    public partial class frmCategories : Form
    {
        public frmCategories()
        {
            InitializeComponent();
            if (SharedClass.User == User.Employee &&
                (SharedClass.Employee.Position == Position.Manager || SharedClass.Employee.Position == Position.Seller)
                || SharedClass.User == User.Customer)
            {
                Controls.Remove(label1);                
                Controls.Remove(txtCategory);                
                Controls.Remove(btnAdd);
                Controls.Remove(btnDelete);
                Size = new Size(295, 330);
            }
            SharedClass.storeModel.Categories.Load();
            dataGridView1.DataSource = SharedClass.storeModel.Categories.Local.ToBindingList();
            if(SharedClass.User == User.Customer)
                BackColor = SharedClass.BackColor;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCategory.Text == String.Empty)
            {
                MessageBox.Show("Введите название категории", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Category category = new Category();
            category.CategoryName = txtCategory.Text;
            SharedClass.storeModel.Categories.Add(category);

            SharedClass.storeModel.SaveChanges();
            dataGridView1.Refresh();
            txtCategory.Text = String.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            Category category = dataGridView1.CurrentRow.DataBoundItem as Category;

            if (category == null) return;

            int id = category.Id;
            Category selectedCategory = SharedClass.storeModel.Categories.Find(id);
            SharedClass.storeModel.Categories.Remove(selectedCategory);

            SharedClass.storeModel.SaveChanges();
            dataGridView1.Refresh();
        }
    }
}
