using System;
using System.Collections.Generic;

#nullable disable

namespace Cautionem.Models
{
    public partial class Order
    {
        public int CompanyId { get; set; }
        public int FileId { get; set; }
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
    }
}
