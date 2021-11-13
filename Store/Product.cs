using System.Collections.Generic;

namespace Store
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Cost { get; set; }
        public int? ProducerId { get; set; }
        //public Producer Producer { get; set; }
        public int? CategoryId { get; set; }
        //public Category Category { get; set; }

        //public ICollection<Order_Product> Orders_Products { get; set; }

        //public Product()
        //{
        //    Orders_Products = new List<Order_Product>();
        //}
    }
}
