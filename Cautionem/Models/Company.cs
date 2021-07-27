using System;
using System.Collections.Generic;

#nullable disable

namespace Cautionem.Models
{
    public partial class Company
    {
        public Company()
        {
            Banks = new HashSet<Bank>();
            Customers = new HashSet<Customer>();
            Files = new HashSet<File>();
            Items = new HashSet<Item>();
            PaymentTypes = new HashSet<PaymentType>();
        }

        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string FiscalId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Bank> Banks { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<PaymentType> PaymentTypes { get; set; }
    }
}
