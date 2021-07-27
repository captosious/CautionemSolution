using System;
using System.Collections.Generic;

#nullable disable

namespace Cautionem.Models
{
    public partial class PaymentType
    {
        public int CompanyId { get; set; }
        public int PaymentId { get; set; }
        public string Name { get; set; }
        public string Terms { get; set; }

        public virtual Company Company { get; set; }
    }
}
