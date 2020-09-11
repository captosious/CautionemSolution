using System;
using System.Collections.Generic;

namespace Cautionem.Models
{
    public partial class CustomerAddress
    {
        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
        public int CustomerAddressId { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public string Zip { get; set; }
        public string ContactName { get; set; }
        public string ContactSurname { get; set; }
        public string ContactEmail { get; set; }
        public string Phone { get; set; }

        public virtual Customer C { get; set; }
    }
}
