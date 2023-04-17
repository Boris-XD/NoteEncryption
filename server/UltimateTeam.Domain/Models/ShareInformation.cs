using System;
using System.Collections.Generic;

#nullable disable

namespace Dev33.UltimateTeam.Domain.Models
{
    public partial class ShareInformation
    {
        public Guid GuessId { get; set; }
        public Guid InformationId { get; set; }

        public virtual User Guess { get; set; }
        public virtual Information Information { get; set; }
    }
}
