using System;
using System.Collections.Generic;

#nullable disable

namespace Cautionem.Models
{
    public partial class Item
    {
        public int CompanyId { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ItemTypeId { get; set; }
        public string TaxId { get; set; }

        public virtual Company Company { get; set; }
    }
}
