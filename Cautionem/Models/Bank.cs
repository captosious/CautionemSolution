using System;
using System.Collections.Generic;

namespace Cautionem.Models
{
    public partial class Bank: ICloneable
    {
        public int CompanyId { get; set; }
        public int BankId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Account { get; set; }

        public virtual Company Company { get; set; }

        public object Clone()
        {
            return (Bank)this.MemberwiseClone();
        }
    }
}
