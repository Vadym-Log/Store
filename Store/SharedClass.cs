using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Store
{
    public enum User
    { 
        Customer = 1,
        Employee = 2
    }
    public static class SharedClass
    {
        public static StoreModel storeModel;
        public static User User;
        public static Employee Employee;
        public static Customer Customer;
        public static bool addLogin;
        public static List<Order_Product> Orders_Products;
        public static string fileName;
        public static Control ctnDataGridView1FrmOrders_Products;
        public static bool NewOrderCreated;
        public static Color BackColor;
    }
}
