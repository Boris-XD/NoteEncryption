using System;
using System.Collections.Generic;

#nullable disable

namespace Dev33.UltimateTeam.Domain.Models
{
    public partial class User
    {
        public User()
        {
            Containers = new HashSet<Container>();
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public virtual ShareInformation ShareInformation { get; set; }
        public virtual ICollection<Container> Containers { get; set; }
    }
}
