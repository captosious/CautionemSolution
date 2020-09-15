using System;
using System.Collections.Generic;

namespace Cautionem.Models
{
    public partial class Tax
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Tax1 { get; set; }
    }
}
