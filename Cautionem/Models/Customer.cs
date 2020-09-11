using System;
using System.Collections.Generic;

namespace Cautionem.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerAddress = new HashSet<CustomerAddress>();
        }

        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string TaxId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<CustomerAddress> CustomerAddress { get; set; }
    }
}
