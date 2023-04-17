using System;
using System.Collections.Generic;

#nullable disable

namespace Dev33.UltimateTeam.Domain.Models
{
    public partial class Tag
    {
        public Guid Id { get; set; }
        [Display(Encrypted = false, Sensitive = false)]
        public string Name { get; set; }
        public Guid InformationId { get; set; }

        public virtual Information Information { get; set; }
    }
}
