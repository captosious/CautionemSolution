using System;
using System.Collections.Generic;

namespace Cautionem.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string TaxId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
