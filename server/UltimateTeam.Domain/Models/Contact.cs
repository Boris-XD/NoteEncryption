using System;
using System.Collections.Generic;

#nullable disable

namespace Dev33.UltimateTeam.Domain.Models
{
    public partial class Contact
    {
        public Contact()
        {
            Addresses = new HashSet<Address>();
            Emails = new HashSet<Email>();
            Phones = new HashSet<Phone>();
        }

        public Guid InformationsId { get; set; }
        [Display(Encrypted = true, Sensitive = false)]
        public string FullName { get; set; }
        [Display(Encrypted = false, Sensitive = false)]
        public string FirstName { get; set; }
        [Display(Encrypted = false, Sensitive = false)]
        public string LastName { get; set; }
        [Display(Encrypted = true, Sensitive = false)]
        public string Business { get; set; }
        [Display(Encrypted = true, Sensitive = false)]
        public string Zip { get; set; }
        [Display(Encrypted = true, Sensitive = false)]
        public string Country { get; set; }
        [Display(Encrypted = true, Sensitive = false)]
        public string State { get; set; }
        public DateTime Birthday { get; set; }


        public virtual Information Informations { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
