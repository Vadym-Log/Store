using System;
using System.Windows.Forms;

namespace Store
{
    public partial class frmAddProduct : Form
    {
        public frmAddProduct()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Order_Product order_product = new Order_Product();
            Product addProduct = null;
            int? id = null;
            int quantity = 0;
            try
            {
                id = Convert.ToInt32(txtProductID.Text);
            }
            catch
            {
                MessageBox.Show("Введен неверный ID код товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            addProduct = SharedClass.storeModel.Products.Find(id);
            if (txtProductID.Text == string.Empty || addProduct == null)
            {
                MessageBox.Show("Товар с указанным ID кодом отсутствует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                quantity = Convert.ToInt32(txtQuantity.Text);
            }
            catch
            {
                MessageBox.Show("Введено неверное количество товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtQuantity.Text == string.Empty || quantity == 0)
            {
                MessageBox.Show("Введите количество товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            order_product.ProductId = addProduct.Id;
            order_product.Quantity = quantity;
            SharedClass.Orders_Products.Add(order_product);
            txtProductID.Text = string.Empty;
            txtQuantity.Text = string.Empty;
        }
    }
}
