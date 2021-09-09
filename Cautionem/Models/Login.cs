using System;
namespace Cautionem.Models
{
    public class Login
    {
        public int CompanyId { get; set; }
        public string Username { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string CompleteName { get; set; }
        public string CompleteNameReverse { get; set; }
        public int SecurityId { get; set; }
        public byte[] Picture { get; set; }
    }
}
