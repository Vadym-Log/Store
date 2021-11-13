using System;
using System.Data.Entity;
using System.Drawing;
using System.Windows.Forms;

namespace Store
{
    public partial class frmProducers : Form
    {
        public frmProducers()
        {
            InitializeComponent();
            if (SharedClass.User == User.Employee && SharedClass.Employee.Position == Position.Seller
                || SharedClass.User == User.Customer)
            {
                Controls.Remove(label1);
                Controls.Remove(label2);
                Controls.Remove(label3);
                Controls.Remove(txtProducer);
                Controls.Remove(txtCountry);
                Controls.Remove(txtPhone);
                Controls.Remove(btnAdd);
                Controls.Remove(btnDelete);
                Size = new Size(496, 480);
            }
            SharedClass.storeModel.Producers.Load();
            dataGridView1.DataSource = SharedClass.storeModel.Producers.Local.ToBindingList();
            if (SharedClass.User == User.Customer)
                BackColor = SharedClass.BackColor;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtProducer.Text == String.Empty)
            {
                MessageBox.Show("Введите название производителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtCountry.Text == String.Empty)
            {
                MessageBox.Show("Введите страну производителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtPhone.Text == String.Empty)
            {
                MessageBox.Show("Введите телефон производителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Producer producer = new Producer();
            producer.ProducerName = txtProducer.Text;
            producer.Country = txtCountry.Text;
            producer.Phone = txtPhone.Text;
            SharedClass.storeModel.Producers.Add(producer);

            SharedClass.storeModel.SaveChanges();
            dataGridView1.Refresh();
            txtProducer.Text = String.Empty;
            txtCountry.Text = String.Empty;
            txtPhone.Text = String.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            Producer producer = dataGridView1.CurrentRow.DataBoundItem as Producer;

            if (producer == null) return;

            int id = producer.Id;
            Producer selectedProducer = SharedClass.storeModel.Producers.Find(id);
            SharedClass.storeModel.Producers.Remove(selectedProducer);

            SharedClass.storeModel.SaveChanges();
            dataGridView1.Refresh();
        }
    }
}
