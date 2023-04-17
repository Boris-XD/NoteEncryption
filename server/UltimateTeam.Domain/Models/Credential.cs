using System;
using System.Collections.Generic;

#nullable disable

namespace Dev33.UltimateTeam.Domain.Models
{
    public partial class Credential
    {
        public Credential()
        {
            Urls = new HashSet<Url>();
        }

        public Guid InformationsId { get; set; }
        [Display(Encrypted = true, Sensitive = false)]
        public string UserName { get; set; }
        [Display(Encrypted = true, Sensitive = true)]
        public string Password { get; set; }


        public virtual Information Informations { get; set; }
        public virtual ICollection<Url> Urls { get; set; }
    }
}
