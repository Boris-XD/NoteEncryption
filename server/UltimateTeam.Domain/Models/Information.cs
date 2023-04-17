using Dev33.UltimateTeam.Domain.Enums;
using System;
using System.Collections.Generic;

#nullable disable

namespace Dev33.UltimateTeam.Domain.Models
{
    public partial class Information
    {
        public Information()
        {
            ShareInformations = new HashSet<ShareInformation>();
            Tags = new HashSet<Tag>();
        }

        public Guid Id { get; set; }

        [Display(Encrypted = false, Sensitive = false)]
        public string Name { get; set; }
        public bool Favorite { get; set; }

        [Display(Encrypted = false, Sensitive = false)]
        public string Description { get; set; }
        public Guid ContainerId { get; set; }
        public InformationType Type { get; set; }
        public EncryptorType EncryptionType { get; set; }

        public virtual Container Container { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual Credential Credential { get; set; }
        public virtual Key Key { get; set; }
        public virtual Note Note { get; set; }
        public virtual CreditCard CreditCard { get; set; }
        public virtual ICollection<ShareInformation> ShareInformations { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
