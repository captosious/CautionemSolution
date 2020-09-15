using System;
using System.Collections.Generic;

namespace Cautionem.Models
{
    public partial class File
    {
        public int CompanyId { get; set; }
        public int FileId { get; set; }
        public string Reference { get; set; }
        public int CustomerId { get; set; }
        public string Folder { get; set; }

        public virtual Customer C { get; set; }
        public virtual Company Company { get; set; }
    }
}
