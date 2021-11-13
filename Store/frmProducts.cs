using System;
using System.Data.Entity;
using System.Drawing;
using System.Windows.Forms;

namespace Store
{
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
            if (SharedClass.User == User.Employee && SharedClass.Employee.Position == Position.Seller
                || SharedClass.User == User.Customer)
            {
                Controls.Remove(label1);
                Controls.Remove(label2);
                Controls.Remove(label3);
                Controls.Remove(label4);
                Controls.Remove(txtProduct);
                Controls.Remove(txtCost);
                Controls.Remove(txtCategoryID);
                Controls.Remove(txtProducerID);
                Controls.Remove(btnAdd);
                Controls.Remove(btnDelete);
                Size = new Size(608, 470);
            }

            // Вариант, чтобы удалить неиспользуемые поля при отображении
            // Работает, но неиспользуемые поля всё равно отображаются
            // Просто они становятся "пустыми" - без информации

            //List<Product> collectionProducts = SharedClass.storeModel.Products.Local.ToList();
            //var collection = collectionProducts.Select(p => new Product()
            //{
            //    ProductName = p.ProductName,
            //    Cost = p.Cost
            //});
            //ObservableCollection<Product> collect = new ObservableCollection<Product>(collection);
            //dataGridView1.DataSource = collect.ToBindingList();

            //В результате, в классе Product и в других аналогичных классах для создания базы данных
            //были просто закомментированы следующие поля:

            //public Producer Producer { get; set; }
            //public Category Category { get; set; }
            //public ICollection<Order_Product> Orders_Products { get; set; }
            //public Product()
            //{
            //    Orders_Products = new List<Order_Product>();
            //}

            //Они ни как не используются для создания базы данных, по крайней мере в данном приложении,
            //и, фактически, только "мешают"

            SharedClass.storeModel.Products.Load();
            dataGridView1.DataSource = SharedClass.storeModel.Products.Local.ToBindingList();
            if (SharedClass.User == User.Customer)
                BackColor = SharedClass.BackColor;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtProduct.Text == String.Empty)
            {
                MessageBox.Show("Введите название товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtCost.Text == String.Empty)
            {
                MessageBox.Show("Введите стоимость товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtCategoryID.Text == String.Empty)
            {
                MessageBox.Show("Введите ID код категории", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtProducerID.Text == String.Empty)
            {
                MessageBox.Show("Введите ID код производителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Product product = new Product();
            product.ProductName = txtProduct.Text;
            product.Cost = Convert.ToDouble(txtCost.Text);
            product.CategoryId = Convert.ToInt32(txtCategoryID.Text);
            product.ProducerId = Convert.ToInt32(txtProducerID.Text);
            SharedClass.storeModel.Products.Add(product);

            SharedClass.storeModel.SaveChanges();
            dataGridView1.Refresh();
            txtProduct.Text = String.Empty;
            txtCost.Text = String.Empty;
            txtCategoryID.Text = String.Empty;
            txtProducerID.Text = String.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            Product product = dataGridView1.CurrentRow.DataBoundItem as Product;

            if (product == null) return;

            int id = product.Id;
            Product selectedProduct = SharedClass.storeModel.Products.Find(id);
            SharedClass.storeModel.Products.Remove(selectedProduct);

            SharedClass.storeModel.SaveChanges();
            dataGridView1.Refresh();
        }
    }
}
