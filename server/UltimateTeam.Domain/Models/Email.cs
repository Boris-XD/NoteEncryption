using System;
using System.Collections.Generic;

#nullable disable

namespace Dev33.UltimateTeam.Domain.Models
{
    public partial class Email
    {
        public Guid Id { get; set; }
        [Display(Encrypted = true, Sensitive = false)]
        public string Mail { get; set; }
        public Guid ContactId { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
