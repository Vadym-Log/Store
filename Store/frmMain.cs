using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace Store
{
    public partial class frmMain : Form
    {
        XmlTextWriter xmlWriter = null;
        string xmlSettings;
        public frmMain()
        {
            InitializeComponent();
            if (SharedClass.User == User.Customer)
            {
                Controls.Remove(btnEmployees);
                Controls.Remove(btnCustomers);
                btnOrders.Location = new Point(12, 12);
                btnOrders_Products.Location = new Point(12, 102);
                Size = new Size(436, 310);

                Button btnColor = new Button();
                Controls.Add(btnColor);
                btnColor.Location = new Point(60, 190);
                btnColor.AutoSize = true;
                btnColor.Image = Properties.Resources.circle_palette;
                btnColor.Click += new System.EventHandler(this.btnColor_Click);

                try
                {
                    if (ReadSettings() == false)
                        MessageBox.Show("В файле конфигурации настройки отсутствуют", "Настройка цвета формы", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Персональные настройки загружены из файла конфигурации", "Настройка цвета формы", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Возникла проблема при загрузке данных из файла конфигурации", "Настройка цвета формы", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }            
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            frmProducts frmProducts = new frmProducts();
            frmProducts.Show();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            frmCategories frmCategories = new frmCategories();
            frmCategories.Show();
        }

        private void btnProducers_Click(object sender, EventArgs e)
        {
            frmProducers frmProducers = new frmProducers();
            frmProducers.Show();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            frmEmployees frmEmployees = new frmEmployees();
            frmEmployees.Show();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            frmCustomers frmCustomers = new frmCustomers();
            frmCustomers.Show();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            frmOrders frmOrders = new frmOrders();
            frmOrders.Show();
        }

        private void btnOrders_Products_Click(object sender, EventArgs e)
        {
            frmOrders_Products frmOrders_Products = new frmOrders_Products();
            frmOrders_Products.Show();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                BackColor = colorDialog1.Color;
            SaveSettings();
        }

        private bool ReadSettings()
        {
            NameValueCollection allAppSettings = ConfigurationManager.AppSettings;
            if (allAppSettings.Count < 1) { return false; }

            int redBack = Convert.ToInt32(allAppSettings["BackColor.R"]);
            int greenBack = Convert.ToInt32(allAppSettings["BackColor.G"]);
            int blueBack = Convert.ToInt32(allAppSettings["BackColor.B"]);
            BackColor = Color.FromArgb(redBack, greenBack, blueBack);
            SharedClass.BackColor = BackColor;

            return (true);
        }

        private void SaveSettings()
        {
            // Массив ключей (создан для упрощения обращения к файлу конфигурации).
            string[] keys = new string[] { "BackColor.R",
                                           "BackColor.G",
                                           "BackColor.B" };

            // Массив значений (создан для упрощения обращения к файлу конфигурации).
            string[] values = new string[] { BackColor.R.ToString(),
                                             BackColor.G.ToString(),
                                             BackColor.B.ToString() };

            // Сохранение происходит при помощи работы с XML.
            XmlDocument doc = loadConfigDocument();

            // Открываем узел appSettings, в котором содержится перечень настроек.
            XmlNode node = doc.SelectSingleNode("//appSettings");
            XmlNode childNode = null;
            string childNodeName = "Customer_" + SharedClass.Customer.Id;
            if (node.ChildNodes.Count == 0)
                childNode = doc.CreateElement(childNodeName);

            //doc.Save(Assembly.GetExecutingAssembly().Location + ".config");
            //string myChildNodeName = "//" + childNodeName;
            //childNode = doc.SelectSingleNode(myChildNodeName);

            // Цикл модификации файла конфигурации.
            for (int i = 0; i < keys.Length; i++)
            {
                // Обращаемся к конкретной строке по ключу.
                XmlElement element = node.SelectSingleNode(string.Format("//add[@key='{0}']", keys[i])) as XmlElement;

                // Если строка с таким ключем существует - записываем значение.
                if (element != null)
                    element.SetAttribute("value", values[i]);
                else
                {
                    // Иначе: создаем строку и формируем в ней пару [ключ]-[значение].
                    element = doc.CreateElement("add");
                    element.SetAttribute("key", keys[i]);
                    element.SetAttribute("value", values[i]);
                    node.AppendChild(element);
                }
            }
            // Сохраняем результат модификации.
            doc.Save(Assembly.GetExecutingAssembly().Location + ".config");
            MessageBox.Show("Настройки сохранены в файле конфигурации", "Настройка цвета формы", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private XmlDocument loadConfigDocument()
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(Assembly.GetExecutingAssembly().Location + ".config");
                return doc;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new Exception("No configuration file found.", e);
            }
        }
    }
}
