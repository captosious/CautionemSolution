using System;
using System.Collections.Generic;

namespace Cautionem.Models
{
    public partial class Invoice
    {
        public int CompanyId { get; set; }
        public int OrderId { get; set; }
        public int InvoiceId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? IssuedOn { get; set; }
        public DateTime? PaidOn { get; set; }
    }
}
