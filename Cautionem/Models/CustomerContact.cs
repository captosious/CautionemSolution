using System;
using System.Collections.Generic;

#nullable disable

namespace Cautionem.Models
{
    public partial class CustomerContact
    {
        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public string Zip { get; set; }
        public string CountryId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual Customer C { get; set; }
    }
}
