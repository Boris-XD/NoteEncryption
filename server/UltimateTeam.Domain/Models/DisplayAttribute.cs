using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev33.UltimateTeam.Domain.Models
{
    public class DisplayAttribute : Attribute
    {
        public bool Encrypted { get; set; }
        public bool Sensitive { get; set; }
    }
}
