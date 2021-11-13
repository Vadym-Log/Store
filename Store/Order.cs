using System;
using System.Collections.Generic;

namespace Store
{
    public class Order
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public int? CustomerId { get; set; }
        //public Customer Customer { get; set; }
        public int? EmployeeId { get; set; }
        //public Employee Employee { get; set; }

        //public ICollection<Order_Product> Orders_Products { get; set; }

        //public Order()
        //{
        //    Orders_Products = new List<Order_Product>();
        //}
    }
}
