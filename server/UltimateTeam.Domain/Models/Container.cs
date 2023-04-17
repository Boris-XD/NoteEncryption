using System;
using System.Collections.Generic;

#nullable disable

namespace Dev33.UltimateTeam.Domain.Models
{
    public partial class Container
    {
        public Container()
        {
            Information = new HashSet<Information>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Favorite { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Information> Information { get; set; }
    }
}
