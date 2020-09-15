using System;
using System.Collections.Generic;

namespace Cautionem.Models
{
    public partial class Country
    {
        public Country()
        {
            Customer = new HashSet<Customer>();
        }

        public string CountryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
