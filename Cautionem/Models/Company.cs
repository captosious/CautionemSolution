using System;
using System.Collections.Generic;

namespace Cautionem.Models
{
    public partial class Company
    {
        public Company()
        {
            Bank = new HashSet<Bank>();
            Customer = new HashSet<Customer>();
            Item = new HashSet<Item>();
            Order = new HashSet<Order>();
            PaymentType = new HashSet<PaymentType>();
        }

        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string FiscalId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Bank> Bank { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<PaymentType> PaymentType { get; set; }
    }
}
