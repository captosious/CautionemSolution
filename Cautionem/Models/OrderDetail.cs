using System;
using System.Collections.Generic;

namespace Cautionem.Models
{
    public partial class OrderDetail
    {
        public int CompanyId { get; set; }
        public int OrderId { get; set; }
        public int OrderDetailId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal? ItemPrice { get; set; }
    }
}
