using System;
using System.Collections.Generic;

#nullable disable

namespace Dev33.UltimateTeam.Domain.Models
{
    public partial class Url
    {
        public Guid Id { get; set; }
        [Display(Encrypted = true, Sensitive = false)]
        public string Address { get; set; }
        public Guid CredentialId { get; set; }

        public virtual Credential Credential { get; set; }
    }
}
