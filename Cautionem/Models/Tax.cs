using System;
using System.Collections.Generic;

#nullable disable

namespace Cautionem.Models
{
    public partial class Tax
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Tax1 { get; set; }
    }
}
