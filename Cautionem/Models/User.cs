using System;
using System.Collections.Generic;

#nullable disable

namespace Cautionem.Models
{
    public partial class User
    {
        public int CompanyId { get; set; }
        public string Username { get; set; }
        public int Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public byte[] Picture { get; set; }
        public int SecurityId { get; set; }
    }
}
