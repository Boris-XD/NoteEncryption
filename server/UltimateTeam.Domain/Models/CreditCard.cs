using System;
using System.Collections.Generic;

#nullable disable

namespace Dev33.UltimateTeam.Domain.Models
{
    public partial class CreditCard
    {
        public Guid InformationsId { get; set; }
        [Display(Encrypted = true, Sensitive = false)]
        public string Name { get; set; }
        [Display(Encrypted = false, Sensitive = false)]
        public string Number { get; set; }
        public DateTime Expiration { get; set; }
        [Display(Encrypted = true, Sensitive = true)]
        public string Cvv { get; set; }
        [Display(Encrypted = true, Sensitive = true)]
        public string Issuer { get; set; }

        public virtual Information Informations { get; set; }
    }
}
