using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Cautionem.Models
{

    public partial class CustomerContact
    {
        public CustomerContact()
        {
            //Id = null;
        }

        public int CompanyId { get; set; }
        public int CustomerId { get; set; }
        [Key][System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(                                                                                                                                                                                                                                                           DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public string Zip { get; set; }
        public string CountryId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual Customer C { get; set; }

    }
}