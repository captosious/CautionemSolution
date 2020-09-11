using System;
using System.Collections.Generic;

namespace Cautionem.Models
{
    public partial class Order
    {
        public int CompanyId { get; set; }
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }

        public virtual Company Company { get; set; }
    }
}
