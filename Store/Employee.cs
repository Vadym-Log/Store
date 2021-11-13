using System.Collections.Generic;

namespace Store
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public Position Position { get; set; }

        //public ICollection<Order> Orders { get; set; }

        //public Employee()
        //{
        //    Orders = new List<Order>();
        //}
    }
}
