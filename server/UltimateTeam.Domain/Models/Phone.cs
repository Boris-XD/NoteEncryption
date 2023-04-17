using System;
using System.Collections.Generic;

#nullable disable

namespace Dev33.UltimateTeam.Domain.Models
{
    public partial class Phone
    {
        public Guid Id { get; set; }
        [Display(Encrypted = true, Sensitive = false)]
        public string Number { get; set; }
        public Guid ContactId { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
