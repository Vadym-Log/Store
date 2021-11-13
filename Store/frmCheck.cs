using System.IO;
using System.Windows.Forms;

namespace Store
{
    public partial class frmCheck : Form
    {
        public frmCheck()
        {
            InitializeComponent();

            try
            {
                string text = File.ReadAllText(SharedClass.fileName);
                richTextBox1.Text = text;
            }
            catch
            {
                MessageBox.Show("Файл 'Чек' не удалось прочесть");
            }
        }
    }
}
