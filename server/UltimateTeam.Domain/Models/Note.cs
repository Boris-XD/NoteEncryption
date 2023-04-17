using System;
using System.Collections.Generic;

#nullable disable

namespace Dev33.UltimateTeam.Domain.Models
{
    public partial class Note
    {
        public Guid InformationsId { get; set; }
        [Display(Encrypted = true, Sensitive = false)]
        public string Text { get; set; }


        public virtual Information Informations { get; set; }
    }
}
