using System;
using System.Collections.Generic;

namespace Cautionem.Models
{
    public partial class Invoice
    {
        public string InvoiceId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? IssuedOn { get; set; }
        public DateTime? PaidOn { get; set; }
    }
}
